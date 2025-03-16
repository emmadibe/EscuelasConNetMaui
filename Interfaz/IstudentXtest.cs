using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EscuelaConMaui.Models;

namespace EscuelaConMaui.Interfaz
{
    public interface IstudentXtest
    {
        public Task<List<TestsXStudentsModels>> GetAll();
        public Task<TestsXStudentsModels> GetById(int id);
        public Task<int> InsertTestXStudent(TestsXStudentsModels testXstudents);
        public Task<int> DeleteTestXStudent(TestsXStudentsModels testXstudents);
        public Task<int> UpdateTestXStudent(TestsXStudentsModels testXstudents);
        public Task<int> GetIdByStudentIdAndTestId(int studentId, int testId);
    }
}
