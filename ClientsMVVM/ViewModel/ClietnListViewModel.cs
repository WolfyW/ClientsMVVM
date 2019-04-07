using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using ClientsMVVM.Model;
using ClientsMVVM.MVVM;
using ClientsMVVM.View;

namespace ClientsMVVM.ViewModel
{
    class ClietnListViewModel : INotifyPropertyChanged
    {
        ObservableCollection<Client> clients;
        Client selectedClient;

        public ClietnListViewModel()
        {
            clients = new ObservableCollection<Client>()
            {
                new Client() {Name = "Jhon", LastName = "Green", Birthday = DateTime.Parse("1987, 3, 24") },
                new Client() {Name = "Klerk", LastName = "Treens", Birthday = DateTime.Parse("1976, 3, 21")},
                new Client() {Name = "Sam", LastName = "Miltor", Birthday =   DateTime.Parse("1995, 8, 11")},
                new Client() {Name = "Mily", LastName = "Near", Birthday =    DateTime.Parse("1987, 3, 24")}
            };
        }

        public ObservableCollection<Client> Clients
        {
            get
            {
                return clients;
            }
            set
            {
                clients = value;
                OnPropertyChanged();
            }
        }

        public Client SelectedClient
        {
            get
            {
                return selectedClient;
            }
            set
            {
                if (selectedClient != null)
                    selectedClient.ChangeClient = false; // Если изменяли клиента, то изменяем состояние обратно на закрытое
                selectedClient = value;
                OnPropertyChanged();
            }
        }

        public void AddClient(Client client)
        {
            Clients.Add(client);
        }

        private RelayCommand deleteCommand;
        public RelayCommand DeleteCommand
        {
            get
            {
                return deleteCommand ?? (deleteCommand = new RelayCommand(obj =>
                {
                    if (selectedClient != null)
                        Clients.Remove(selectedClient);
                }
                ));
            }
        }

        private RelayCommand changeCommand;
        public RelayCommand ChangeCommand
        {
            get
            {
                return changeCommand ?? (changeCommand = new RelayCommand(obj =>
                {
                    if (selectedClient != null)
                        selectedClient.ChangeClient = !selectedClient.ChangeClient;
                }));
            }
        }

        private RelayCommand addCommand;
        public RelayCommand AddCommand
        {
            get
            {
                return addCommand ?? (addCommand = new RelayCommand(obj =>
                {
                    AddClient add = new AddClient(AddClient);
                    add.ShowDialog();
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
