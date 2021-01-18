import { PacienteResponse } from "../../paciente/Response/PacienteResponse.interface";

export interface DoctorResponse {
  id: number;
  tipoDocumentoId: number;
  numeroDocumento: string;
  nombreCompleto: string;
  especialidad: string;
  numeroCredencial: string;
  nombreHospital: string;
  lsPacientes: PacienteResponse[];
}
