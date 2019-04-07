using ClientsMVVM.Model;
using ClientsMVVM.MVVM;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ClientsMVVM.ViewModel
{
    public delegate void AddClientDelegate(Client client);

    class AddClientViewModel : INotifyPropertyChanged
    {
        private Client client;
        AddClientDelegate addClientDelegate;

        public AddClientViewModel()
        {
            client = new Client();
        }

        public AddClientViewModel(AddClientDelegate addClient)
        {
            client = new Client();
            client.Birthday = DateTime.Now;
            client.ChangeClient = true;
            addClientDelegate += addClient;
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
                OnPropertyChanged();
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
                OnPropertyChanged();
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
                OnPropertyChanged();
            }
        }


        private RelayCommand addCommand;
        public RelayCommand AddCommand
        {
            get
            {
                return addCommand ?? (addCommand = new RelayCommand(obj =>
                {
                    addClientDelegate(client);
                    client.ChangeClient = false;
                    ((Window)obj).Close();
                }));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }

    }
}
