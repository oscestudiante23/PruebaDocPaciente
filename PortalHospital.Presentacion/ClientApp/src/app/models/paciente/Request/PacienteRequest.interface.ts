export interface PacienteRequest {
  id: number;
  tipoDocumentoId: number;
  numeroDocumento: string;
  nombreCompleto: string;
  numeroSeguridadSocial: string
  codigoPostal: string;
  telefono: string;
  lsDoctores: number[];
}
