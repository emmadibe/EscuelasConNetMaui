using EscuelaConMaui.ViewModels.TestsViewModels;

namespace EscuelaConMaui.Views.TestsViews;
[QueryProperty(nameof(TestId), "TestId")] //Recibo la variable "TestId". Esa variable es enviada desde ShowAllTest. Su valor lo asigno a la propiedad TestId.
public partial class ShowTest : ContentPage
{
    public int TestId
    {
        set
        {
            // Pasas el valor directamente al crear el ViewModel para que se lo asigne a la popiedad courseId.
            BindingContext = new ShowTestViewModel(value);
        }
    }
    public ShowTest()
	{
        BindingContext = App.Current.Services.GetRequiredService<ShowTestViewModel>();
        InitializeComponent();
		
		
	}
}