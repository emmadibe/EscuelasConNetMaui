namespace EscuelaConMaui.Views;

public partial class SignUpForm : ContentPage
{
	public SignUpForm()
	{
        BindingContext = App.Current.Services.GetRequiredService<SignUpFormViewModel>();//Es para acceder al ViewModel en tiempos de ejecución. Cuando en el DataType, en el archivo XAMl, aclaro que ls propiedades son de la clase SignUpViewModel, es para que el software se de cuenta de eso en tipos de DESARROLLO; esto es en tiempos de EJECUCIÓN.
        InitializeComponent();
	}
}