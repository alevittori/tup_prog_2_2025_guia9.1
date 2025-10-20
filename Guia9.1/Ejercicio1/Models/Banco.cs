using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio1.Models
{
    
    internal class Banco
    {
        List<Persona> listClientes;
        List<Cuenta> listCuentas;

        public Banco()
        {
            listClientes = new List<Persona>();
            listCuentas = new List<Cuenta>();
        }

        bool clienteExist(int dniCliente)//recomendado para listas grandes
        {
            //SI LO HAGO CON BINARYSEARCH
            listClientes.Sort();//ORDERNAR LA LISTA, POR NUMERO DE CUENTA, PROGRAMADO EN EL COMPARETO DE CUENTA
            Persona persona = new Persona("persona",dniCliente);// creamo el objero placebo para buscar


            int resultadoBusqueda = listClientes.BinarySearch(persona);

            return resultadoBusqueda >= 0;

        }
        bool clienteExist(Persona clienteABuscar)//recomendado para listas pequeñas
        {
            return listClientes.Any(clienteEnLista => clienteEnLista.Dni == clienteABuscar.Dni);
        }

        bool cuentaExist(int numeroDeCuenta)
        {
            listCuentas.Sort();
            Persona p = new Persona();
            Cuenta cuentaABuscar = new Cuenta(numeroDeCuenta, p);
            int resultadoBusqueda = listCuentas.BinarySearch(cuentaABuscar);
            return resultadoBusqueda >= 0;

        }
        bool cuentaExist(Cuenta cuentaABuscar)
        {
            return listCuentas.Any(cuentaEnLista => cuentaEnLista.Numero ==  cuentaABuscar.Numero);
        }
        public Cuenta AgregarCuenta(int numeroDeCuenta, int dniDelTitular, string nombreDelTitular)
        {
            Persona titular = new Persona(nombreDelTitular, dniDelTitular);
            Cuenta nuevaCuenta = new Cuenta(numeroDeCuenta, titular);

            //ACA DEBERIAAMOS VALIDAR QUE EL CLIENTE NO EXISTA
            if (titular != null && !clienteExist(titular)) { listClientes.Add(titular); }
            
            //aca deveriamos validar que la cuenta no exista
            if (nuevaCuenta != null && !cuentaExist(nuevaCuenta)) { listCuentas.Add(nuevaCuenta); return nuevaCuenta; }


            return null;

        }
    }
}
