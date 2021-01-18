using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Hospital.Dominio.Entidad
{
    [Table("tipodocumento", Schema = "dbo")]
    public class TipoDocumento
    {
        [Key]
        [Column("tipodocumentoId")]
        [Required]
        public int Id { get; set; }
        [Column("tipodocumentoNombreCorto")]
        [MaxLength(10)]
        [Required]
        public string NombreCorto { get; set; }
        [Column("tipodocumentoNombre")]
        [MaxLength(40)]
        [Required]
        public string Nombre { get; set; }
    }
}
