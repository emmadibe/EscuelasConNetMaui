using EscuelaConMaui.Interfaz.InterrfazLogIn;
using EscuelaConMaui.Services.ServicesLogIn;
using EscuelaConMaui.ViewModels;

namespace EscuelaConMaui
{
    public partial class App : Application
    {
        public new static App Current => (App)Application.Current;
        public IServiceProvider Services { get; set; }
        public App()
        {
            var services = new ServiceCollection();
            Services = ConfigureServices(services);
            InitializeComponent();

            MainPage = new AppShell();
        }
        private static IServiceProvider ConfigureServices(ServiceCollection services)
        {
            //Services:
            services.AddSingleton<LoginIFunctions, LoginFunctions>();//Quiero acceder a la función de la interfaz LoginIFunctions con la implementación de LoginFunctions. 

            //ViewModels:
            services.AddTransient<LoginViewModel>();

            //Views:
            services.AddSingleton<Login>();

            return services.BuildServiceProvider();
        }
    }
}
