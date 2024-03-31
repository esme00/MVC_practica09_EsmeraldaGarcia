using System.ComponentModel.DataAnnotations;

namespace MVC_practica09_EsmeraldaGarcia.Models
{
    public class tipo_equipo
    {
        [Key]
        public int tipo_equipo_id { get; set; }
        public string? descripcion { get; set; }
        public string? estado { get; set; }

    }
}
