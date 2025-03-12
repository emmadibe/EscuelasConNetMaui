using EscuelaConMaui.ViewModels.TestsViewModels;

namespace EscuelaConMaui.Views.TestsViews;

public partial class ShowTest : ContentPage
{
	public ShowTest()
	{
		BindingContext = App.Current.Services.GetRequiredService<ShowTestViewModel>();
		InitializeComponent();
	}
}