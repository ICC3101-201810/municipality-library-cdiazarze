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
      List<Person> personas = new List<Person>();
      List<Address> propiedades = new List<Address>();
      List<Car> autos = new List<Car>();
      int option = 0;
      while (option < 7)
      {
        Console.WriteLine("Bievenido al programa del registro civil, que desea hacer:\n(1) Registrar Persona\n(2) Registrar Propiedad\n(3) " +
          "Registar Vehiculo\n(4) Modificar Propiedad\n(5) Modificar Dueño de Automovil\n(6) Modificar Resgistro Persona");
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
          personas.Add(p);
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
          propiedades.Add(a);
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
          Car c = new Car(brand, model, year, null, license_plate, seatbelts, diesel);
          autos.Add(c);
          Console.WriteLine("Se ha registrado correctamente el automovil en: " + c.Model + ", Modelo: " + c.Model + ", Patente: " + c.License_plate);
        }
        else if (option == 4)
        {
          int eleccion = 0;
          int eleccion2 = 0;
          if (propiedades.Count > 0)
          {
            Console.WriteLine("\nElija propiedad a modificar:");
            for (int i = 0; i < propiedades.Count(); i++)
            {
              Console.WriteLine("(" + (i + 1) + ") " + propiedades[i].Street + ", " + propiedades[i].Commune + ", " + propiedades[i].City);
            }
            eleccion = Int32.Parse(Console.ReadLine());
            Address a = propiedades[eleccion - 1];

            while (eleccion2 < 4)
            {
              Console.WriteLine("\nQue desea Modificar?\n(1) Cambiar cantidad de Baños\n(2) Cambiar cantidad de Piezas\n(3) " +
              "Cambiar Dueño\n(4) Volver\n");
              eleccion2 = Int32.Parse(Console.ReadLine());
              if (eleccion2 == 1)
              {
                Console.WriteLine("Ingrese cuantos Baños va a agregar:\n");
                a.addBathrooms(Int32.Parse(Console.ReadLine()));
                Console.WriteLine("Se agregaron correctamente, Baños actuales: " + a.Bathrooms);
              }
              else if (eleccion2 == 2)
              {
                Console.WriteLine("Ingrese cuantas Piezas va a agregar:\n");
                a.addBeedrooms(Int32.Parse(Console.ReadLine()));
                Console.WriteLine("Se agregaron correctamente, Piezas actuales: " + a.Bedrooms);
              }
              else if (eleccion2 == 3)
              {
                if (personas.Count > 0)
                {
                  Console.WriteLine("Seleccione nuevo dueño, si no existe, debe volver al menu y registrarlo primero");
                  for (int j = 0; j < personas.Count(); j++)
                  {
                    Console.WriteLine("(" + (j + 1) + ") " + personas[j].Rut + ": " + personas[j].First_name + " " + personas[j].Last_name);
                  }
                  a.changeOwner(personas[Int32.Parse(Console.ReadLine()) - 1]);
                  Console.WriteLine("Se cambia correctamente");
                }
                else Console.WriteLine("No existen personas registradas, debe registrar primero al nuevo dueño");
              }
            }
          }
          else Console.WriteLine("No existen propiedades registradas");
        }
        else if (option == 5)
        {
          int eleccion = 0;
          if (autos.Count > 0)
          {
            Console.WriteLine("\nElija auto a modificar:");
            for (int i = 0; i < autos.Count(); i++)
            {
              Console.WriteLine("(" + (i + 1) + ") " + autos[i].Brand + ", " + autos[i].Model + ", " + autos[i].License_plate);
            }
            eleccion = Int32.Parse(Console.ReadLine());
            Car c = autos[eleccion - 1];
            if (personas.Count > 0)
            {
              Console.WriteLine("Seleccione nuevo dueño, si no existe, debe volver al menu y registrarlo primero");
              for (int j = 0; j < personas.Count(); j++)
              {
                Console.WriteLine("(" + (j + 1) + ") " + personas[j].Rut + ": " + personas[j].First_name + " " + personas[j].Last_name);
              }
              c.giveUpOwnershipToThirdParty(personas[Int32.Parse(Console.ReadLine()) - 1]);
              Console.WriteLine("Se cambia correctamente");
            }
            else Console.WriteLine("No existen personas registradas, debe registrar primero al nuevo dueño");
          }
          else Console.WriteLine("No existen autos registrados, debe registrar primero algun vehiculo");
        }
        else if (option == 6)
        {

          if (personas.Count > 0)
          {
            Console.WriteLine("Seleccione registro de persona a modificar");
            for (int j = 0; j < personas.Count(); j++)
            {
              Console.WriteLine("(" + (j + 1) + ") " + personas[j].Rut + ": " + personas[j].First_name + " " + personas[j].Last_name);
            }
            Person p = personas[Int32.Parse(Console.ReadLine()) - 1];
            int eleccion2 = 0;
            while (eleccion2 < 4)
            {
              Console.WriteLine("\nQue desea Modificar?\n(1) Cambiar Nombre\n(2) Cambiar Apellido\n(3) " +
              "Ser abandonado\n(4) Ser Adoptado\n(5) Volver\n");
              eleccion2 = Int32.Parse(Console.ReadLine());
              if (eleccion2 == 1)
              {
                Console.WriteLine("Ingrese Nuevo Nombre:\n");
                p.changeFirstName(Console.ReadLine());
                Console.WriteLine("Cambiado el nombre con exito a: "+ p.First_name);
              }
              if (eleccion2 == 2)
              {
                Console.WriteLine("Ingrese Nuevo Apellido:\n");
                p.changeLastName(Console.ReadLine());
                Console.WriteLine("Cambiado el apellido con exito a: "+ p.Last_name);
              }
              if (eleccion2 == 3)
              {
                p.getAbandoned();
                Console.WriteLine("Exito! Usted ya no tiene padres!: ");
              }

            }
          }
          else Console.WriteLine("No existen personas registrados, debe registrar primero alguna persona");
        }
      }
    }
  }
}
