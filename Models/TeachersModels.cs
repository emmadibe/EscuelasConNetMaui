
namespace EscuelaConMaui.Models
{
    [Table("teachers")] //propiedad, que me la otorga la herramienta sqllite que instalé, que le da el nombre a la tabla en la base de datos. 
    public partial class TeachersModels : AbstractBaseClass //Al extender de AbstractbaseClass, TeachersModels tiene la propiedad id.
    {
        [MaxLength(30)]
        public string? Name { get; set; }
        [MaxLength(30)]

        public string? LastName { get; set; }
        public int Age { get; set; }
        public string? Password {  get; set; }
        public string? Email { get; set; }
        public Rama Rama {  get; set; } = Rama.OTRO;

     
    }

}
