using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestYourself.Core.Entities.Base
{
    public class ResponseState
    {
        public string ErrorMessage { get; set; }
        public bool IsError { get; set; }
        public string Observation { get; set; }
    }
}
