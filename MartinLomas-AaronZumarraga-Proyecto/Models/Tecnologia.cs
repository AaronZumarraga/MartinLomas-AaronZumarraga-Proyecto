using System.ComponentModel.DataAnnotations;

namespace MartinLomas_AaronZumarraga_Proyecto.Models
{
    public class Tecnologia
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "No se olvide de ingresar el asunto")]
        [StringLength(30)]
        public string Asunto { get; set; }
        [Required(ErrorMessage = "Ingrese sus aportes al tema")]

        public string Discusion { get; set; }
        [Required]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:dd-mm-aa}")]
        public DateTime Fecha { get; set; }

    }
}
