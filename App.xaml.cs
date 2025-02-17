
using EscuelaConMaui.Interfaz.InterrfazLogIn;
using EscuelaConMaui.Services.ServicesLogIn;
using EscuelaConMaui.ViewModels;

namespace EscuelaConMaui
{
    public partial class App : Application
    {
        public new static App Current => Application.Current as App ?? throw new InvalidOperationException("Application.Current is not an instance of App or is null");
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
            services.AddSingleton<GeneralsIFunctions, GeneralsFunctions>(); //Quiero acceder a las funciones definidas en la interfaz GeneralIFunctions, con las implementaciones que están en la clase GeneralFunctions. 

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
