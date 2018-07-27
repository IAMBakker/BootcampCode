using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BootCamp.Model
{
    class Auto
    {
        public String Color { get; set; }
        public int AmountOfWheels { get; set; }
        public String Brand { get; set; }
        public int AmountOfDoors { get; set; }
        public Motor CarMotor { get; set; }
        public int Torque { get; set; }

        public Auto()
        {

        }

        public Auto(string color, int amountOfWheels, string brand, Motor carMotor)
        {
            Color = color;
            AmountOfWheels = amountOfWheels;
            Brand = brand;
            CarMotor = carMotor;
            Torque = carMotor.calculateTorque();
        }

        public override bool Equals(object obj)
        {
            var auto = obj as Auto;
            return auto != null &&
                   Color == auto.Color &&
                   AmountOfWheels == auto.AmountOfWheels &&
                   Brand == auto.Brand;
        }

        public override int GetHashCode()
        {
            var hashCode = 1084575758;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Color);
            hashCode = hashCode * -1521134295 + AmountOfWheels.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Brand);
            return hashCode;
        }

        public void PrintAuto()
        {
            Console.WriteLine("Color: " + Color);
            Console.WriteLine("AmountOfWheels: " + AmountOfWheels);
            Console.WriteLine("Brand: " + Brand);
            Console.WriteLine("AmountOfDoors: " + AmountOfDoors);
            Console.WriteLine("Torque: " + Torque);
            Console.WriteLine("Motor:");
            CarMotor.PrintMotor();
        }

        public class Motor
        {
            public String Name { get; set; }
            public int Force { get; set; }
            public int RPM { get; set; }

            public Motor(string name, int force, int rPM)
            {
                Name = name;
                Force = force;
                RPM = rPM;
            }

            public int calculateTorque()
            {
                return (Force * 5252) / RPM;
            }

            public void PrintMotor()
            {
                Console.WriteLine("Name: " + Name);
                Console.WriteLine("Force: " + Force);
                Console.WriteLine("RPM: " + RPM);
            }
        }

    }
}
