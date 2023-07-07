using Newtonsoft.Json;
using System;
using System.Net;
using System.Net.Http;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ConsumoApiJNS6
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ActualizarEstudiante : ContentPage
    {
        private readonly HttpClient client = new HttpClient();

        public ActualizarEstudiante(Estudiante est)
        {
            InitializeComponent();

            txtCodigo.Text = est.Codigo.ToString();
            txtNombre.Text = est.Nombre;
            txtApellido.Text = est.Apellido;
            txtEdad.Text = est.Edad.ToString();
        }

        private async void btnActualizar_Clicked(object sender, EventArgs e)
        {
            try
            {
                var parametros1 =
                    "codigo=" + txtCodigo.Text +
                    "&nombre=" + txtNombre.Text +
                    "&apellido=" + txtApellido.Text +
                    "&edad=" + txtEdad.Text;

                var parametros = new System.Collections.Specialized.NameValueCollection();
                parametros.Add("codigo", txtCodigo.Text);
                parametros.Add("nombre", txtNombre.Text);
                parametros.Add("apellido", txtApellido.Text);
                parametros.Add("edad", txtEdad.Text);

                // WebClient client = new WebClient();


                var a = client.PutAsync(Config.API_URL+"?" + parametros1, null);

                this.mainPage();

            }
            catch (Exception ex)
            {
                DependencyService.Get<IMensaje>().longAlert(ex.Message);

            }
        }

        private void btnRegresar_Clicked(object sender, EventArgs e)
        {
            this.mainPage();
        }



        public void mainPage()
        {
            Navigation.RemovePage(this);
            this.Navigation.PushAsync(new MainPage());

            string mensaje = "Registro actualizado correctamente";
            DependencyService.Get<IMensaje>().longAlert(mensaje);
                       
        }
    }
}
