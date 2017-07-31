using App.Models;

namespace App.Repositories {
	interface ICustomerRepository {
		void AddCustomer(Customer customer);
	}
}
