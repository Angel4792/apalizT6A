using System.Net;

namespace apalizT6A.Views;

public partial class vAgregar : ContentPage
{
	public vAgregar()
	{
		InitializeComponent();
	}

    private void btnGuardar_Clicked(object sender, EventArgs e)
    {
		try
		{
			WebClient cliente = new WebClient();
			var parametros = new System.Collections.Specialized.NameValueCollection();
			parametros.Add("nombre", TxtNombre.Text);
			parametros.Add("apellido", TxtApellido.Text);
			parametros.Add("edad", TxtEdad.Text);
			cliente.UploadValues("http://192.168.1.15/uisraelws/estudiante.php", "POST", parametros);
			Navigation.PushAsync(new vEstudiante());

		}
		catch (Exception)
		{

			DisplayAlert("","","");
		}

    }
}