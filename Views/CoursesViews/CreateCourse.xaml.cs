using EscuelaConMaui.ViewModels.CoursesViewModels;

namespace EscuelaConMaui.Views.CoursesViews;

public partial class CreateCourse : ContentPage
{
	public CreateCourse()
	{
		InitializeComponent();
        BindingContext = App.Current.Services.GetRequiredService<CreateCourseViewModels>();
    }
}