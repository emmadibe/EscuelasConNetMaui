using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EscuelaConMaui.Models;

namespace EscuelaConMaui.Interfaz
{
    public interface IStudents 
    {
        public Task<List<StudentsModels>> GetAll(); //Me traigo una lista en donde cada item de la Lista es una instancia de StudentssModels. Con este método me traigo todos los estudiantes, todos los registros de mi tabla students de mi base de datos. 
        public Task<List<StudentsModels>> GetAllByCourseId(int courseId);
        public Task<StudentsModels> GetById(int id); //Me traigo un solo students, el cual lo encuentro en mi bdd por el id. 
        public Task<int> InsertStudent(StudentsModels student);
        public Task<int> DeleteStudent(StudentsModels student);
        public Task<int> UpdateStudent(StudentsModels student);
    }
}
