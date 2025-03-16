using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using TableAttribute = SQLite.TableAttribute;
using Microsoft.EntityFrameworkCore;


namespace EscuelaConMaui.Models
{
    [Table("testsXstudents")] //propiedad, que me la otorga la herramienta sqllite que instalé, que le da el nombre a la tabla en la base de datos. 
    public partial class TestsXStudentsModels : AbstractBaseClass
    {
        [ForeignKey("students")]
        public int StudentId { get; set; }
        [ForeignKey("tests")] 
        public int TestId { get; set; }

        public int Nota {  get; set; }
    }
}
