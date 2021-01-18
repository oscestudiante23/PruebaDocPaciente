import { DoctorResponse } from "../../doctor/Response/DoctorResponse.interface";

export interface PacienteResponse {
  id: number;
  tipoDocumentoId: number;
  numeroDocumento: string;
  nombreCompleto: string;
  numeroSeguridadSocial: string
  codigoPostal: string;
  telefono: string;
  lsDoctores: DoctorResponse[];
}
