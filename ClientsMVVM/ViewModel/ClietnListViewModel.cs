using ClientsMVVM.Model;
using ClientsMVVM.MVVM;
using ClientsMVVM.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;

namespace ClientsMVVM.ViewModel
{
    class ClietnListViewModel : INotifyPropertyChanged
    {
        ObservableCollection<Client> clients;
        Client selectedClient;

        public ClietnListViewModel()
        {
            clients = new ObservableCollection<Client>();
            List<Client> clientList = CRUDOperation.GetClients();
            foreach (var cl in clientList)
            {
                clients.Add(cl);
            }
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
                selectedClient = value;
                OnPropertyChanged();
            }
        }

        public void AddClient(Client client)
        {
            Clients.Add(client);
            CRUDOperation.AddClient(client);
        }

        public void ChangeClient()
        {
            CRUDOperation.Updateclient();
            OnPropertyChanged("Clients");
        }

        private RelayCommand deleteCommand;
        public RelayCommand DeleteCommand
        {
            get
            {
                return deleteCommand ?? (deleteCommand = new RelayCommand(obj =>
                {
                    if (selectedClient != null)
                    {
                        CRUDOperation.RemoveClient(selectedClient);
                        Clients.Remove(selectedClient);
                    }
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
                    {
                        AddChangeClient add = new AddChangeClient(ChangeClient, selectedClient);
                        add.ShowDialog();
                    }
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
                    AddChangeClient add = new AddChangeClient(AddClient);
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
