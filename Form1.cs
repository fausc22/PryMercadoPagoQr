using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using MercadoPago.Client.Payment;
using MercadoPago.Config;
using MercadoPago.Resource.Payment;
using MercadoPago.Resource.User;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using static PryMercadoPagoQr.Clase;

namespace PryMercadoPagoQr
{
    public partial class Form1 : Form
    {
        private const string baseUrl = "https://api.mercadopago.com/instore/qr/seller/collectors/1772005205/pos/SUC002CAJA001/orders?access_token=TEST-7037479340314345-041615-34c3f862f610d2b370e1b8f704d85249-1772005205"; // URL de la solicitud GET
        bool pagoCompletado = false; // Variable para controlar si el pago ha sido completado
        private int dotCount = 0;
        string external_id_form = string.Empty;
        string idMercado_form = string.Empty;
        string externalStoreId_form = string.Empty;
        string externalIdCaja_form = string.Empty;
        int userIdCaja_form = 0;
        Clase cls = new Clase();
        public Form1()
        {
            InitializeComponent();
        }

        

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        

        private async void button1_Click(object sender, EventArgs e)
        {
            bool estadoPago = false;
            ComboBoxItemData selectedItem = (ComboBoxItemData)cmbCaja.SelectedItem;
            string externalStoreId = selectedItem.external_store_id;
            int userId = selectedItem.user_id;
            string externalId = selectedItem.external_id;
            string token = txtToken.Text;
            decimal Monto = Decimal.Parse(txtMonto.Text);
            cmbCaja.Enabled = false;
            txtMonto.Enabled = false;
            bool CobroEnviado = await Clase.EnviarCobro(userId, externalStoreId, externalId, token, Monto);

            
            if(CobroEnviado == true)
            {
                
                timerProceso.Enabled = true;
                lblProceso.Visible = true;
                button1.Enabled = false;
                btnCancelarPago.Enabled = true;
                //lblProceso.Text == "Pago en proceso...";
                bool SePago = await cls.VerificarEstadoPagoAsync(userId, externalStoreId, token);

                if (SePago == true)
                {
                    if (lblProceso.Text != "PAGO CANCELADO")
                    {
                        timerProceso.Enabled = false;
                        lblProceso.ForeColor = Color.Green;
                        lblProceso.Text = "Pago completado con éxito";
                    }
                    
                    
                    btnCancelarPago.Enabled = false;
                    txtMonto.Enabled = true;
                    txtMonto.Text = "";
                    cmbCaja.SelectedIndex = -1;
                    cmbCaja.Enabled = true;
                    
                }
                else
                {
                    return;
                }



            }
            else
            {
                return;
            }

            




        }

        

        private void timerProceso_Tick(object sender, EventArgs e)
        {
            // Añade un punto al texto del label
            dotCount = (dotCount + 1) % 4;
            string dots = new string('.', dotCount);

            // Actualiza el texto del label
            lblProceso.Text = "Pago en proceso" + dots;
        }

        private void txtIdMercado_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtToken_TextChanged(object sender, EventArgs e)
        {

        }

        private async void btnObtenerSucursal_Click(object sender, EventArgs e)
        {
            string token = txtToken.Text;
            string idMercado = txtIdMercado.Text;
            string nameCaja = string.Empty;
            string Externalid = string.Empty;
            string externaStorelId = string.Empty;
            int userId = 0;
            string qrImageUrl = string.Empty; // Variable para el campo Image del objeto qr

            //await Clase.ObtenerInfoCajas(token);
            //await Clase.ObtenerSucursal(token, idMercado);
            StoreInfo storeInfo = await Clase.ObtenerSucursal(token, idMercado);
            List<Result> cajaInfoList = await Clase.ObtenerInfoCajas(token);




            if (storeInfo != null)
            {
                string name = storeInfo.Name;
                string id = storeInfo.Id;
                string externalId = storeInfo.external_id;

                // Usa los datos como desees, por ejemplo, asignándolos a controles en tu formulario
                
                lblNombreSucursal.Text = name;
                lblNombreSucursal.Visible = true;
                external_id_form = externalId;
                idMercado_form = externalId;
                
            }
            else
            {
                MessageBox.Show("Failed to get store data.");
            }

            if (cajaInfoList != null && cajaInfoList.Count > 0)
            {
                gpSucursal.Visible = true;
                // Si cajaInfoList es una lista de objetos Result, necesitas iterar sobre la lista
                foreach (var cajaInfo in cajaInfoList)
                {
                    nameCaja = cajaInfo.name;
                    Externalid = cajaInfo.external_id;
                    externaStorelId = cajaInfo.external_store_id;
                    userId = cajaInfo.user_id;



                    ComboBoxItemData item = new ComboBoxItemData(nameCaja, Externalid, externaStorelId, userId);
                    cmbCaja.Items.Add(item);

                    // Acceder al objeto qr dentro de cajaInfo
                    qrImageUrl = cajaInfo.qr.image; // Accedes al campo Image del objeto qr

                }
                Clase.ImagenQr(qrImageUrl, pbQr);
                //MessageBox.Show(nameCaja + Externalid + externaStorelId + qrImageUrl);
            }
            else
            {
                MessageBox.Show("pifio chat gpt");
            }



        }

        private void cmbCaja_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbCaja.SelectedItem != null)
            {
                ComboBoxItemData selectedItem = (ComboBoxItemData)cmbCaja.SelectedItem;
                externalStoreId_form = selectedItem.external_store_id;
                externalIdCaja_form = selectedItem.external_id;
                userIdCaja_form = selectedItem.user_id;
                txtMonto.Enabled = true;
                lblProceso.Visible = false;
                lblProceso.ForeColor = Color.Blue;

                
            }
            
        }

        private async void btnCancelarPago_Click(object sender, EventArgs e)
        {
            ComboBoxItemData selectedItem = (ComboBoxItemData)cmbCaja.SelectedItem;
            string externalStoreId = selectedItem.external_store_id;
            int userId = selectedItem.user_id;
            string externalId = selectedItem.external_id;
            string token = txtToken.Text;
            decimal Monto = Decimal.Parse(txtMonto.Text);
            

            bool PagoCancelado = await Clase.CancelarCobro(token, userId, externalStoreId);

            if (PagoCancelado == true)
            {
                timerProceso.Enabled = false;

                lblProceso.ForeColor = Color.Red;
                lblProceso.Text = "PAGO CANCELADO";
                btnCancelarPago.Enabled = false;
                cmbCaja.SelectedIndex = -1;
                txtMonto.Text = "";
                
            }
            else
            {
                return;
            }
        }

        private void btnMostrarId_Click(object sender, EventArgs e)
        {
            txtIdMercado.UseSystemPasswordChar = !txtIdMercado.UseSystemPasswordChar;
        }

        private void btnMostrarToken_Click(object sender, EventArgs e)
        {
            txtToken.UseSystemPasswordChar= !txtToken.UseSystemPasswordChar;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            decimal Monto = 22;
            string body = @"
                {
                  ""description"": ""Item de prueba"",
                  ""external_reference"": ""1"",
                  ""items"": [
                    {
                      ""sku_number"": ""1"",
                      ""category"": ""1"",
                      ""title"": ""Item de prueba"",
                      ""description"": ""Este es un Item de prueba"",
                      ""unit_price"": " + Monto + @",
                      ""quantity"": 1,
                      ""unit_measure"": ""unit"",
                      ""total_amount"": " + Monto + @"
                    }
                  ],
                  ""title"": ""Item de prueba"",
                  ""total_amount"": " + Monto + @"
                }";

            MessageBox.Show(body);
        }

        private void txtMonto_TextChanged(object sender, EventArgs e)
        {
            if (cmbCaja.SelectedIndex != -1 && txtMonto.Text != null)
            {
                button1.Enabled = true;
                
            }
        }

        public async Task VerificarEstadoPagoAsync(bool EstadoPago)
        {

            EstadoPago = false;
            // Realizar solicitudes GET periódicas
            while (!EstadoPago)
            {
                try
                {
                    using (var client = new HttpClient())
                    {
                        var response = await client.GetAsync(baseUrl);
                        if (response.IsSuccessStatusCode)
                        {
                            //// Pago sigue en proceso

                            EstadoPago = false;
                        }
                        else
                        {
                            // Pago completado
                            EstadoPago = true;


                            break; // Salir del bucle
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Manejar errores
                    MessageBox.Show($"Error al verificar el estado del pago: {ex.Message}");
                }

                // Esperar un tiempo antes de la siguiente verificación
                await Task.Delay(TimeSpan.FromSeconds(3)); // Esperar 10 segundos entre solicitudes

            }




        }
    }
}
