using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EscuelaConMaui.Models;

namespace EscuelaConMaui.Services
{
    public partial class TraerTodoService : ITraerTodos
    {

        private readonly SQLLiteHelper<TraerTodoModels> db; //Propiedad, otorgada por el kit sqllite, que me permite conectarme a la base de datos. 

        public TraerTodoService()
            => db = new(); //Inicializo mi variable db que es de tipo SQLLiteHelper<TeacherModels>
        public Task<List<TraerTodoModels>> GetStudentExamsByCourse(int courseId)
        {
            string sql = $@"
        SELECT 
            s.Name || ' ' || s.LastName AS NameAndLastName,
            te.TestNoumber || ' ' || te.Name AS NoumberAndNameTest,
            txs.Nota AS Nota,
            te.TestNoumber AS TestNoumber
        FROM 
            students s
        INNER JOIN 
            courses c ON c.Id = s.CourseId
        INNER JOIN 
            testsXstudents txs ON s.Id = txs.StudentId
        INNER JOIN 
            tests te ON txs.TestId = te.Id
        WHERE 
            c.Id = {courseId}
        AND 
            txs.Nota = (
                SELECT MAX(Nota) 
                FROM testsXstudents 
                WHERE StudentId = s.id AND TestId = txs.TestId
            )
        ORDER BY 
            s.Name, te.TestNoumber";

            // Ejecutar la consulta (ajusta según el método real de SQLLiteHelper)
            var result = db.ExecuteSql<TraerTodoModels>(sql, courseId); // Método hipotético
            return Task.FromResult(result);
        }
    }
}
