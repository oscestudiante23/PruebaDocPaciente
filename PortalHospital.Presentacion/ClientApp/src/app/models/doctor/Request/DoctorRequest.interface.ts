export interface DoctorRequest {
  id: number;
  tipoDocumentoId: number;
  numeroDocumento: string;
  nombreCompleto: string;
  especialidad: string;
  numeroCredencial: string;
  nombreHospital: string;
  lsPacientes: number[];
}
