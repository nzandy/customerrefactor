using App.Models;

namespace App.Repositories {
	public interface ICustomerDataAccessStrategy {
		void AddCustomer(Customer customer);
	}
}
