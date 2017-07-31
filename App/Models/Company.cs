using App.Enums;

namespace App.Models {
	public class Company {

		public static string VERY_IMPORTANT_COMPANY = "VeryImportantClient";
		public static string IMPORTANT_COMPANY = "ImportantClient";

		public int Id { get; set; }

		public string Name { get; set; }

		public Classification Classification { get; set; }
	}
}