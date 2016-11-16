using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestDrive.HttpClient
{
    public class Constants
    {
        public const string REQUEST_EXCEPTION = "Error while making http request.";
        public const string REQUEST_PARSE_JSON_EXCEPTION = "Error in parsing JSON output.";
        public const string REQUEST_CALLBACK_EXCEPTION = "Please ensure your device is connected with the internet.";

        public const string NOT_IMPLEMENTED_EXCEPTION_MESSAGE = "Request is unitialized";
        public const string GRACEFUL_EXECUTION_MESSAGE = "The last request completed gracefully without any exception.";
    }
}
