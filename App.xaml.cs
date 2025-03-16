
using EscuelaConMaui.Interfaz.InterrfazLogIn;
using EscuelaConMaui.Models;
using EscuelaConMaui.Services.DataBase;
using EscuelaConMaui.Services.ServicesLogIn;
using EscuelaConMaui.ViewModels;
using EscuelaConMaui.ViewModels.CoursesViewModels;
using EscuelaConMaui.ViewModels.StudentsViewModels;
using EscuelaConMaui.ViewModels.TestsViewModels;
using EscuelaConMaui.Views.CoursesViews;
using EscuelaConMaui.Views.StudentsViews;
using EscuelaConMaui.Views.TestsViews;

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
            services.AddSingleton<ITeachers, TeachersServices>(); //Inyecto los métodos de la interfaz ITeachers cuya implementación está en la clase TeachersService. 
            services.AddSingleton<LoginIFunctions, LoginFunctions>();//Quiero acceder a la función de la interfaz LoginIFunctions con la implementación de LoginFunctions.  
            services.AddSingleton<GeneralsIFunctions, GeneralsFunctions>(); //Quiero acceder a las funciones definidas en la interfaz GeneralIFunctions, con las implementaciones que están en la clase GeneralFunctions. 
            services.AddSingleton<IDataBaseInitializer, DataBaseInitializer>(); //Quiero acceder a los métodos definidos en la interfaz IDataBaseInitializer con implementación de la clase DataBaseInitializer.
            services.AddSingleton<SQLLiteBase>();  
            services.AddSingleton<ICourses, CoursesServices>();
            services.AddSingleton<IStudents, StudentsService>();
            services.AddSingleton<ITests, TestsServices>();
            services.AddSingleton<IstudentXtest, TestsXStudentsService>();
            services.AddSingleton<ITraerTodos, TraerTodoService>();
            services.AddSingleton<ITraerTodoDefinitivo, TraerTodoDefinitivoService>();
             

            //ViewModels:
            services.AddTransient<LoginViewModel>();
            services.AddTransient<SignUpFormViewModel>();
            services.AddTransient<MainTeacherMenuViewModel>();
            services.AddTransient<CreateCourseViewModels>();
            services.AddTransient<ShowCourseViewModels>();
            services.AddTransient<AddStudentViewModels>();
            services.AddTransient<AddTestViewModels>();
            services.AddTransient<ShowAllTestsViewModels>();
            services.AddTransient<ShowTestViewModel>();

            //Views:
            services.AddSingleton<Login>();
            services.AddSingleton<SignUpForm>();
            services.AddSingleton<CreateCourse>();
            services.AddSingleton<ShowCourse>();
            services.AddSingleton<AddStudent>();
            services.AddSingleton<AddTest>();
            services.AddSingleton<ShowAllTests>();
            services.AddSingleton<ShowTest>();

            return services.BuildServiceProvider();
        }
    }
}
