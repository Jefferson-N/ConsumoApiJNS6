using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace ConsumoApiJNS6
{
    public partial class MainPage : ContentPage
    {
        private readonly HttpClient client = new HttpClient();
        private ObservableCollection<Estudiante> _post;
        public MainPage()
        {
            InitializeComponent();
            this.mostrar();

        }

        public async void mostrar()
        {
            var contenido = await client.GetStringAsync(Config.API_URL);

            List<Estudiante> postd = JsonConvert.DeserializeObject<List<Estudiante>>(contenido);
            _post = new ObservableCollection<Estudiante>(postd);

            listaestudiantes.ItemsSource = _post;
        }

        private  void btnmostrar_Clicked(object sender, EventArgs e)
        {
             this.mostrar();

        }

        private async void btnInsertar_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new InsertarEstudiante());
        }


        private async void btnEliminar_Clicked(object sender, EventArgs e)
        { 
            if(!await DisplayAlert("Confirmaciòn", "Desea eliminar Registro","Si","No"))
            {
                return;
            }

            
            try
            {
                
                var item = (Estudiante)(sender as Button).CommandParameter;
                var parametros="codigo=" +item.Codigo;

                await client.DeleteAsync(Config.API_URL +"?"+parametros);

                this.mostrar();

                string mensaje = "Registro eliminado correctamente";
                DependencyService.Get<IMensaje>().longAlert(mensaje);

            }
            catch (Exception ex)
            {
                DependencyService.Get<IMensaje>().longAlert(ex.Message);

            }
        }

        private async void listaestudiantes_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
           var objectEstudiante = (Estudiante)e.SelectedItem;
           await Navigation.PushAsync(new ActualizarEstudiante(objectEstudiante));
        }
    }
}
