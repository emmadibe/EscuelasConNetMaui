using EscuelaConMaui.Views.CoursesViews;
using EscuelaConMaui.Views.StudentsViews;
using EscuelaConMaui.Views.TeachersViews;
using EscuelaConMaui.Views.TestsViews;

namespace EscuelaConMaui
{
    public partial class AppShell : Shell //AppShell es la clase encargada de definir la estructura de navegación de mi aplicación, tal como los menúes, los tabs o rutas de navegación. 
    {
        public AppShell() //El contructor de la clase AppShel
        {
            InitializeComponent(); //Carga la vista y sus layouts y componentes. 
            //La clase Routing me la proporciona el framework NET MAUI. 
            Routing.RegisterRoute(nameof(Login), typeof(Login)); //Hago esto para poder acceder a la vista Login desde cualquier parte del programa y en cualquier momento. Accedo a la ruta Login bajo el nombre de login. Por convención, nombre a la ruta con el nombre de la vista. Así, podré acceder desde cualquier parte de mi programa a la vista cuya ruta se llama Login. O sea, ahora voy a poder navegar a la vista Login desde cualquier parte de mi aplicación, ya sea desde un botón, de un evento u otra forma de navegación. 
            Routing.RegisterRoute(nameof(SignUpForm), typeof(SignUpForm));
            Routing.RegisterRoute(nameof(MainTeacherMenu), typeof(MainTeacherMenu));        
            Routing.RegisterRoute(nameof(CreateCourse), typeof(CreateCourse));
            Routing.RegisterRoute(nameof(ShowCourse), typeof(ShowCourse));
            Routing.RegisterRoute(nameof(AddStudent), typeof(AddStudent));
            Routing.RegisterRoute(nameof(AddTest), typeof(AddTest));
            Routing.RegisterRoute(nameof(ShowAllTests), typeof(ShowAllTests));  
            Routing.RegisterRoute(nameof(ShowTest), typeof(ShowTest));
        }
    }
}
 