using System;
using App.Repositories;

namespace App.Services {

	/// <summary>
	/// Provides backwards compatibility to clients that are already using the service service.
	/// Tightly coupled with CompanyRepository and SqlCustomerDataAccess classes.
	/// </summary>
	public class CustomerService {

		/// <returns>True if successfuly added, false if an issue parsing the customer. </returns>
		public bool AddCustomer(string firname, string surname, string email, DateTime dateOfBirth, int companyId) {
			var companyRepository = new CompanyRepository();
			var customerAccessStrategy = new SqlCustomerDataAccess();

			return CustomerServiceWithInjection.AddCustomer(companyRepository, customerAccessStrategy,
				firname, surname, email, dateOfBirth, companyId);
		}
	}
}
