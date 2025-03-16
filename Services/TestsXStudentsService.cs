using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EscuelaConMaui.Models;

namespace EscuelaConMaui.Services
{
    public class TestsXStudentsService : IstudentXtest
    {
        private readonly SQLLiteHelper<TestsXStudentsModels> db; //Propiedad, otorgada por el kit sqllite, que me permite conectarme a la base de datos. 

        public TestsXStudentsService()
            => db = new(); //Inicializo mi variable db que es de tipo SQLLiteHelper<TeacherModels>
        public Task<int> DeleteTestXStudent(TestsXStudentsModels test)
            => Task.FromResult(db.Delete(test));

        public Task<List<TestsXStudentsModels>> GetAll()
            => Task.FromResult(db.GetAllData());

        public Task<TestsXStudentsModels> GetById(int id)
            => Task.FromResult(db.Get(id));

        public Task<int> InsertTestXStudent(TestsXStudentsModels test)
            => Task.FromResult(db.Add(test));

        public Task<int> UpdateTestXStudent(TestsXStudentsModels test)
            => Task.FromResult(db.Update(test));
        public Task<int> GetIdByStudentIdAndTestId(int studentId, int testId)
        {
            var record = db.GetAllData()
                .FirstOrDefault(t => t.StudentId == studentId && t.TestId == testId);

            return Task.FromResult(record != null ? record.Id : -1); // Retorna -1 si no se encuentra
        }
    }
}
