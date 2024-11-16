using apalizT6A.Models;
using Newtonsoft.Json;
using System.Collections.ObjectModel;

namespace apalizT6A.Views;

public partial class vEstudiante : ContentPage
{
	private const string Url = "http://192.168.1.15/uisraelws/estudiante.php";
	private readonly HttpClient cliente = new HttpClient();
	private ObservableCollection<Estudiante> estud;


	public vEstudiante()
	{
		InitializeComponent();
		mostrar();
	}

	public async void mostrar()
	{
		var content = await cliente.GetStringAsync(Url);
		List<Estudiante> mostarEst = JsonConvert.DeserializeObject<List<Estudiante>>(content);
		estud = new ObservableCollection<Estudiante>(mostarEst);
        listaEstudiantes.ItemsSource = estud;

	}

	private void btnActualizar_Clicked(object sender, EventArgs e)
	{
		mostrar();
	}

	private void btnAgregar_Clicked(object sender, EventArgs e)
	{
		Navigation.PushAsync(new Views.vAgregar());
	}
	private void listaEstudiantes_ItemSelected(object sender, SelectedItemChangedEventArgs e)
	{
		var objestudiante =(Estudiante)e.SelectedItem;
		Navigation.PushAsync(new Views.vActualizar(objestudiante));
	}

}
