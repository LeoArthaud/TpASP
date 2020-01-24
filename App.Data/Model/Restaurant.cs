using System;
using System.Collections.Generic;
using System.Text;

namespace App.Data.Model
{
    public class Restaurant
    {
        public int id { get; set; }
        public string name { get; set; }
        public string phone { get; set; }
        public string comment { get; set; }
        public string email { get; set; }
        public Note note { get; set; }
        public Address address { get; set; }
    }
}
