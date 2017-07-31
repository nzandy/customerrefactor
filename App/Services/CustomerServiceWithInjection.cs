using System;
using App.Repositories;
using App.Models;
using App.Extensions;

namespace App.Services {

	/// <summary>
	/// New class that supports dependency injection to improve testability and extensibility.
	/// </summary>
	public static class CustomerServiceWithInjection {
		public static bool AddCustomer(ICompanyRepository companyRepo, ICustomerDataAccessStrategy customerDataAccess,
			string firname, string surname, string email, DateTime dateOfBirth, int companyId) {

			Company company = companyRepo.GetById(companyId);

			try {
				var customer = new Customer(company, dateOfBirth, email, firname, surname);
				customer.CreditCheck();
				if (customer.HasCreditLimit && customer.CreditLimit < 500) {
					return false;
				}

				CustomerDataAccess.AddCustomer(customer, customerDataAccess);
				return true;

			} catch (Exception ex) {
				// Customer related validation handled in Customer constructor, throws exception if any parameters
				// Are invalid.
				return false;
			}
		}
	}
}
