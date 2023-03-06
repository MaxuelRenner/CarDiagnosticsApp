using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDiagnosticsApp.MVVM.Model
{
    public class FixTypes
    {
        public int ID { get; set; }
        public string TypeF { get; set; }
        public FixTypes(int ID, string typeF)
        {
            this.ID = ID;
            this.TypeF = typeF;
        }
    }
}
