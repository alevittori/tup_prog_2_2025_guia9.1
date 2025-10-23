namespace Ejercicio1
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lBDetalles = new ListBox();
            btnVerCuentas = new Button();
            btnImportar = new Button();
            btnExportar = new Button();
            btnResguardar = new Button();
            btnRestaurar = new Button();
            btnSalir = new Button();
            SuspendLayout();
            // 
            // lBDetalles
            // 
            lBDetalles.FormattingEnabled = true;
            lBDetalles.Location = new Point(12, 64);
            lBDetalles.Name = "lBDetalles";
            lBDetalles.Size = new Size(577, 289);
            lBDetalles.TabIndex = 0;
            // 
            // btnVerCuentas
            // 
            btnVerCuentas.Location = new Point(621, 64);
            btnVerCuentas.Name = "btnVerCuentas";
            btnVerCuentas.Size = new Size(167, 47);
            btnVerCuentas.TabIndex = 1;
            btnVerCuentas.Text = "Ver Cuentas";
            btnVerCuentas.UseVisualStyleBackColor = true;
            btnVerCuentas.Click += btnVerCuentas_Click;
            // 
            // btnImportar
            // 
            btnImportar.Location = new Point(621, 119);
            btnImportar.Name = "btnImportar";
            btnImportar.Size = new Size(167, 47);
            btnImportar.TabIndex = 2;
            btnImportar.Text = "Importar Cuentas";
            btnImportar.UseVisualStyleBackColor = true;
            // 
            // btnExportar
            // 
            btnExportar.Location = new Point(621, 174);
            btnExportar.Name = "btnExportar";
            btnExportar.Size = new Size(167, 47);
            btnExportar.TabIndex = 3;
            btnExportar.Text = "Exportar Cuentas";
            btnExportar.UseVisualStyleBackColor = true;
            // 
            // btnResguardar
            // 
            btnResguardar.Location = new Point(621, 229);
            btnResguardar.Name = "btnResguardar";
            btnResguardar.Size = new Size(167, 47);
            btnResguardar.TabIndex = 4;
            btnResguardar.Text = "Resguardar ( Backup )";
            btnResguardar.UseVisualStyleBackColor = true;
            // 
            // btnRestaurar
            // 
            btnRestaurar.Location = new Point(621, 284);
            btnRestaurar.Name = "btnRestaurar";
            btnRestaurar.Size = new Size(167, 47);
            btnRestaurar.TabIndex = 5;
            btnRestaurar.Text = "Restaurar ( Restore )";
            btnRestaurar.UseVisualStyleBackColor = true;
            // 
            // btnSalir
            // 
            btnSalir.Location = new Point(621, 391);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(167, 47);
            btnSalir.TabIndex = 6;
            btnSalir.Text = "Salir";
            btnSalir.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnSalir);
            Controls.Add(btnRestaurar);
            Controls.Add(btnResguardar);
            Controls.Add(btnExportar);
            Controls.Add(btnImportar);
            Controls.Add(btnVerCuentas);
            Controls.Add(lBDetalles);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
        }

        #endregion

        private ListBox lBDetalles;
        private Button btnVerCuentas;
        private Button btnImportar;
        private Button btnExportar;
        private Button btnResguardar;
        private Button btnRestaurar;
        private Button btnSalir;
    }
}
