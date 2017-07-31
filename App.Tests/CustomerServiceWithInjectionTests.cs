using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using App.Services;
using App.Repositories;
using App.Models;
using Moq;

namespace App.Tests {
	[TestClass]
	public class CustomerServiceWithInjectionTests {
		private static readonly DateTime INVALID_BIRTHDATE_TOO_YOUNG = new DateTime(2010, 12, 8);
		private static readonly DateTime VALID_BIRTHDATE = new DateTime(1990, 12, 8);

		private static readonly string INVALID_EMAIL = "google";
		private static readonly string VALID_EMAIL = "larry@google.com";

		private static Company VERY_IMPORTANT_COMPANY = new Company {
			Id = 1,
			Name = Company.VERY_IMPORTANT_COMPANY
		};

		private static Company NOT_IMPORTANT_COMPANY = new Company
		{
			Id = 2,
			Name = "Stupid Company"
		};

		private ICompanyRepository _companyRepository;
		private ICustomerDataAccessStrategy _customerDataAccess;

		[TestInitialize]
		public void Setup() {
			//Setup mock dependencies.
			var companyRepoMock = new Mock<ICompanyRepository>();
			companyRepoMock.Setup(c => c.GetById(1)).Returns(VERY_IMPORTANT_COMPANY);
			companyRepoMock.Setup(c => c.GetById(2)).Returns(NOT_IMPORTANT_COMPANY);
			_companyRepository = companyRepoMock.Object;

			var customerDataAccessMock = new Mock<ICustomerDataAccessStrategy>();
			_customerDataAccess = customerDataAccessMock.Object;

		}

		[TestMethod]
		public void ValidCustomerReturnsTrue() {
			bool result = CustomerServiceWithInjection.AddCustomer(_companyRepository, _customerDataAccess,
				"Larry", "Page", VALID_EMAIL, VALID_BIRTHDATE, 1);

			Assert.IsTrue(result);
		}

		[TestMethod]
		public void InvalidCustomerBirthdayReturnsFalse() {
			bool result = CustomerServiceWithInjection.AddCustomer(_companyRepository, _customerDataAccess,
				"Larry", "Page", VALID_EMAIL, INVALID_BIRTHDATE_TOO_YOUNG, 1);

			Assert.IsFalse(result);
		}

		[TestMethod]
		public void InvalidCustomerEmailReturnsFalse() {
			bool result = CustomerServiceWithInjection.AddCustomer(_companyRepository, _customerDataAccess,
				"Larry", "Page", INVALID_EMAIL, VALID_BIRTHDATE, 1);

			Assert.IsFalse(result);
		}
	}
}
