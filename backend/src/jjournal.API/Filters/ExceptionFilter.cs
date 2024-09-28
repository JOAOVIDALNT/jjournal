using jjournal.Communication.Responses;
using jjournal.Exception;
using jjournal.Exception.Base;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Net;

namespace jjournal.API.Filters
{
    public class ExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            if (context.Exception is AppBaseException)
                HandleProjectException(context);
            else
                HandleUnknowException(context);
        }

        private void HandleProjectException(ExceptionContext context)
        {
            /* 
             CAST DA EXCEPTION PARA USAR O ATRIBUTO LISTA, PODERIA SER FEITO ATRAVÉS DE DECALRAÇÃO DE VARIÁVEL 
             EX:
             var exception = context.Exception as ErrorOnValidationException; 
            */
            if (context.Exception is ErrorOnValidationException validationException) 
            {
                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                context.Result = new BadRequestObjectResult(new ResponseErrorJson(validationException.ErrorMessages));
            }

        }

        private void HandleUnknowException(ExceptionContext context)
        {
            context.HttpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            context.Result = new ObjectResult(new ResponseErrorJson(ResourceMessageException.UNKNOW_ERROR));
        }
    }
}
