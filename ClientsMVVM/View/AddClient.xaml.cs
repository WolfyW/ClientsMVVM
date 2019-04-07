using ClientsMVVM.ViewModel;
using System.Windows;

namespace ClientsMVVM.View
{
    /// <summary>
    /// Логика взаимодействия для AddClient.xaml
    /// </summary>
    public partial class AddClient : Window
    {
        public AddClient(AddClientDelegate addClient)
        {
            InitializeComponent();
            DataContext = new AddClientViewModel(addClient);
        }
    }
}
