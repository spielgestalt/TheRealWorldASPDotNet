using System;
using Microsoft.AspNetCore.Mvc;
namespace TheRealWorldASPDotNet.Controllers
{

    public static class ControllerExtensions
    {
        [Serializable]
        public class JSONError { 
            public string Error { get; set; }
            public string Message { get; set; }
        }
        public static JSONError BuildJsonError(this Controller controller,string error, string message) {
            return new JSONError() {
                Error = error,
                Message = message
            };
        }
    }
}
