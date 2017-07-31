using App.Models;
using App.Services;

namespace App.Extensions {
	public static class CustomerExtensions {
		public static void CreditCheck(this Customer customer) {
			if (customer.Company.Name == Company.VERY_IMPORTANT_COMPANY) {
				// Skip credit check
				customer.HasCreditLimit = false;
			} else if (customer.Company.Name == Company.IMPORTANT_COMPANY) {
				// Do credit check and double credit limit
				customer.HasCreditLimit = true;
				using (var customerCreditService = new CustomerCreditServiceClient()) {
					var creditLimit = customerCreditService.GetCreditLimit(customer.Firstname, customer.Surname, customer.DateOfBirth);
					creditLimit = creditLimit * 2;
					customer.CreditLimit = creditLimit;
				}
			} else {
				// Do credit check
				customer.HasCreditLimit = true;
				using (var customerCreditService = new CustomerCreditServiceClient()) {
					var creditLimit = customerCreditService.GetCreditLimit(customer.Firstname, customer.Surname, customer.DateOfBirth);
					customer.CreditLimit = creditLimit;
				}
			}
		}
	}
}
