using System;

namespace CustomerService.Exceptions
{
	public class AddressInvalidException : Exception
	{
		public AddressInvalidException(string message) : base(message)
		{
			
		}
	}
}