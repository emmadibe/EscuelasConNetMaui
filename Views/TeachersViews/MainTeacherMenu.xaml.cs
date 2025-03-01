using System.Security.Cryptography.X509Certificates;

namespace EscuelaConMaui.Views.TeachersViews;

[QueryProperty(nameof(TeacherId), "Id")] //Recibo la variable "Id". Esa variable es enviada desde Login. Su valor lo asigno a la propiedad TeacherId.
public partial class MainTeacherMenu : ContentPage
{
    public int TeacherId
    {
        set
        {
            // Pasas el valor directamente al crear el ViewModel para que se lo asigne a la popiedad TeacherId.
            BindingContext = new MainTeacherMenuViewModel(value);
        }
    }
    public MainTeacherMenu()
	{
        InitializeComponent();
        BindingContext = App.Current.Services.GetRequiredService<MainTeacherMenuViewModel>(); //Es para acceder al ViewModel en tiempos de ejecución. Cuando en el DataType, en el archivo XAMl, aclaro que ls propiedades son de la clase MainTeacherMenuViewModel, es para que el software se de cuenta de eso en tipos de DESARROLLO; esto es en tiempos de EJECUCIÓN.
	}
}