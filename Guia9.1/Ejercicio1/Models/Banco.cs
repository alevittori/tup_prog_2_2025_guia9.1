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

        public int CantidadCuentas { get { return listCuentas.Count; } private set { } }
        public int CantidadClientes {  get { return listClientes.Count; } private set { }  }

        public Cuenta this[int idx]
        {
            get
            {
                if (idx >= 0 && idx < listCuentas.Count) 
                    return listCuentas[idx];
                else
                    throw new IndexOutOfRangeException("Indice fuera de rango");
            }
                
        }

        public Banco()
        {
            listClientes = new List<Persona>();
            listCuentas = new List<Cuenta>();
        }

        bool clienteExist(int dniCliente)//recomendado para listas grandes
        {
            //SI LO HAGO CON BINARYSEARCH
            //listClientes.Sort();//ORDERNAR LA LISTA, POR NUMERO DE CUENTA, PROGRAMADO EN EL COMPARETO DE CUENTA
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
           // listCuentas.Sort();
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

            if (string.IsNullOrWhiteSpace(nombreDelTitular))
                throw new ArgumentException("El nombre no puede estar vacío.");
            if (numeroDeCuenta <= 0)
                throw new ArgumentException("El número de cuenta debe ser positivo.");



            Persona titular = new Persona(nombreDelTitular, dniDelTitular);
            Cuenta nuevaCuenta = new Cuenta(numeroDeCuenta, titular);



            //ACA DEBERIAAMOS VALIDAR QUE EL CLIENTE NO EXISTA
            if (titular != null && !clienteExist(titular)) 
            { 
                listClientes.Add(titular);
                listClientes.Sort();
            }
            
            //aca deveriamos validar que la cuenta no exista
            if (nuevaCuenta != null && !cuentaExist(nuevaCuenta)) 
            { 
                listCuentas.Add(nuevaCuenta);
                listCuentas.Sort();
                return nuevaCuenta; 
            }


            return null;

        }

        public void ListarCuentas(ListBox lista)
        {
            foreach(Cuenta cuenta in listCuentas)
            {
                lista.Items.Add(cuenta);

            }
        }
    }
}
