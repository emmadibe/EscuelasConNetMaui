using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EscuelaConMaui.Models;

namespace EscuelaConMaui.Interfaz
{
    public interface ICourses //Defino los métodos del CRUD
    {
        public Task<List<CoursesModels>> GetAll(); //Me traigo una lista en donde cada item de la Lista es una instancia de CoursesModels. Con este método me traigo todos los cursos, todos los registros de mi tabla courses de mi base de datos. 
        public Task<CoursesModels> GetById(int id); //Me traigo un solo course, el cual lo encuentro en mi bdd por el id. 
        public Task<int> InsertCourse(CoursesModels courses);
        public Task<int> DeleteCourse(CoursesModels courses);
        public Task<int> UpdateCourse(CoursesModels courses);
        public Task<List<CoursesModels>> GetAllCoursesByMyTeacher(int myTeacherId);

    }
}
