using Hospital.Models.Request;
using Hospital.Models.Response;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hospital.Infraestructura.Query.Contrato
{
    public interface IHospitalModelQuery
    {

        #region Parametricas
        List<TipoDocumentoResponse> ObtenerTipoDocumentos();
        #endregion Parametricas

        #region Pacientes        
        PacienteResponse ObtenerPacientePorId(long idPaciente);
        List<PacienteResponse> ObtenerPacientes();
        List<PacienteResponse> ObtenerPacientesPorDoctorId(long idDoctor);
        long CrearPaciente(PacienteRequest pacienteNuevo);
        long ActualizarPaciente(PacienteRequest pacienteModificado);
        long BorrarPacientePorId(long idPaciente);
        #endregion Pacientes

        #region Doctores
        DoctorResponse ObtenerDoctorPorId(long idDoctor);
        List<DoctorResponse> ObtenerDoctores();
        List<DoctorResponse> ObtenerDoctoresPorPacienteId(long idPaciente);
        long CrearDoctor(DoctorRequest doctorNuevo);
        #endregion Doctores


    }
}
