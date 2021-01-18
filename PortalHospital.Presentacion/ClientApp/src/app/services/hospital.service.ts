import { Injectable, Inject } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})

export class HospitalService {

  httpOptions: any;
  constructor(private http: HttpClient, @Inject("BASE_URL") private baseUrl: string) {
  }

  public ObtenerTipoDocumento() {
    this.httpOptions = { headers: new HttpHeaders({ 'Content-Type': 'application/json', 'Authorization': '' }) };
    return this.http.get(this.baseUrl + "Hospital/ObtenerTipoDocumentoMediador", this.httpOptions);
  }
}
