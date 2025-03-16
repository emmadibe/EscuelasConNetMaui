using EscuelaConMaui.ViewModels.TestsViewModels;

namespace EscuelaConMaui.Views.TestsViews;

public partial class AddTest : ContentPage
{
	public AddTest()
	{
		BindingContext = App.Current.Services.GetRequiredService<AddTestViewModels>(); //Es para acceder al ViewModel en tiempos de ejecución. Cuando en el DataType, en el archivo XAMl, aclaro que las propiedades son de la clase AddTestViewModel, es para que el software se de cuenta de eso en tipos de DESARROLLO; esto es en tiempos de EJECUCIÓN.
        InitializeComponent();
	}
}