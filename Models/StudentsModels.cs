using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EscuelaConMaui.Models;
using TableAttribute = SQLite.TableAttribute;

namespace EscuelaConMaui.Models
{
    [Table("students")] //propiedad, que me la otorga la herramienta sqllite que instalé, que le da el nombre a la tabla en la base de datos. 
    public class StudentsModels : AbstractBaseClass //hereda de Person. 
    {
        [ForeignKey("courses")] //Defino a la propiedad-campo CourseId, perteneciente a la clase-modelo-tabla students, como una Foreign Key. Esta clave foranea hace referencia al campo Id de la clase-modelo-tabla courses. EN SQLiteExtensions se asume que el campo al que hace referencia la FK es la Primary KEY de la clase referenciada. Por ello, no tengo que aclararlo.
        public int CourseId { get; set; }

        [MaxLength(30)]
        public string? Name { get; set; }
        [MaxLength(30)]

        public string? LastName { get; set; }
    }
}
