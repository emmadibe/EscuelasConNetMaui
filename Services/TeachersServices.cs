using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EscuelaConMaui.Interfaz;
using EscuelaConMaui.Models;

namespace EscuelaConMaui.Services
{
    internal class TeachersServices : ITeachers
    {
        private readonly SQLLiteHelper<TeachersModels> db; //Propiedad, otorgada por el kit sqllite, que me permite conectarme a la base de datos. 

        public TeachersServices()
            => db = new(); //Inicializo mi variable db que es de tipo SQLLiteHelper<TeacherModels>
        public Task<int> DeleteTeacher(TeachersModels teacher)
            => Task.FromResult(db.Delete(teacher)); 
         
        public Task<List<TeachersModels>> GetAll()
            => Task.FromResult(db.GetAllData());

        public Task<TeachersModels> GetById(int id)
            => Task.FromResult(db.Get(id));

        public Task<int> InsertTeacher(TeachersModels teacher)
            => Task.FromResult(db.Add(teacher));

        public Task<int> UpdateTeacher(TeachersModels teacher)
            => Task.FromResult(db.Update(teacher));
    }
}
