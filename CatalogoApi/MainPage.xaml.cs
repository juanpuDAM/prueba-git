using CatalogoApi.Models;
using CatalogoApi.Services;
namespace CatalogoApi
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void OnCargarClicked(object? sender, EventArgs e)
        {
            BtnCargar.IsEnabled = false;
            Cargando.IsRunning = true;
            Cargando.IsVisible = true;

            try
            {
                List<Producto> productos = await ProductoService.ObtenerProductosAsync();
                ListaProductos.ItemsSource = productos;
            }
            catch (HttpRequestException ex)
            {
                string motivo = ex.StatusCode is null ? "no haber conecction o el server no ruleison" : $"fallo del server with code {(int)ex.StatusCode}";
                await DisplayAlertAsync("error de los erroes de res", motivo, "acepteison");
            }
            catch (TaskCanceledException)
            {
                await DisplayAlertAsync("tiempo agotado", "el servidor tarda demaiado en responder", "acpeteison");
            }
            finally
            {
                Cargando.IsRunning = false;
                Cargando.IsVisible = false;
                Cargando.IsEnabled = true;
            }
        }
    }
}
