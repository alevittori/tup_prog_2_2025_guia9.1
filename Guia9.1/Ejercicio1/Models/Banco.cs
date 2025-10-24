using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio1.Models
{
    [Serializable]
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
        public Cuenta AgregarCuenta(int numeroDeCuenta, int dniDelTitular, string nombreDelTitular, double saldo = 0)
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
            if (nuevaCuenta != null)
            { 
                if(!cuentaExist(nuevaCuenta))
                {
                    nuevaCuenta.ActualizarSaldo(saldo);
                    listCuentas.Add(nuevaCuenta);
                    listCuentas.Sort();
                    return nuevaCuenta; 

                }else
                {
                    //si la cuenta existe solo actualizar el salgo como pide en el partado c de Importacion
                    Cuenta aModificar = listCuentas.FirstOrDefault(c => c.Numero == numeroDeCuenta);
                    if (aModificar != null) { aModificar.ActualizarSaldo(nuevaCuenta.Saldo); }

                }
            }

            


            return null;

        }

        public void ListarCuentas(ListBox lista)
        {
                lista.Items.Clear();
                lista.Items.Add(@"Cuenta n° | Nombre       |     Saldo");
                lista.Items.Add(@"--------------------------------------------");
            foreach(Cuenta cuenta in listCuentas)
            {
                lista.Items.Add(cuenta);

            }
        }

        public List<Cuenta> ObtenerCuentasConSaldoMayorA(double saldo)
        {
            List<Cuenta> lista = new List<Cuenta>();
            foreach(Cuenta c in listCuentas)
            {
                if(c.Saldo > saldo) {  lista.Add(c); }
            }

            return lista;
        }

        public string[] ObtenerListaStringCuentas() 
        {
            string[] listacuenta = new string[CantidadCuentas];
            int n = 0;
            foreach (Cuenta c in listCuentas)
            {
                //"DNI; nombre; número de cuenta; saldo";
                listacuenta[n++] = $"{c.GetType().Name};{c.Titular.Dni};{c.Titular.Nombre};{c.Numero};{c.Saldo}";
            }

            return listacuenta;
        
        }

        public string[] ObtenerListaStringClientes() 
        {
            string[] listaclientes = new string[CantidadClientes];
            int n = 0;
            foreach (Persona c in listClientes)
            {
                //"DNI; nombre; número de cuenta; saldo";
                listaclientes[n++] = $"{c.GetType().Name};{c.Nombre};{c.Dni}";
            }

            return listaclientes;

        }
    }
}
