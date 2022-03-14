using Core.Exceptions;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace TechnicalTestITSense_APIRest.Utilities.Handlers
{
    public static class ErrorModelState
    {
        public static void ModelStateValid(this ModelStateDictionary modelStateDiccionary)
        {
            if (!modelStateDiccionary.IsValid)
            {
                IEnumerable<string> query = from values in modelStateDiccionary.Values
                                            from error in values.Errors
                                            select error.ErrorMessage;
                List<string> errorList = query.ToList();
                throw new HttpException(errorList, HttpStatusCode.BadRequest);
            }
        }


    }
}
