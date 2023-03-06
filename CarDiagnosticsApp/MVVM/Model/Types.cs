using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDiagnosticsApp.MVVM.Model
{
    public class Types
    {
        public int ID { get; set; }
        public string TypeV { get; set; }
        public Types(int ID, string typeV)
        {
            this.ID = ID;
            this.TypeV = typeV;
        }
    }
}
