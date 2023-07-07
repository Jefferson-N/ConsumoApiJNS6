using Newtonsoft.Json;
using System;
using System.Net;
using System.Runtime.InteropServices.ComTypes;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ConsumoApiJNS6
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class InsertarEstudiante : ContentPage
    {
        public InsertarEstudiante()
        {
            InitializeComponent();
        }

        private async void btninsertar_Clicked(object sender, EventArgs e)
        {
            try
            {
                WebClient client = new WebClient();
                var parametros = new System.Collections.Specialized.NameValueCollection();
                parametros.Add("codigo", txtCodigo.Text);
                parametros.Add("nombre", txtNombre.Text);
                parametros.Add("apellido", txtApellido.Text);
                parametros.Add("edad", txtEdad.Text);



                client.UploadValues(Config.API_URL, "POST", parametros);

               
                this.mainPage();

            }
            catch (Exception ex) {
                DependencyService.Get<IMensaje>().longAlert(ex.Message);

            }
        }

        public void mainPage()
        {
            Navigation.RemovePage(this);
            this.Navigation.PushAsync(new MainPage());

            string mensaje = "Registro insertado correctamente";
            DependencyService.Get<IMensaje>().longAlert(mensaje);
                       
        }
    }
}
