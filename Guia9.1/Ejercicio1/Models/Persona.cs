using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio1.Models
{
    internal class Persona:IComparable<Persona>
    {
        string nombre;
        int dni;

        public string Nombre { get => nombre; private set => nombre = value; }
        public int Dni { get => dni; private set => dni = value; }

        public Persona() { }
        public Persona(string nombre, int dni)
        {
            Nombre = nombre;
            Dni = dni;
        }

        public override string ToString()
        {
            return $"{Nombre} (DNI: {Dni})";
        }

        public int Compareto(Persona other)
        {
            if (other == null) return -1;
            return this.Dni.CompareTo(other.Dni);
        }

    }
}
