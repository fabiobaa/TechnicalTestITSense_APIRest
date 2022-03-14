using System.Collections.Generic;
using System.Text.Json;

namespace TechnicalTestITSense_APIRest.Filter
{
    public class ErrorDetails
    {
        public int StatusCode { get; set; }
        public List<string> Message { get; set; }
        public override string ToString()
        {
            return JsonSerializer.Serialize(this);
        }
    }
}
