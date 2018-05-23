using System;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using ClassLibrary1;

namespace Municipalidad
{
  class Program1
  {
    static void Main(string[] args)
    {
      int option = 0;
      while (option < 4)
      {
        Console.WriteLine("Bievenido al programa del registro civil, que desea hacer:\n(1) Registrar Persona\n(2) Registrar Propiedad\n(3) Registar Vehiculo\n(4) Salir\n");
        option = Int32.Parse(Console.ReadLine());
        if (option == 1)
        {
          Console.WriteLine("\nRegistro de Persona:\n");
          Console.WriteLine("Ingrese Nombre:\n");
          String Nombre = Console.ReadLine();
          Console.WriteLine("Ingrese Apellido:\n");
          String Apellido = Console.ReadLine();
          Console.WriteLine("Ingrese Fecha de Nacimiento:\n");
          DateTime FechaNacimiento = DateTime.Parse(Console.ReadLine());
          Console.WriteLine("Ingrese Rut:\n");
          String Rut = Console.ReadLine();
          Person p = new Person(Nombre, Apellido, FechaNacimiento, null, Rut, null, null);
          Console.WriteLine("Se ha registrado correctamente a: " + p.First_name + " " + p.Last_name);
        }
        else if (option == 2)
        {
          bool Patio = true;
          bool Piscina = true;
          Console.WriteLine("\nRegistro de Propiedad:\n");
          Console.WriteLine("Ingrese Calle:\n");
          String Calle = Console.ReadLine();
          Console.WriteLine("Ingrese Numero:\n");
          int Numero = Int32.Parse(Console.ReadLine());
          Console.WriteLine("Ingrese Comuna:\n");
          String Comuna = (Console.ReadLine());
          Console.WriteLine("Ingrese Ciudad:\n");
          String Ciudad = Console.ReadLine();
          Console.WriteLine("Ingrese Año de Construccion:\n");
          int Year = Int32.Parse(Console.ReadLine());
          Console.WriteLine("Ingrese Numero de Piezas:\n");
          int Piezas = Int32.Parse(Console.ReadLine());
          Console.WriteLine("Ingrese Numero de Baños:\n");
          int Banos = Int32.Parse(Console.ReadLine());
          Console.WriteLine("Tiene Patio? (Y/N):\n");
          if (Console.ReadLine().ToUpper().Equals("N")) { Patio = false; }
          Console.WriteLine("Tiene Piscina? (Y/N):\n");
          if (Console.ReadLine().ToUpper().Equals("N")) { Piscina = false; }
          Address a = new Address(Calle, Numero, Comuna, Ciudad, null, Year, Piezas, Banos, Patio, Piscina);
          Console.WriteLine("Se ha registrado correctamente la propiedad en: " + a.Street + ", " + a.Commune + ", " + a.City);
        }
        else if (option == 3)
        {
          bool diesel = true;
          Console.WriteLine("Ingrese Marca:\n");
          String brand = Console.ReadLine();
          Console.WriteLine("Ingrese Modelo:\n");
          String model = Console.ReadLine();
          Console.WriteLine("Ingrese Año:\n");
          int year = Int32.Parse(Console.ReadLine());
          Console.WriteLine("Ingrese Patente:\n");
          String license_plate = Console.ReadLine();
          Console.WriteLine("Ingrese Numero de Asientos:\n");
          int seatbelts = Int32.Parse(Console.ReadLine());
          Console.WriteLine("Diesel? (Y/N):\n");
          if (Console.ReadLine().ToUpper().Equals("N")) { diesel = false; }
          Car c=new Car(brand, model, year, null, license_plate, seatbelts, diesel);
          Console.WriteLine("Se ha registrado correctamente el automovil en: " + c.Model+ ", Modelo: " + c.Model + ", Patente: " + c.License_plate);
        }
        else { }
      }
    }
  }
}
