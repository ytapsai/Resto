using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using Swagger_Resto_pub_DBSetup.Model;
using Swagger_Resto_pub_Domain.Repo;
using Swagger_Resto_pub_DBSetup;

namespace Swagger_Test_Wpf_Admin
{
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        private DomainController _domainController;
        private ObservableCollection<ClientEf> _clients;

        public event PropertyChangedEventHandler PropertyChanged;

        public ObservableCollection<ClientEf> Clients
        {
            get { return _clients; }
            set
            {
                _clients = value;
                OnPropertyChanged(nameof(Clients));
            }
        }

        public MainWindow(AppDbContext dbContext)
        {
            InitializeComponent();

            var clientRepo = new ClientRepo(dbContext);
            _domainController = new DomainController(clientRepo);

            // Load clients from the domain controller
            Clients = new ObservableCollection<ClientEf>(_domainController.GetAll());

            // Set the data context of the data grid to the clients collection
            dgClients.DataContext = Clients;
        }

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            // Create a new client based on the text box values
            var client = new ClientEf
            {
                Id = int.Parse(txtId.Text),
                FirstName = txtFirstName.Text,
                LastName = txtLastName.Text,
                Street = txtStreet.Text,
                HouseNumber = int.Parse(txtHouseNumber.Text),
                BusNumber = txtBusNumber.Text,
                City = txtCity.Text,
                PostalCode = int.Parse(txtPostalCode.Text),
                Country = txtCountry.Text,
                PhoneNumber = int.Parse(txtPhoneNumber.Text),
                EmailAddress = txtEmailAddress.Text,
                Password = txtPassword.Text,
                NumberOfOrders = int.Parse(txtNumberOfOrders.Text)
            };

            // Add the client to the domain controller and update the clients collection
            _domainController.Add(client);
            Clients.Add(client);

            // Clear the text boxes
            ClearTextBoxes();
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            // Get the selected client from the data grid
            var selectedClient = dgClients.SelectedItem as ClientEf;
            if (selectedClient != null)
            {
                // Remove the client from the domain controller and update the clients collection
                _domainController.Delete(selectedClient);
                Clients.Remove(selectedClient);
            }
        }

        private void Update_Click(object sender, RoutedEventArgs e)
        {
            // Get the selected client from the data grid
            var selectedClient = dgClients.SelectedItem as ClientEf;
            if (selectedClient != null)
            {
                // Update the client's properties based on the text box values
                selectedClient.Id = int.Parse(txtId.Text);
                selectedClient.FirstName = txtFirstName.Text;
                selectedClient.LastName = txtLastName.Text;
                selectedClient.Street = txtStreet.Text;
                selectedClient.HouseNumber = int.Parse(txtHouseNumber.Text);
                selectedClient.BusNumber = txtBusNumber.Text;
                selectedClient.City = txtCity.Text;
                selectedClient.PostalCode = int.Parse(txtPostalCode.Text);
                selectedClient.Country = txtCountry.Text;
                selectedClient.PhoneNumber = int.Parse(txtPhoneNumber.Text);
                selectedClient.EmailAddress = txtEmailAddress.Text;
                selectedClient.Password = txtPassword.Text;
                selectedClient.NumberOfOrders = int.Parse(txtNumberOfOrders.Text);

                // Update the client in the domain controller
                _domainController.Update(selectedClient);
            }
        }

        private void ClearTextBoxes()
        {
            txtId.Text = "";
            txtFirstName.Text = "";
            txtLastName.Text = "";
            txtStreet.Text = "";
            txtHouseNumber.Text = "";
            txtBusNumber.Text = "";
            txtCity.Text = "";
            txtPostalCode.Text = "";
            txtCountry.Text = "";
            txtPhoneNumber.Text = "";
            txtEmailAddress.Text = "";
            txtPassword.Text = "";
            txtNumberOfOrders.Text = "";
        }
    }
}
