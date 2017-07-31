using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using App.Models;

namespace App.Repositories {
	public static class CustomerDataAccess
    {
        public static void AddCustomer(Customer customer, ICustomerDataAccessStrategy dataAccess)
        {
			dataAccess.AddCustomer(customer);
        }
    }
}
