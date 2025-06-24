using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestSharpAPIAutomation.Models
{
    public class PutPlaceRequest
    {
        public string place_id { get; set; }
        public string address { get; set; }
        public string key { get; set; }
    }

    public class PutPlaceResponse
    {
        public string msg { get; set; }
    }
}
