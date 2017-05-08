namespace CustomerService.Entities
{
	public class Customer
	{
		public string Name { get; set; }
		public string Surname { get; set; }
		public string TelephoneNumber { get; set; }
		public Address Address { get; set; }

	}
}