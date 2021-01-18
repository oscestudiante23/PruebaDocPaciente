using Hospital.Dominio.Entidad;
using Hospital.Infraestructura.Query.Contrato;
using Hospital.Models.Request;
using Hospital.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Hospital.Infraestructura.Query.Implementacion
{

    public class HospitalModelQuery : IHospitalModelQuery
    {
        private HospitalContext _db;
        public HospitalModelQuery(HospitalContext db)
        {
            _db = db;
        }

        #region Parametricas

        public List<TipoDocumentoResponse> ObtenerTipoDocumentos()
        {
            List<TipoDocumentoResponse> lsTipoDocumento = new List<TipoDocumentoResponse>();
            lsTipoDocumento = (from e in _db.TipoDocumento
                               orderby e.Id ascending
                               select new TipoDocumentoResponse
                               {
                                   Id = e.Id,
                                   NombreCorto = e.NombreCorto,
                                   Nombre = e.Nombre
                               }).ToList();
            return lsTipoDocumento;
        }

        #endregion Parametricas

        #region Pacientes
        public PacienteResponse ObtenerPacientePorId(long idPaciente)
        {
            PacienteResponse paciente = (from e in _db.Paciente
                                         where e.Id == idPaciente
                                         select new PacienteResponse
                                         {
                                             Id = e.Id,
                                             TipoDocumentoId = e.TipoDocumentoId,
                                             NumeroDocumento = e.NumeroDocumento,
                                             NombreCompleto = e.NombreCompleto,
                                             NumeroSeguridadSocial = e.NumeroSeguridadSocial,
                                             CodigoPostal = e.CodigoPostal,
                                             Telefono = e.Telefono

                                         }).FirstOrDefault();
            if (paciente != null)
            {
                paciente.LsDoctores = ObtenerDoctoresPorPacienteId(paciente.Id);
            }
            return paciente;
        }

        public List<PacienteResponse> ObtenerPacientes()
        {
            List<PacienteResponse> lsPacientes = new List<PacienteResponse>();
            lsPacientes = (from e in _db.Paciente
                           orderby e.Id descending
                           select new PacienteResponse
                           {
                               Id = e.Id,
                               TipoDocumentoId = e.TipoDocumentoId,
                               NumeroDocumento = e.NumeroDocumento,
                               NombreCompleto = e.NombreCompleto,
                               NumeroSeguridadSocial = e.NumeroSeguridadSocial,
                               CodigoPostal = e.CodigoPostal,
                               Telefono = e.Telefono
                           }).ToList();
            if (lsPacientes.Count > 0)
            {
                lsPacientes.ForEach(x => x.LsDoctores = ObtenerDoctoresPorPacienteId(x.Id));
            }
            return lsPacientes;
        }
        public List<PacienteResponse> ObtenerPacientesPorDoctorId(long idDoctor)
        {
            List<PacienteResponse> lsPacientes = new List<PacienteResponse>();
            lsPacientes = (from pd in _db.Paciente_Doctor
                           join e in _db.Paciente on pd.PacienteId equals e.Id
                           where pd.DoctorId == idDoctor
                           orderby e.Id descending
                           select new PacienteResponse
                           {
                               Id = e.Id,
                               TipoDocumentoId = e.TipoDocumentoId,
                               NumeroDocumento = e.NumeroDocumento,
                               NombreCompleto = e.NombreCompleto,
                               NumeroSeguridadSocial = e.NumeroSeguridadSocial,
                               CodigoPostal = e.CodigoPostal,
                               Telefono = e.Telefono
                           }).ToList();
            return lsPacientes;
        }

        public long CrearPaciente(PacienteRequest pacienteNuevo)
        {
            long resp = 0;
            Paciente paciente = new Paciente
            {
                Id = 0,
                TipoDocumentoId = pacienteNuevo.TipoDocumentoId,
                NumeroDocumento = pacienteNuevo.NumeroDocumento,
                NombreCompleto = pacienteNuevo.NombreCompleto,
                NumeroSeguridadSocial = pacienteNuevo.NumeroSeguridadSocial,
                CodigoPostal = pacienteNuevo.CodigoPostal,
                Telefono = pacienteNuevo.Telefono
            };
            _db.Paciente.Add(paciente);
            _db.SaveChanges();

            if (paciente.Id > 0 && pacienteNuevo.LsDoctores != null)
            {
                Paciente_Doctor pacienteDoctor;
                foreach (var idDoctor in pacienteNuevo.LsDoctores)
                {
                    pacienteDoctor = new Paciente_Doctor
                    {
                        Id = 0,
                        DoctorId = idDoctor,
                        PacienteId = paciente.Id
                    };
                    _db.Paciente_Doctor.Add(pacienteDoctor);
                    _db.SaveChanges();
                }
            }
            resp = paciente.Id;
            return resp;
        }

        public long ActualizarPaciente(PacienteRequest pacienteModificado)
        {
            long resp = 0;
            bool bmod = false;
            Paciente pacienteDB = _db.Paciente.FirstOrDefault(x => x.Id == pacienteModificado.Id);
            List<Paciente_Doctor> lsPacienteDoctorDB = _db.Paciente_Doctor.Where(x => x.PacienteId == pacienteModificado.Id).ToList();

            if (pacienteDB != null)
            {
                if (pacienteModificado.TipoDocumentoId != pacienteDB.TipoDocumentoId)
                {
                    pacienteDB.TipoDocumentoId = pacienteModificado.TipoDocumentoId;
                    bmod = true;
                }
                if (pacienteModificado.NumeroDocumento != pacienteDB.NumeroDocumento)
                {
                    pacienteDB.NumeroDocumento = pacienteModificado.NumeroDocumento;
                    bmod = true;
                }
                if (pacienteModificado.NombreCompleto != pacienteDB.NombreCompleto)
                {
                    pacienteDB.NombreCompleto = pacienteModificado.NombreCompleto;
                    bmod = true;
                }
                if (pacienteModificado.NumeroSeguridadSocial != pacienteDB.NumeroSeguridadSocial)
                {
                    pacienteDB.NumeroSeguridadSocial = pacienteModificado.NumeroSeguridadSocial;
                    bmod = true;
                }
                if (pacienteModificado.CodigoPostal != pacienteDB.CodigoPostal)
                {
                    pacienteDB.CodigoPostal = pacienteModificado.CodigoPostal;
                    bmod = true;
                }
                if (pacienteModificado.Telefono != pacienteDB.Telefono)
                {
                    pacienteDB.Telefono = pacienteModificado.Telefono;
                    bmod = true;
                }
                if (bmod)
                {
                    _db.Paciente.Update(pacienteDB);
                    _db.SaveChanges();
                    resp++;
                }
                if (lsPacienteDoctorDB.Count > 0)
                {
                    if (pacienteModificado.LsDoctores.Count > 0)
                    {
                        List<long> lsNuevosDoctores = pacienteModificado.LsDoctores.Where(x => !lsPacienteDoctorDB.Exists(e => e.DoctorId == x)).ToList();
                        foreach (var pacienteDoctorBorrar in lsPacienteDoctorDB.Where(x => !pacienteModificado.LsDoctores.Exists(e => e == x.DoctorId)).ToList())
                        {
                            _db.Paciente_Doctor.Remove(pacienteDoctorBorrar);
                            _db.SaveChanges();
                            resp++;
                        }
                        lsPacienteDoctorDB.Clear();

                        foreach (var doctorId in lsNuevosDoctores)
                        {
                            _db.Paciente_Doctor.Add(new Paciente_Doctor { Id = 0, PacienteId = pacienteModificado.Id, DoctorId = doctorId });
                            _db.SaveChanges();
                            resp++;
                        }
                    }
                    else
                    {
                        _db.Paciente_Doctor.RemoveRange(lsPacienteDoctorDB);
                        _db.SaveChanges();
                        resp++;
                    }
                }
                else
                {
                    foreach (var doctorId in pacienteModificado.LsDoctores)
                    {
                        _db.Paciente_Doctor.Add(new Paciente_Doctor { Id = 0, PacienteId = pacienteModificado.Id, DoctorId = doctorId });
                        _db.SaveChanges();
                        resp++;
                    }
                }

            }
            return resp;
        }

        public long BorrarPacientePorId(long idPaciente)
        {
            long resp = 0;
            List<Paciente_Doctor> lsPacienteDoctorDB = _db.Paciente_Doctor.Where(x => x.PacienteId == idPaciente).ToList();
            Paciente pacienteDB = _db.Paciente.FirstOrDefault(x => x.Id == idPaciente);
            if (pacienteDB != null)
            {
                if (lsPacienteDoctorDB.Count > 0)
                {
                    _db.Paciente_Doctor.RemoveRange(lsPacienteDoctorDB);
                    _db.SaveChanges();
                }
                _db.Paciente.Remove(pacienteDB);
                _db.SaveChanges();
                resp = 1;
            }
            return resp;
        }

        #endregion Pacientes


        #region Doctores
        public DoctorResponse ObtenerDoctorPorId(long idDoctor)
        {
            DoctorResponse doctor = (from e in _db.Doctor
                                     where e.Id == idDoctor
                                     select new DoctorResponse
                                     {
                                         Id = e.Id,
                                         TipoDocumentoId = e.TipoDocumentoId,
                                         NumeroDocumento = e.NumeroDocumento,
                                         NombreCompleto = e.NombreCompleto,
                                         Especialidad = e.Especialidad,
                                         NumeroCredencial = e.NumeroCredencial,
                                         NombreHospital = e.NombreHospital
                                     }).FirstOrDefault();
            if (doctor != null)
            {
                doctor.LsPacientes = ObtenerPacientesPorDoctorId(doctor.Id);
            }
            return doctor;
        }
        public List<DoctorResponse> ObtenerDoctores()
        {
            List<DoctorResponse> lsDoctor = new List<DoctorResponse>();
            lsDoctor = (from e in _db.Doctor
                        orderby e.Id descending
                        select new DoctorResponse
                        {
                            Id = e.Id,
                            TipoDocumentoId = e.TipoDocumentoId,
                            NumeroDocumento = e.NumeroDocumento,
                            NombreCompleto = e.NombreCompleto,
                            Especialidad = e.Especialidad,
                            NumeroCredencial = e.NumeroCredencial,
                            NombreHospital = e.NombreHospital
                        }).ToList();
            if (lsDoctor.Count > 0)
            {
                lsDoctor.ForEach(x => x.LsPacientes = ObtenerPacientesPorDoctorId(x.Id));
            }

            return lsDoctor;
        }
        public List<DoctorResponse> ObtenerDoctoresPorPacienteId(long idPaciente)
        {
            List<DoctorResponse> lsPacientes = new List<DoctorResponse>();
            lsPacientes = (from pd in _db.Paciente_Doctor
                           join e in _db.Doctor on pd.DoctorId equals e.Id
                           where pd.PacienteId == idPaciente
                           orderby e.Id descending
                           select new DoctorResponse
                           {
                               Id = e.Id,
                               TipoDocumentoId = e.TipoDocumentoId,
                               NumeroDocumento = e.NumeroDocumento,
                               NombreCompleto = e.NombreCompleto,
                               Especialidad = e.Especialidad,
                               NumeroCredencial = e.NumeroCredencial,
                               NombreHospital = e.NombreHospital
                           }).ToList();
            return lsPacientes;
        }
        //Nuevo
        public long CrearDoctor(DoctorRequest doctorNuevo)
        {
            long resp = 0;
            Doctor doctor = new Doctor
            {
                Id = 0,
                TipoDocumentoId = doctorNuevo.TipoDocumentoId,
                NumeroDocumento = doctorNuevo.NumeroDocumento,
                NombreCompleto = doctorNuevo.NombreCompleto,
                Especialidad = doctorNuevo.Especialidad,
                NumeroCredencial = doctorNuevo.NumeroCredencial,
                NombreHospital = doctorNuevo.NombreHospital
            };
            _db.Doctor.Add(doctor);
            _db.SaveChanges();
            if (doctor.Id > 0 && doctorNuevo.LsPacientes != null)
            {
                Paciente_Doctor pacienteDoctor;
                foreach (var idPaciente in doctorNuevo.LsPacientes)
                {
                    pacienteDoctor = new Paciente_Doctor
                    {
                        Id = 0,
                        DoctorId = doctor.Id,
                        PacienteId = idPaciente
                    };
                    _db.Paciente_Doctor.Add(pacienteDoctor);
                    _db.SaveChanges();
                }
            }
            resp = doctor.Id;
            return resp;
        }

        #endregion Doctores
    }
}
