using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace MyMovie.Web.Extensions
{
    public class ErrorContent
    {
        public HttpStatusCode StatusCode { get; set; }
        public string ErrorMessage { get; set; }

        public string GetErrorMessage()
        {
            return StatusCode == HttpStatusCode.InternalServerError
                ? "Ocorreu um erro não identificado"
                : ErrorMessage;
        }
    }
}
