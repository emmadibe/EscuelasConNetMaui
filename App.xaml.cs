using EscuelaConMaui.Interfaz.InterfazSignUp;
using EscuelaConMaui.Interfaz.InterrfazLogIn;
using EscuelaConMaui.Services.ServicesLogIn;
using EscuelaConMaui.Services.SignUpServices;
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
            services.AddSingleton<SignUpIFunctions, SignUpFunctions>();//Quiero acceder a las funciones de la interfaz SignUpIFunctions con las implementaciones que están en la clase SignUpFunctions. 

            //ViewModels:
            services.AddTransient<LoginViewModel>();
            services.AddTransient<SignUpFormViewModel>();
            //Views:
            services.AddSingleton<Login>();
            services.AddSingleton<SignUpForm>();

            return services.BuildServiceProvider();
        }
    }
}
