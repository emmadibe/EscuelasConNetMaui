using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EscuelaConMaui.Models;

namespace EscuelaConMaui.Services
{
    internal class CoursesServices : ICourses
    {
        private readonly SQLLiteHelper<CoursesModels> db; //Propiedad, otorgada por el kit sqllite, que me permite conectarme a la base de datos. 

        public CoursesServices()
            => db = new(); //Inicializo mi variable db que es de tipo SQLLiteHelper<CourseModels>
        public Task<int> DeleteCourse(CoursesModels course)
            => Task.FromResult(db.Delete(course));

        public Task<List<CoursesModels>> GetAll()
            => Task.FromResult(db.GetAllData());

        public Task<CoursesModels> GetById(int id)
            => Task.FromResult(db.Get(id));

        public Task<int> InsertCourse(CoursesModels course)
            => Task.FromResult(db.Add(course));

        public Task<int> UpdateCourse(CoursesModels course)
            => Task.FromResult(db.Update(course));

        public Task<List<CoursesModels>> GetAllCoursesByMyTeacher(int myTeacherId) //Esta consulta no la twngo en SQLLiteHelper. Es que es propia para Courses. Pues, debo, traerme todos los registros de la tabla courses que pertenezcan a mi teacher.
            => Task.FromResult(db._connection.Table<CoursesModels>().Where(item => item.TeacherId == myTeacherId).ToList());
    }
}
