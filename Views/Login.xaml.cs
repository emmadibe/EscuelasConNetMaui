namespace EscuelaConMaui.Views;

public partial class Login : ContentPage
{
	public Login()
	{
		BindingContext = App.Current.Services.GetRequiredService<LoginViewModel>(); //Es para acceder al ViewModel en tiempos de ejecución. Cuando en el DataType, en el archivo XAMl, aclaro que ls propiedades son de la clase LoginViewModel, es para que el software se de cuenta de eso en tipos de DESARROLLO; esto es en tiempos de EJECUCIÓN.
		InitializeComponent();
	}
}