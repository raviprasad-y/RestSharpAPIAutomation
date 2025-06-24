using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestSharpAPIAutomation.Models
{
    public class AddPlaceRequest
    {
        public Location location { get; set; }
        public int accuracy { get; set; }
        public string name { get; set; }
        public string phone_number { get; set; }
        public string address { get; set; }
        public List<string> types { get; set; }
        public string website { get; set; }
        public string language { get; set; }
    }
    public class Location() 
    {
        public double lat { get; set; }
        public double lng { get; set; }
    }
}
