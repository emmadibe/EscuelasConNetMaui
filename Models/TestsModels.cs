using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MaxLengthAttribute = SQLite.MaxLengthAttribute;
using TableAttribute = SQLite.TableAttribute;

namespace EscuelaConMaui.Models
{
    [Table("tests")] //propiedad, que me la otorga la herramienta sqllite que instalé, que le da el nombre a la tabla en la base de datos. 
    public class TestsModels : AbstractBaseClass //Al extender de AbstractbaseClass, TestsModels tiene la propiedad id.
    {
        [ForeignKey("courses")] //Defino a la propiedad-campo CourseId, perteneciente a la clase-modelo-tabla Courses, como una Foreign Key. Esta clave foranea hace referencia al campo Id de la clase-modelo-tabla courses. EN SQLiteExtensions se asume que el campo al que hace referencia la FK es la Primary KEY de la clase referenciada. Por ello, no tengo que aclararlo. 
        public int CourseId { get; set; }
        
        [MaxLength(30)]
        [Required]
        public string? Name { get; set; }
        [Required]
        public int TestNoumber { get; set; }
        [Required]
        public DateTime Date { get; set; }
    }
}
