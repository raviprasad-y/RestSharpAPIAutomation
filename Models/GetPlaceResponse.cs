using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestSharpAPIAutomation.Models
{
    public class GetPlaceResponse
    {
        public Location location { get; set; }
        public string accuracy { get; set; }
        public string name { get; set; }
        public string phone_number { get; set; }
        public string address { get; set; }
        public string types { get; set; }
        public string website { get; set; }
        public string language { get; set; }
    }


    public class LocationValue
    {
        public string latitude { get; set; }
        public string longitude { get; set; }
    }
}
