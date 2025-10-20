using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio1.Models
{
    [Serializable]
    internal class Cuenta: IComparable<Cuenta>
    {
        Persona titular;
        int numero;
        double saldo;
        DateTime fecha;

        public int Numero { get => numero; private set => numero = value; }
        public double Saldo { get => saldo; private set => saldo = value; }
        public DateTime Fecha { get => fecha; private set => fecha = value; }
        internal Persona Titular { get => titular; private set => titular = value; }
    
    
        public Cuenta(int num, Persona titular)
        {
            Titular = titular;
            Numero = num;
            Saldo = 0;
            fecha = DateTime.Now;
        }

        public Cuenta(int num, Persona titular, DateTime fecha, double saldo) {
            Titular = titular;
            Numero = num;
            Fecha = fecha;
            Saldo = saldo;
        }

        public int CompareTo(Cuenta other)
        {
            if (other == null ) return -1;
            return this.Numero.CompareTo(other.Numero);
        }

        public override string ToString()
        {
            return $"{Numero} - Titutalar: {Titular.ToString()}. Saldo: {Saldo:c}";
        }
    }
}
