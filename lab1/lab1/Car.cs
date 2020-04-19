using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab1
   {
        public class Car
        {
            private string _brand;
            private string _model;
            private int _doors;
            private float _engine;
            private double _fuelCons;

            private static int _carCount = 0;

            public string Brand
            {
                get { return _brand; }
                set { _brand = value; }
            }
            public string Model
            {
                get { return _model; }
                set { _model = value; }
            }
            public int Doors
            {
                get { return _doors; }
                set { _doors = value; }
            }
            public float Engine
            {
                get { return _engine; }
                set { _engine = value; }
            }
            public double FuelCons
            {
                get { return _fuelCons; }
                set { _fuelCons = value; }
            }
            public Car()
            {
                _brand = "";
                _model = "";
                _doors = 0;
                _engine = 0.0;
                _fuelCons = 0.0;
                CarCount++;
            }
            public Car(string brand, string model, int doors, float engine, double fuelCons)
            {
                _brand = brand;
                _model = model;
                _doors = doors;
                _engine = engine;
                _fuelCons = fuelCons;
                _carCount++;
            }
            public double CalcCons(double roadLength)
            {
                return (_fuelCons * roadLength) / 100.0;
            }
            public double CalcCost(double roadLength, double petrolCost)
            {
                return CalcCons(roadLength) * petrolCost;
            }
            public static void Details()
            {
                Console.WriteLine(this);
            }
            public static void CarCount()
            {
                Console.WriteLine($"Car count: {_carCount}");
            }

        }
    }

}
}
