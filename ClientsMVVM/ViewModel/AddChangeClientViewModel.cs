using ClientsMVVM.Model;
using ClientsMVVM.MVVM;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;

namespace ClientsMVVM.ViewModel
{
    public delegate void AddClientDelegate(Client client);
    public delegate void ChangeClientDelegate();


    class AddChangeClientViewModel : INotifyPropertyChanged
    {
        private Client client;
        private AddClientDelegate addClientDelegate;
        private ChangeClientDelegate changeClientDelegate;
        private bool isAdd;

        public AddChangeClientViewModel()
        {
            client = new Client();
        }

        public AddChangeClientViewModel(AddClientDelegate addClient)
        {
            client = new Client();
            client.Birthday = DateTime.Now;
            addClientDelegate += addClient;
            isAdd = true;
        }

        public AddChangeClientViewModel(ChangeClientDelegate ChangeClient, Client client)
        {
            changeClientDelegate += ChangeClient;
            isAdd = false;
            this.client = client;
        }

        public string TypeAction
        {
            get
            {
                if (isAdd)
                    return "Добавить";
                else
                    return "Изменить";
            }
        }

        public string Name
        {
            get
            {
                return client.Name;
            }
            set
            {
                client.Name = value;
            }
        }
        public string LastName
        {
            get
            {
                return client.LastName;
            }
            set
            {
                client.LastName = value;
            }
        }
        public DateTime Birthday
        {
            get
            {
                return client.Birthday;
            }
            set
            {
                client.Birthday = value;
            }
        }

        private RelayCommand addCommand;
        public RelayCommand AddCommand
        {
            get
            {
                if (isAdd)
                    return addCommand ?? (addCommand = new RelayCommand(obj =>
                    {
                        addClientDelegate(client);
                        ((Window)obj).Close();
                    }));
                else
                {
                    return addCommand ?? (addCommand = new RelayCommand(obj =>
                    {
                        changeClientDelegate();
                        ((Window)obj).Close();
                    }
                    ));
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }

    }
}
