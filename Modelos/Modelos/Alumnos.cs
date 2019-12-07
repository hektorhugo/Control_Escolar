using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace BackEnd.Modelos
{
    
    [Table("Alumnos", Schema = "DBO")]
    public class Alumnos
    {
        [Key]
        public int  idAlumno { get; set; }
        public string nombre { get; set; }
        public string apellidoPaterno { get; set; }
        public string apellidoMaterno { get; set; }
    }
    
}
