namespace PryMercadoPagoQr
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.button1 = new System.Windows.Forms.Button();
            this.lblProceso = new System.Windows.Forms.Label();
            this.timerProceso = new System.Windows.Forms.Timer(this.components);
            this.txtMonto = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbCaja = new System.Windows.Forms.ComboBox();
            this.btnCancelarPago = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txtIdMercado = new System.Windows.Forms.TextBox();
            this.btnObtenerSucursal = new System.Windows.Forms.Button();
            this.lblSucursal = new System.Windows.Forms.Label();
            this.lblNombreSucursal = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtToken = new System.Windows.Forms.TextBox();
            this.btnMostrarId = new System.Windows.Forms.Button();
            this.btnMostrarToken = new System.Windows.Forms.Button();
            this.pbQr = new System.Windows.Forms.PictureBox();
            this.gpSucursal = new System.Windows.Forms.GroupBox();
            this.gpDatosSucursal = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbQr)).BeginInit();
            this.gpSucursal.SuspendLayout();
            this.gpDatosSucursal.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Enabled = false;
            this.button1.Location = new System.Drawing.Point(46, 133);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(138, 38);
            this.button1.TabIndex = 0;
            this.button1.Text = "SOLICITAR PAGO";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // lblProceso
            // 
            this.lblProceso.AutoSize = true;
            this.lblProceso.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProceso.Location = new System.Drawing.Point(255, 242);
            this.lblProceso.Name = "lblProceso";
            this.lblProceso.Size = new System.Drawing.Size(0, 29);
            this.lblProceso.TabIndex = 10;
            this.lblProceso.Visible = false;
            // 
            // timerProceso
            // 
            this.timerProceso.Interval = 1000;
            this.timerProceso.Tick += new System.EventHandler(this.timerProceso_Tick);
            // 
            // txtMonto
            // 
            this.txtMonto.Enabled = false;
            this.txtMonto.Location = new System.Drawing.Point(104, 83);
            this.txtMonto.Name = "txtMonto";
            this.txtMonto.Size = new System.Drawing.Size(100, 20);
            this.txtMonto.TabIndex = 11;
            this.txtMonto.TextChanged += new System.EventHandler(this.txtMonto_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(28, 85);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 18);
            this.label1.TabIndex = 12;
            this.label1.Text = "MONTO";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(28, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 18);
            this.label2.TabIndex = 13;
            this.label2.Text = "CAJA";
            // 
            // cmbCaja
            // 
            this.cmbCaja.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCaja.FormattingEnabled = true;
            this.cmbCaja.Location = new System.Drawing.Point(104, 36);
            this.cmbCaja.Name = "cmbCaja";
            this.cmbCaja.Size = new System.Drawing.Size(100, 21);
            this.cmbCaja.TabIndex = 14;
            this.cmbCaja.SelectedIndexChanged += new System.EventHandler(this.cmbCaja_SelectedIndexChanged);
            // 
            // btnCancelarPago
            // 
            this.btnCancelarPago.Location = new System.Drawing.Point(46, 177);
            this.btnCancelarPago.Name = "btnCancelarPago";
            this.btnCancelarPago.Size = new System.Drawing.Size(138, 38);
            this.btnCancelarPago.TabIndex = 15;
            this.btnCancelarPago.Text = "CANCELAR PAGO";
            this.btnCancelarPago.UseVisualStyleBackColor = true;
            this.btnCancelarPago.Click += new System.EventHandler(this.btnCancelarPago_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 40);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(93, 13);
            this.label3.TabIndex = 17;
            this.label3.Text = "ID DE MERCADO";
            // 
            // txtIdMercado
            // 
            this.txtIdMercado.Location = new System.Drawing.Point(126, 37);
            this.txtIdMercado.Name = "txtIdMercado";
            this.txtIdMercado.Size = new System.Drawing.Size(100, 20);
            this.txtIdMercado.TabIndex = 16;
            this.txtIdMercado.Text = "61269396";
            this.txtIdMercado.UseSystemPasswordChar = true;
            this.txtIdMercado.TextChanged += new System.EventHandler(this.txtIdMercado_TextChanged);
            // 
            // btnObtenerSucursal
            // 
            this.btnObtenerSucursal.Location = new System.Drawing.Point(88, 116);
            this.btnObtenerSucursal.Name = "btnObtenerSucursal";
            this.btnObtenerSucursal.Size = new System.Drawing.Size(138, 38);
            this.btnObtenerSucursal.TabIndex = 18;
            this.btnObtenerSucursal.Text = "OBTENER SUCURSAL";
            this.btnObtenerSucursal.UseVisualStyleBackColor = true;
            this.btnObtenerSucursal.Click += new System.EventHandler(this.btnObtenerSucursal_Click);
            // 
            // lblSucursal
            // 
            this.lblSucursal.AutoSize = true;
            this.lblSucursal.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSucursal.Location = new System.Drawing.Point(83, 19);
            this.lblSucursal.Name = "lblSucursal";
            this.lblSucursal.Size = new System.Drawing.Size(149, 29);
            this.lblSucursal.TabIndex = 19;
            this.lblSucursal.Text = "SUCURSAL";
            // 
            // lblNombreSucursal
            // 
            this.lblNombreSucursal.AutoSize = true;
            this.lblNombreSucursal.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombreSucursal.Location = new System.Drawing.Point(52, 242);
            this.lblNombreSucursal.Name = "lblNombreSucursal";
            this.lblNombreSucursal.Size = new System.Drawing.Size(149, 29);
            this.lblNombreSucursal.TabIndex = 20;
            this.lblNombreSucursal.Text = "SUCURSAL";
            this.lblNombreSucursal.Visible = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(91, 85);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(16, 18);
            this.label5.TabIndex = 21;
            this.label5.Text = "$";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(16, 75);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(89, 13);
            this.label6.TabIndex = 23;
            this.label6.Text = "ACCESS TOKEN";
            // 
            // txtToken
            // 
            this.txtToken.Location = new System.Drawing.Point(126, 72);
            this.txtToken.Name = "txtToken";
            this.txtToken.Size = new System.Drawing.Size(100, 20);
            this.txtToken.TabIndex = 22;
            this.txtToken.Text = "TEST-6238719312440729-041709-f80815ac54947f1f73b71509c595f8a1-1775451190";
            this.txtToken.UseSystemPasswordChar = true;
            this.txtToken.TextChanged += new System.EventHandler(this.txtToken_TextChanged);
            // 
            // btnMostrarId
            // 
            this.btnMostrarId.Location = new System.Drawing.Point(232, 40);
            this.btnMostrarId.Name = "btnMostrarId";
            this.btnMostrarId.Size = new System.Drawing.Size(70, 22);
            this.btnMostrarId.TabIndex = 24;
            this.btnMostrarId.Text = "MOSTRAR";
            this.btnMostrarId.UseVisualStyleBackColor = true;
            this.btnMostrarId.Click += new System.EventHandler(this.btnMostrarId_Click);
            // 
            // btnMostrarToken
            // 
            this.btnMostrarToken.Location = new System.Drawing.Point(232, 72);
            this.btnMostrarToken.Name = "btnMostrarToken";
            this.btnMostrarToken.Size = new System.Drawing.Size(70, 22);
            this.btnMostrarToken.TabIndex = 25;
            this.btnMostrarToken.Text = "MOSTRAR";
            this.btnMostrarToken.UseVisualStyleBackColor = true;
            this.btnMostrarToken.Click += new System.EventHandler(this.btnMostrarToken_Click);
            // 
            // pbQr
            // 
            this.pbQr.Location = new System.Drawing.Point(257, 281);
            this.pbQr.Name = "pbQr";
            this.pbQr.Size = new System.Drawing.Size(231, 255);
            this.pbQr.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbQr.TabIndex = 26;
            this.pbQr.TabStop = false;
            // 
            // gpSucursal
            // 
            this.gpSucursal.Controls.Add(this.button1);
            this.gpSucursal.Controls.Add(this.txtMonto);
            this.gpSucursal.Controls.Add(this.label1);
            this.gpSucursal.Controls.Add(this.label2);
            this.gpSucursal.Controls.Add(this.cmbCaja);
            this.gpSucursal.Controls.Add(this.label5);
            this.gpSucursal.Controls.Add(this.btnCancelarPago);
            this.gpSucursal.Location = new System.Drawing.Point(11, 281);
            this.gpSucursal.Name = "gpSucursal";
            this.gpSucursal.Size = new System.Drawing.Size(228, 255);
            this.gpSucursal.TabIndex = 27;
            this.gpSucursal.TabStop = false;
            this.gpSucursal.Text = "INGRESE CAJA Y MONTO";
            this.gpSucursal.Visible = false;
            // 
            // gpDatosSucursal
            // 
            this.gpDatosSucursal.Controls.Add(this.label3);
            this.gpDatosSucursal.Controls.Add(this.txtIdMercado);
            this.gpDatosSucursal.Controls.Add(this.btnObtenerSucursal);
            this.gpDatosSucursal.Controls.Add(this.txtToken);
            this.gpDatosSucursal.Controls.Add(this.btnMostrarToken);
            this.gpDatosSucursal.Controls.Add(this.label6);
            this.gpDatosSucursal.Controls.Add(this.btnMostrarId);
            this.gpDatosSucursal.Location = new System.Drawing.Point(12, 51);
            this.gpDatosSucursal.Name = "gpDatosSucursal";
            this.gpDatosSucursal.Size = new System.Drawing.Size(327, 166);
            this.gpDatosSucursal.TabIndex = 28;
            this.gpDatosSucursal.TabStop = false;
            this.gpDatosSucursal.Text = "INGRESE ID Y TOKEN";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(601, 550);
            this.Controls.Add(this.gpDatosSucursal);
            this.Controls.Add(this.lblNombreSucursal);
            this.Controls.Add(this.gpSucursal);
            this.Controls.Add(this.pbQr);
            this.Controls.Add(this.lblSucursal);
            this.Controls.Add(this.lblProceso);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbQr)).EndInit();
            this.gpSucursal.ResumeLayout(false);
            this.gpSucursal.PerformLayout();
            this.gpDatosSucursal.ResumeLayout(false);
            this.gpDatosSucursal.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label lblProceso;
        private System.Windows.Forms.Timer timerProceso;
        private System.Windows.Forms.TextBox txtMonto;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbCaja;
        private System.Windows.Forms.Button btnCancelarPago;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtIdMercado;
        private System.Windows.Forms.Button btnObtenerSucursal;
        private System.Windows.Forms.Label lblSucursal;
        private System.Windows.Forms.Label lblNombreSucursal;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtToken;
        private System.Windows.Forms.Button btnMostrarId;
        private System.Windows.Forms.Button btnMostrarToken;
        private System.Windows.Forms.PictureBox pbQr;
        private System.Windows.Forms.GroupBox gpSucursal;
        private System.Windows.Forms.GroupBox gpDatosSucursal;
    }
}

