using EscuelaConMaui.ViewModels.TestsViewModels;

namespace EscuelaConMaui.Views.TestsViews;

public partial class ShowAllTests : ContentPage
{
	public ShowAllTests()
	{
		BindingContext = App.Current.Services.GetRequiredService<ShowAllTestsViewModels>();
		InitializeComponent();
	}
}