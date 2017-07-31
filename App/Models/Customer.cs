using System;

namespace App.Models
{
    public class Customer
    {

		public Customer(Company company, DateTime dateOfBirth, string emailAddress, string firstName, string lastName) {
			if (string.IsNullOrEmpty(firstName)) throw new ArgumentNullException(nameof(firstName));
			if (string.IsNullOrEmpty(lastName)) throw new ArgumentNullException(nameof(lastName));
			if (!emailAddress.Contains("@") && !emailAddress.Contains(".")) throw new ArgumentException(nameof(emailAddress));
			if (!ValidAge(dateOfBirth)) throw new ArgumentException(nameof(dateOfBirth));

			Company = company;
			DateOfBirth = dateOfBirth;
			EmailAddress = emailAddress;
			Firstname = firstName;
			Surname = lastName;
		}

		private bool ValidAge(DateTime dateOfBirth) {
			var now = DateTime.Now;
			int age = now.Year - dateOfBirth.Year;
			if (now.Month < dateOfBirth.Month || (now.Month == dateOfBirth.Month && now.Day < dateOfBirth.Day)) age--;
			if (age < 21) {
				return false;
			}
			return true;
		}
        public int Id { get; set; }

        public string Firstname { get; set; }

        public string Surname { get; set; }

        public DateTime DateOfBirth { get; set; }

        public string EmailAddress { get; set; }

        public bool HasCreditLimit { get; set; }

        public int CreditLimit { get; set; }

        public Company Company { get; set; }
    }
}