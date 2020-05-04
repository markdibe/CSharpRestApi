using CustomerAppBll;
using CustomerAppBll.BusinessObjects;
using CustomerAppDAO;
using CustomerAppDAO.Entities;
using System;
using static System.Net.Mime.MediaTypeNames;

namespace CustomerAppUI
{
    class Program
    {
        static BllFacade bllFacade = new BllFacade();

        static void Main(string[] args)
        {
            var cust = new CustomerBO()
            {
                FirstName = "Mark",
                LastName = "Dibeh",
                Address = "Lebanon"
            };
            bllFacade.CustomerService.Create(cust);
            bllFacade.CustomerService.Create(new CustomerBO()
            {
                FirstName = "Jonathan",
                LastName = "Dibeh",
                Address = "Lebanon"
            });
            while (true)
            {
                Console.WriteLine("Enter \n 1- to add customer \n 2- to update customer \n 3- to get a customer \n 4- to get all customer \n 5- to exit");
                int.TryParse(Console.ReadLine(), out int choice);
                CheckUserRequirement(choice);
            }
          

        }

        private static void AddCustomer()
        {
            CustomerBO cust = new CustomerBO();
            Console.WriteLine("First Name :");
            cust.FirstName = Console.ReadLine();

            Console.WriteLine("Last Name :");
            cust.LastName = Console.ReadLine();

            Console.WriteLine("Address Name :");
            cust.Address = Console.ReadLine();

            bllFacade.CustomerService.Create(cust);
            Console.WriteLine("Customer Added Successfully");
        }


        private static void GetCustomer()
        {
            Console.WriteLine("Enter the id of desired customer !");
            int.TryParse(Console.ReadLine(), out int id);
            CustomerBO customer = bllFacade.CustomerService.Get(id);
            string text = customer == null ? $"This Customer does not exist!" : $"First Name : {customer.FirstName} and Last name : {customer.LastName} and Address : {customer.Address}";
            Console.WriteLine(text);
        }

        private static void Edit()
        {
            Console.WriteLine("Enter the Id Of customer you want to edit ");
            int.TryParse(Console.ReadLine(), out int id);
            var cust = bllFacade.CustomerService.Get(id);
            if (cust != null)
            {
                Console.WriteLine("First Name :");
                cust.FirstName = Console.ReadLine();

                Console.WriteLine("Last Name :");
                cust.LastName = Console.ReadLine();

                Console.WriteLine("Address :");
                cust.Address = Console.ReadLine();

                bllFacade.CustomerService.Update(cust);
                Console.WriteLine("Customer Information updated successfully !");
            }
            else
            {
                Console.WriteLine("Customer Not Found ! Please make sure of the ID");
            }
        }

        private static void CustomerList()
        {
            var customerList = bllFacade.CustomerService.GetAll();
            customerList.ForEach(customer =>
            {
                Console.WriteLine(
                    $"Id : {customer.Id} , First Name : {customer.FirstName} , Last Name : {customer.LastName} , Address : {customer.Address}"
                        );
            });
        }

        private static void CheckUserRequirement(int choice)
        {
            switch (choice)
            {
                case 1:
                    AddCustomer();
                    break;
                case 2:
                    Edit();
                    break;
                case 3:
                    GetCustomer();
                    break;
                case 4:
                    CustomerList();
                    break;
                default:
                    CheckUserRequirement(choice);
                    break;
            }
        }
    }
}
