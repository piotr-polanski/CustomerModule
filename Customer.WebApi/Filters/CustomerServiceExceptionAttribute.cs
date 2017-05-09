using System.Net;
using System.Net.Http;
using System.Web.Http.Filters;
using CustomerService.Exceptions;
using log4net;

namespace Customer.WebApi.Filters
{
	public class CustomerServiceExceptionAttribute : ExceptionFilterAttribute
	{
		private static readonly ILog Log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
		public override void OnException(HttpActionExecutedContext actionExecutedContext)
		{
			Log.Error(actionExecutedContext.Exception.Message, actionExecutedContext.Exception);

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