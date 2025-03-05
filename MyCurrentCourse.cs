using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EscuelaConMaui
{
    public static class MyCurrentCourse //Al igual que con los dato del usuario que inició sesión, me conviene almacenar las propiedades del curso al que entré. Pues, voy a necesitarlos para muchas operaciones y vistas: actualizar o eliminar el curso, agregar alumnos del curso, agregar tareas del curso, etc. 
    {
        public static int courseId {  get; set; }
        public static string courseName { get; set; }
        public static string courseSchool { get; set; }
        public static string courseSubject { get; set; }
    }
}
