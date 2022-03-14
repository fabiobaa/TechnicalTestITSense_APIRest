using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace Core.Exceptions
{
    public class HttpException : Exception
    {


        public List<string> Messages { get; set; }
        public HttpStatusCode StatusCode { get; set; }

        public HttpException()
        {
            Messages = new List<string>();
        }

        public HttpException(HttpStatusCode statusCode = HttpStatusCode.InternalServerError) : this()
        {
            StatusCode = statusCode;
        }

        public HttpException(List<string> messages)
        {
            Messages = messages ?? new List<string>();
        }

        public HttpException(List<string> messages, HttpStatusCode statusCode = HttpStatusCode.InternalServerError) : this()
        {
            StatusCode = statusCode;
            Messages = messages ?? new List<string>();
        }
    }
}
