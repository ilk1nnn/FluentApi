using FluentApi.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentApi.Domain.Entities.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        public RelayCommand SelectCustomerCommand { get; set; }
        public RelayCommand SelectOrderCommand { get; set; }
        public RelayCommand AddCommand { get; set; }
        public RelayCommand UpdateCommand { get; set; }
        public RelayCommand ResetCommand { get; set; }
        public RelayCommand DeleteCustomerCommand { get; set; }
        public RelayCommand DeleteOrderCommand { get; set; }
        public RelayCommand  OrderNowCommand { get; set; }

        public MainViewModel()
        {
            Customer = new Customer();
            AllCustomers = new ObservableCollection<Customer>(App.DB.CustomerRepository.GetAllData());
            AllOrders = new ObservableCollection<Order>(App.DB.OrderRepository.GetAllData());


        }

        private Customer customer;

        public Customer Customer
        {
            get { return customer; }
            set { customer = value; OnPropertyChanged(); }
        }


        private Order selectedorder;

        public Order SelectedOrder
        {
            get { return selectedorder; }
            set { selectedorder = value;OnPropertyChanged(); }
        }


        private ObservableCollection<Customer> allcustomers;

        public ObservableCollection<Customer> AllCustomers
        {
            get { return allcustomers; }
            set { allcustomers = value;OnPropertyChanged(); }
        }



        private ObservableCollection<Order> allorders;

        public ObservableCollection<Order> AllOrders
        {
            get { return allorders; }
            set { allorders = value; OnPropertyChanged(); }
        }


    }
}
