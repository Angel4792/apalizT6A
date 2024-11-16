using apalizT6A.Models;
using System.Net;

namespace apalizT6A.Views;

public partial class vActualizar : ContentPage
{
    Estudiante dato;
	public vActualizar(Estudiante datos)
	{
		InitializeComponent();
        dato = datos;
        initializer();
    }
    private void initializer()
    {
        TxtNombre.Text = dato.nombre;
        TxtApellido.Text = dato.apellido;
        TxtEdad.Text = dato.edad.ToString();
        Txtcodigo.Text = dato.codigo.ToString();
    }

    private void btnEliminar_Clicked(object sender, EventArgs e)
    {
        try
        {
            WebClient cliente = new WebClient();
            var parametros = new System.Collections.Specialized.NameValueCollection();
            cliente.UploadValues("http://192.168.1.15/uisraelws/estudiante.php?codigo=" + Txtcodigo.Text, "DELETE", parametros);
            Navigation.PushAsync(new Views.vEstudiante());

            
        }
        catch (Exception)
        {

            DisplayAlert("Alert", "error", "Cerrar");
            
        }

    }

    private void btnActualizar_Clicked(object sender, EventArgs e)
    {
        try
        {
            WebClient cliente = new WebClient();
            var parametros = new System.Collections.Specialized.NameValueCollection();
            cliente.UploadValues("http://192.168.1.15/uisraelws/estudiante.php?nombre=" + TxtNombre.Text + "&apellido=" + TxtApellido.Text + "&edad=" + TxtEdad.Text + "&codigo=" + Txtcodigo.Text, "PUT", parametros);
            Navigation.PushAsync(new Views.vEstudiante());
        }
        catch (Exception)
        {

            DisplayAlert("Alert", "error", "Cerrar");
        }
       
    }
}