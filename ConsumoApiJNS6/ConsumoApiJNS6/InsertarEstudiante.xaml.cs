using Newtonsoft.Json;
using System;
using System.Net;
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

                await DisplayAlert("alerta", "Registro insertado correctamente", "ok");
                this.mainPage();

            }
            catch (Exception ex) {
                await DisplayAlert("Error", ex.Message , "ok");
            }
        }

        public void mainPage()
        {
            Navigation.RemovePage(this);
            this.Navigation.PushAsync(new MainPage());
        }
    }
}
