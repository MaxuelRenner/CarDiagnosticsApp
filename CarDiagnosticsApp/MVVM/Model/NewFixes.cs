using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDiagnosticsApp.MVVM.Model
{
    public class NewFixes
    {

        public int id { get; set; }
        public int repairid { get; set; }
        public int selectedcarid { get; set; }
        public string data { get; set; }
        public string mileage { get; set; }
        public string price { get; set; }
        public string mechanicsname { get; set; }
        public string serivcenameaddress { get; set; }
        public string description { get; set; }

        public NewFixes(int repairid, int selectedcarid, string data, string mileage, string price, string mechanicsname, string serivcenameaddress, string description)
        {
            this.repairid = repairid;
            this.selectedcarid = selectedcarid;
            this.data = data;
            this.mileage = mileage;
            this.price = price;
            this.mechanicsname = mechanicsname;
            this.serivcenameaddress = serivcenameaddress;
            this.description = description;
        }

    }
}
