using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


namespace Hospital.Dominio.Entidad
{
    [Table("paciente", Schema = "dbo")]
    public class Paciente
    {
        [Key]
        [Column("pacienteId")]
        [Required]
        public long Id { get; set; }
        [Column("tipodocumentoId")]
        [Required]
        public int TipoDocumentoId { get; set; }
        [Column("pacienteNumeroDocumento")]
        [MaxLength(20)]
        [Required]
        public string NumeroDocumento { get; set; }
        [Column("pacienteNombreCompleto")]
        [MaxLength(150)]
        [Required]
        public string NombreCompleto { get; set; }
        [Column("pacienteNumeroSeguridadSocial")]
        [MaxLength(50)]
        [Required]
        public string NumeroSeguridadSocial { get; set; }
        [Column("pacienteCodigoPostal")]
        [MaxLength(20)]
        [Required]
        public string CodigoPostal { get; set; }
        [Column("pacienteTelefono")]
        [MaxLength(12)]
        [Required]
        public string Telefono { get; set; }

    }
}
