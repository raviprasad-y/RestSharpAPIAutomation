using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestSharpAPIAutomation.Models
{
    public class AddPlaceResponse
    {
        public string status { get; set;} 
        public string place_id { get; set; }
        public string scope { get; set; }   
        public string reference { get; set; }
        public string id { get; set; }
    }
}
