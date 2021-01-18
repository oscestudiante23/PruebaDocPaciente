using Hospital.Dominio.Entidad;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hospital.Infraestructura
{
    public class HospitalContext : DbContext
    {
        public HospitalContext(DbContextOptions<HospitalContext> options) : base(options)
        {
        }

        #region Entidades
        public DbSet<Doctor> Doctor { get; set; }
        public DbSet<Paciente> Paciente { get; set; }
        public DbSet<TipoDocumento> TipoDocumento { get; set; }

        public DbSet<Paciente_Doctor> Paciente_Doctor { get; set; }
        #endregion Entidades
    }
}
