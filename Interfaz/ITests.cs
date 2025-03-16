using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EscuelaConMaui.Models;

namespace EscuelaConMaui.Interfaz
{
    public interface ITests
    {
        public Task<List<TestsModels>> GetAll(); 
        public Task<TestsModels> GetById(int id);
        public Task<List<TestsModels>> GetAllByCourseId(int courseId);
        public Task<int> InsertTest(TestsModels test);
        public Task<int> DeleteTest(TestsModels test);
        public Task<int> UpdateTest(TestsModels test);

       
    }
}
