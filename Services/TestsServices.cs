using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EscuelaConMaui.Models;

namespace EscuelaConMaui.Services
{
    public class TestsServices : ITests
    {
        private readonly SQLLiteHelper<TestsModels> db; //Propiedad, otorgada por el kit sqllite, que me permite conectarme a la base de datos. 

        public TestsServices()
            => db = new(); //Inicializo mi variable db que es de tipo SQLLiteHelper<TeacherModels>
        public Task<int> DeleteTest(TestsModels test)
            => Task.FromResult(db.Delete(test));

        public Task<List<TestsModels>> GetAll()
            => Task.FromResult(db.GetAllData());

        public Task<List<TestsModels>> GetAllByCourseId(int courseId)
            => Task.FromResult(db.GetAllData().Where(test => test.CourseId == courseId).ToList());


        public Task<TestsModels> GetById(int id)
            => Task.FromResult(db.Get(id));

        public Task<int> InsertTest(TestsModels test)
            => Task.FromResult(db.Add(test));

        public Task<int> UpdateTest(TestsModels test)
            => Task.FromResult(db.Update(test));

    }
}
