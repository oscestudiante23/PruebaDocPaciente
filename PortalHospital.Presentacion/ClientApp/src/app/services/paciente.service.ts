import { Injectable, Inject } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { PacienteRequest } from '../models/paciente/Request/PacienteRequest.interface';

@Injectable({
  providedIn: 'root'
})

export class PacienteService {

  httpOptions: any;
  constructor(private http: HttpClient, @Inject("BASE_URL") private baseUrl: string) {
  }

  public ObtenerPacientes() {
    this.httpOptions = { headers: new HttpHeaders({ 'Content-Type': 'application/json', 'Authorization': '' }) };
    return this.http.get(this.baseUrl + "Paciente/ObtenerPacientesMediador", this.httpOptions);
  }

  public ObtenerPacientePorId(id: number) {
    this.httpOptions = { headers: new HttpHeaders({ 'Content-Type': 'application/json', 'Authorization': '' }) };
    return this.http.get(this.baseUrl + "Paciente/ObtenerPacientePorIdMediador/" + id.toString(), this.httpOptions);
  }

  public CrearPaciente(pacienteRequest: PacienteRequest) {
    this.httpOptions = { headers: new HttpHeaders({ 'Content-Type': 'application/json', 'Authorization': '' }) };
    return this.http.post(this.baseUrl + "Paciente/CrearPacienteMediador", pacienteRequest, this.httpOptions);
  }

  public ActualizarPaciente(pacienteRequest: PacienteRequest) {
    this.httpOptions = { headers: new HttpHeaders({ 'Content-Type': 'application/json', 'Authorization': '' }) };
    return this.http.put(this.baseUrl + "Paciente/ActualizarPacienteMediador", pacienteRequest, this.httpOptions);
  }

  public BorrarPacientePorId(id: number) {
    this.httpOptions = { headers: new HttpHeaders({ 'Content-Type': 'application/json', 'Authorization': '' }) };
    return this.http.delete(this.baseUrl + "Paciente/BorrarPacientePorIdMediador/" + id.toString(), this.httpOptions);
  }

}
