using System.Net;
using System.Net.Http;
using System.Web.Http.Filters;
using CustomerService.Exceptions;

namespace Customer.WebApi.Filters
{
	public class CustomerServiceExceptionAttribute : ExceptionFilterAttribute
	{
		public override void OnException(HttpActionExecutedContext actionExecutedContext)
		{
			if (actionExecutedContext.Exception is CustomerInvalidException)
			{
				actionExecutedContext.Response = new HttpResponseMessage(HttpStatusCode.BadRequest)
				{
					ReasonPhrase = actionExecutedContext.Exception.Message,
					
				};
			}
			else if (actionExecutedContext.Exception is EntityNotFoundException)
			{
				actionExecutedContext.Response = new HttpResponseMessage(HttpStatusCode.NotFound);
			}
			else
			{
				actionExecutedContext.Response = new HttpResponseMessage(HttpStatusCode.InternalServerError);
			}
		}
	}
}