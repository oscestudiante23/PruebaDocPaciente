import { Injectable, Inject } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { DoctorRequest } from '../models/doctor/Request/DoctorRequest.interface';

@Injectable({
  providedIn: 'root'
})

export class DoctorService {

  httpOptions: any;
  constructor(private http: HttpClient, @Inject("BASE_URL") private baseUrl: string) {
  }

  public ObtenerDoctores() {
    this.httpOptions = { headers: new HttpHeaders({ 'Content-Type': 'application/json', 'Authorization': '' }) };
    return this.http.get(this.baseUrl + "Doctor/ObtenerDoctoresMediador", this.httpOptions);
  }

  public ObtenerDoctorPorId(id: number) {
    this.httpOptions = { headers: new HttpHeaders({ 'Content-Type': 'application/json', 'Authorization': '' }) };
    return this.http.get(this.baseUrl + "Doctor/ObtenerDoctorPorIdMediador/" + id.toString(), this.httpOptions);
  }

  public CrearDoctor(doctorRequest: DoctorRequest) {
    this.httpOptions = { headers: new HttpHeaders({ 'Content-Type': 'application/json', 'Authorization': '' }) };
    return this.http.post(this.baseUrl + "Doctor/CrearDoctorMediador", doctorRequest, this.httpOptions);
  }

}
