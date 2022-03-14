using Core.Exceptions;
using Core.Models.ResponseRequest;
using System.Collections.Generic;
using System.Net;


namespace Core.Utilities.Handlers
{
    public static class ErrorHandlers
    {
        public static void ObjectIfIsNotNull(this object obj)
        {
            if (obj == null)
            {
                throw new HttpException(new List<string> { "Requested resource does not exist" }, HttpStatusCode.NotFound);
            }
        }

 

        public static void RequestResponseUnsuccessful(this ResponseRequest responseRequest)
        {
            if (!responseRequest.Success)
            {
                throw new HttpException(new List<string> { responseRequest.Message }, HttpStatusCode.BadRequest);
            }
        }

        public static void ListIfIsEmpty(this int count)
        {
            if (count == 0)
            {
                throw new HttpException(new List<string> { "There is no data to show" }, HttpStatusCode.NotFound);
            }
        }

     
    }
}
