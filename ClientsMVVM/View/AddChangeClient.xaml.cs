using ClientsMVVM.Model;
using ClientsMVVM.ViewModel;
using System.Windows;

namespace ClientsMVVM.View
{
    /// <summary>
    /// Логика взаимодействия для AddClient.xaml
    /// </summary>
    public partial class AddChangeClient : Window
    {
        public AddChangeClient(AddClientDelegate addClient)
        {
            InitializeComponent();
            DataContext = new AddChangeClientViewModel(addClient);
        }

        public AddChangeClient(ChangeClientDelegate changeClient, Client client)
        {
            InitializeComponent();
            DataContext = new AddChangeClientViewModel(changeClient, client);
        }
    }
}
