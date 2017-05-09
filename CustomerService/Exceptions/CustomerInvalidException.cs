using System;

namespace CustomerService.Exceptions
{
	public class CustomerInvalidException : Exception
	{
		public CustomerInvalidException(string message): base (message)
		{
		}
	}
}
