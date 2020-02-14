using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSBTE
{
    class WeaponClass
    {
       public string name { get; set; }
       public string model { get; set; }
       public string[] info { get; set; }
       public WeaponClass(string name, string model, string[] info)
       {
           this.name = name;
           this.model = model;
           this.info = info;
       }
    }
}
