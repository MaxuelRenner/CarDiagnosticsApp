using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDiagnosticsApp.MVVM.Model
{
    public class Vehicle
    {
        public int id { get; set; }
        public int typeid { get; set; }
        public string brand { get; set; }
        public string model { get; set; }
        public string generation { get; set; }
        public string fuel { get; set; }
        public string mileage { get; set; }
        public string plate { get; set; }

        public Vehicle(int id, int typeid, string brand, string model, string generation, string fuel, string mileage, string plate)
        {
            this.id = id;
            this.typeid = typeid;
            this.brand = brand;
            this.model = model;
            this.generation = generation;
            this.fuel = fuel;
            this.mileage = mileage;
            this.plate = plate;
        }
        
        public Vehicle(int typeid, string brand, string model, string generation, string fuel, string mileage, string plate)
        {
            this.typeid = typeid;
            this.brand = brand;
            this.model = model;
            this.generation = generation;
            this.fuel = fuel;
            this.mileage = mileage;
            this.plate = plate;
        }


    }
}
