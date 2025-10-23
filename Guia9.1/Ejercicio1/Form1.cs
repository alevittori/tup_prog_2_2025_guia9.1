using Ejercicio1.Models;

namespace Ejercicio1
{
    public partial class Form1 : Form
    {
        Banco miBanco;
        public Form1()
        {
            InitializeComponent();
            miBanco = new Banco();
            miBanco.AgregarCuenta(377, 33502599, "Ale");
            miBanco.AgregarCuenta(844, 33502599, "Ale");
            miBanco.AgregarCuenta(501, 33502899, "Stefy");
            miBanco.AgregarCuenta(704, 33422599, "Sheila");
            miBanco.AgregarCuenta(956, 33509699, "Raul");
        }

        private void btnVerCuentas_Click(object sender, EventArgs e)
        {
            //lBDetalles.Items.Clear();
            //foreach(Cuenta cuenta in )
            miBanco.ListarCuentas(lBDetalles);
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnImportar_Click(object sender, EventArgs e)
        {
            OpenFileDialog openDialog = new OpenFileDialog
            {
                InitialDirectory = AppDomain.CurrentDomain.BaseDirectory
            };

           
            if(openDialog.ShowDialog() != DialogResult.OK){ return; }
            try
            {
                using(StreamReader lector = new StreamReader(openDialog.FileName))
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

            }catch(Exception ex) {MessageBox.Show(ex.Message,"Error",MessageBoxButtons.OK,MessageBoxIcon.Error); }
        }
    }
}
