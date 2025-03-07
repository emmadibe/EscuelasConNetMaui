using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EscuelaConMaui.Models;

namespace EscuelaConMaui.Services
{
    class StudentsService : IStudents
    {
        private readonly SQLLiteHelper<StudentsModels> db; //Propiedad, otorgada por el kit sqllite, que me permite conectarme a la base de datos. 
        public StudentsService()
           => db = new(); //Inicializo mi variable db que es de tipo SQLLiteHelper<TeacherModels>
        public Task<int> DeleteStudent(StudentsModels student)
            => Task.FromResult(db.Delete(student));

        public Task<List<StudentsModels>> GetAll()
            => Task.FromResult(db.GetAllData());

        public Task<List<StudentsModels>> GetAllByCourseId(int courseId)
            => Task.FromResult(db.GetAllData().Where(student => student.CourseId == courseId).ToList());

        public Task<StudentsModels> GetById(int id)
            => Task.FromResult(db.Get(id));

        public Task<int> InsertStudent(StudentsModels student)
            => Task.FromResult(db.Add(student));

        public Task<int> UpdateStudent(StudentsModels student)
            => Task.FromResult(db.Update(student));
    }
}
