using Ejercicio1.Models;
using System.Net;
using System.Runtime.Serialization.Formatters.Binary;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Ejercicio1
{
    public partial class Form1 : Form
    {
        Banco miBanco;
        string nombreBackup = "Ejercicio1.dat";
        public Form1()
        {
            InitializeComponent();
            miBanco = new Banco();
            /*
            miBanco.AgregarCuenta(377, 33502599, "Ale");
            miBanco.AgregarCuenta(844, 33502599, "Ale");
            miBanco.AgregarCuenta(501, 33502899, "Stefy");
            miBanco.AgregarCuenta(704, 33422599, "Sheila");
            miBanco.AgregarCuenta(956, 33509699, "Raul");
            */
        }

        private void btnVerCuentas_Click(object sender, EventArgs e)
        {
            //lBDetalles.Items.Clear();
            //foreach(Cuenta cuenta in )
            miBanco.ListarCuentas(lBDetalles);
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            /*
            if (!File.Exists(nombreBackup)) { return ; }
            try
            {
                using FileStream fs = new FileStream(nombreBackup, FileMode.Open);
                BinaryFormatter formatter = new BinaryFormatter();
                miBanco = (Banco)formatter.Deserialize(fs);

            }catch(Exception ex) { MessageBox.Show(ex.Message, "Error"); }
            */
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            /*
            try
            {
                using FileStream fs = new FileStream(nombreBackup, FileMode.Create);
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(fs, miBanco);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Error"); }
            */
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnImportar_Click(object sender, EventArgs e)
        {
            OpenFileDialog openDialog = new OpenFileDialog
            {
                InitialDirectory = AppDomain.CurrentDomain.BaseDirectory,
                Title = "Importar Cuentas"

            };


            if (openDialog.ShowDialog() != DialogResult.OK) { return; }
            try
            {
                using (StreamReader lector = new StreamReader(openDialog.FileName))
                {
                    string cabecera = lector.ReadLine(); // descartamos la cabecera

                    while (!lector.EndOfStream)
                    {
                        //DNI; nombre; número de cuenta; saldo
                        string[] grupo = lector.ReadLine().Split(';');

                        if (grupo.Length != 4)
                            return;

                        #region Parsing
                        int dni = Convert.ToInt32(grupo[0]);
                        string nombre = grupo[1];

                        int numeroCuenta = Convert.ToInt32(grupo[2]);
                        double saldo = Convert.ToDouble(grupo[3]);
                        #endregion

                        miBanco.AgregarCuenta(numeroCuenta, dni, nombre, saldo);


                    }
                }

            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Title = "Guarde las Cuentas"
            };


            if (saveFileDialog.ShowDialog() != DialogResult.OK) return;
            try
            {
                using (StreamWriter sr = new StreamWriter(saveFileDialog.FileName))
                {
                    string cabecera = "DNI; nombre; número de cuenta; saldo";
                    sr.WriteLine(cabecera);
                    foreach (Cuenta aExportar in miBanco.ObtenerCuentasConSaldoMayorA(10000))
                    {
                        sr.WriteLine($"{aExportar.Titular.Dni};{aExportar.Titular.Nombre};{aExportar.Numero};{aExportar.Saldo}");
                    }
                }
                MessageBox.Show("Se Exporto correctamente", "Exito");
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Error"); }
        }


        private void btnResguardar_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveDialog = new SaveFileDialog
            {
                InitialDirectory = Application.StartupPath,
                Title = "Resguardar Datos"
            };

            if (saveDialog.ShowDialog() != DialogResult.OK) { return; }

            FileStream fs = null;
            StreamWriter sr = null;
            try
            {
                fs = new FileStream(saveDialog.FileName, FileMode.OpenOrCreate, FileAccess.Write);
                sr = new StreamWriter(fs);

                string[] clientes = miBanco.ObtenerListaStringClientes();
                string[] cuentas = miBanco.ObtenerListaStringCuentas();
                sr.WriteLine("TIPO;DNI;NOMBRE;NUMERODECUENTA;SALDO");
                foreach (string cliente in clientes)
                {
                    sr.WriteLine(cliente);
                }
                foreach (string cuenta in cuentas)
                {
                    sr.WriteLine(cuenta);
                }

                MessageBox.Show("Reslpado Exitoso");
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            finally
            {
                if (sr != null) sr.Close();
                if (fs != null) fs.Close();
            }
        }

        private void btnRestaurar_Click(object sender, EventArgs e)
        {
            OpenFileDialog openDialog = new OpenFileDialog
            {
                InitialDirectory = Application.StartupPath,
                Title = "Restaurar desde archivo"
            };

            if (openDialog.ShowDialog() != DialogResult.OK) return;

            Banco bancoTemporal = new Banco();

            try
            {
                using FileStream fs = new FileStream(openDialog.FileName, FileMode.Open, FileAccess.Read);
                using StreamReader sr = new StreamReader(fs);

                bancoTemporal.RestaurarDesdeStream(sr);
                DialogResult confirmar = MessageBox.Show("Si restaura se perdera toda la informacion del contexto actual. ¿Desea Proseguir?","Seguro de Restaurar?",MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (confirmar == DialogResult.Yes)
                {
                    miBanco = bancoTemporal;
                    MessageBox.Show("Restauración exitosa");
                }
                else
                {
                    MessageBox.Show("No se realizo restauracion", "Restauracion Cancelada", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al restaurar: " + ex.Message);
            }
        }
    }
}
