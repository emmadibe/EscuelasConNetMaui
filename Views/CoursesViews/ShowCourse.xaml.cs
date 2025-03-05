using EscuelaConMaui.ViewModels.CoursesViewModels;

namespace EscuelaConMaui.Views.CoursesViews;

[QueryProperty(nameof(CourseId), "courseId")] //Recibo la variable "courseId". Esa variable es enviada desde MainMenuTeacherViewModels. Su valor lo asigno a la propiedad CourseId.
public partial class ShowCourse : ContentPage
{
    public int CourseId
    {
        set
        {
            // Pasas el valor directamente al crear el ViewModel para que se lo asigne a la popiedad courseId.
            BindingContext = new ShowCourseViewModels(value);
        }
    }
    public ShowCourse()
	{
		InitializeComponent();
        BindingContext = App.Current.Services.GetRequiredService<ShowCourseViewModels>(); //Es para acceder al ViewModel en tiempos de ejecución. Cuando en el DataType, en el archivo XAMl, aclaro que ls propiedades son de la clase ShowCourseViewModel, es para que el software se de cuenta de eso en tipos de DESARROLLO; esto es en tiempos de EJECUCIÓN.
    }
}