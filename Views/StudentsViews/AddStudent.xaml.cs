using EscuelaConMaui.ViewModels.StudentsViewModels;

namespace EscuelaConMaui.Views.StudentsViews;
public partial class AddStudent : ContentPage
{

    public AddStudent()
	{
		InitializeComponent();
        BindingContext = App.Current.Services.GetRequiredService<AddStudentViewModels>(); //Es para acceder al ViewModel en tiempos de ejecución. Cuando en el DataType, en el archivo XAMl, aclaro que ls propiedades son de la clase AddStudentViewModel, es para que el software se de cuenta de eso en tipos de DESARROLLO; esto es en tiempos de EJECUCIÓN.
    }
}