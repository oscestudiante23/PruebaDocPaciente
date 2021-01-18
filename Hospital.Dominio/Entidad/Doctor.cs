using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hospital.Dominio.Entidad
{
    [Table("doctor", Schema = "dbo")]
    public class Doctor
    {
        [Key]
        [Column("doctorId")]
        [Required]
        public long Id { get; set; }
        [Column("tipodocumentoId")]
        [Required]
        public int TipoDocumentoId { get; set; }
        [Column("doctorNumeroDocumento")]
        [Required]
        [MaxLength(20)]
        public string NumeroDocumento { get; set; }
        [Column("doctorNombreCompleto")]
        [Required]
        [MaxLength(150)]
        public string NombreCompleto { get; set; }
        [Column("doctorEspecialidad")]
        [Required]
        [MaxLength(80)]
        public string Especialidad { get; set; }
        [Column("doctorNumeroCredencial")]
        [Required]
        [MaxLength(20)]
        public string NumeroCredencial { get; set; }
        [Column("doctorNombreHospital")]
        [Required]
        [MaxLength(80)]
        public string NombreHospital { get; set; }
    }
}
