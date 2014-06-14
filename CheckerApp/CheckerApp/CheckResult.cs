using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CheckerApp
{
    class CheckResult
    {
        public enum StatusCode : int
        {
            OK = 0,
            ERROR = 1
        }

            public StatusCode code;
            public String message;
    }
}
