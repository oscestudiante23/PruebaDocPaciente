using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hospital.Dominio.Entidad
{
    public class Paciente_Doctor
    {
        [Key]
        [Column("pacientedoctorId")]
        [Required]
        public long Id { get; set; }
        [Column("pacienteId")]
        [Required]
        public long PacienteId { get; set; }
        [Column("doctorId")]
        [Required]
        public long DoctorId { get; set; }
    }
}
