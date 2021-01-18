import { Component, OnInit } from '@angular/core';
import { NgxSpinnerService } from "ngx-spinner";
import { ToastrService } from 'ngx-toastr';
import { Router, ActivatedRoute } from '@angular/router';
import { DoctorService } from '../../services/doctor.service';
import { PacienteService } from '../../services/paciente.service';
import { HospitalService } from '../../services/hospital.service';
import { TipoDocumentoResponse } from '../../models/parametricas/Response/TipoDocumentoResponse.interface';
import { PacienteResponse } from '../../models/paciente/Response/PacienteResponse.interface';
import { DoctorResponse } from '../../models/doctor/Response/DoctorResponse.interface';

@Component({
  selector: 'app-doctorconsultardetalle',
  templateUrl: './doctorconsultardetalle.component.html',
  styleUrls: ['./doctorconsultardetalle.component.css']
})

export class DoctorconsultardetalleComponent implements OnInit {

  public lsTipoDocumento = [] as TipoDocumentoResponse[];
  public lsPacienteResponse = [] as PacienteResponse[];
  public doctorResponse = {} as DoctorResponse;
  private idDoctor: number = 0;
  public tipoDocumentoDoctorTexto: string;

  constructor(private toastr: ToastrService, private router: Router, private spinnerService: NgxSpinnerService, private activeRoute: ActivatedRoute,
    private doctorService: DoctorService, private pacienteService: PacienteService, private hospitalService: HospitalService) {
  }
  ngOnInit() {

    this.activeRoute.params.subscribe(parametros => {
      this.idDoctor = parametros['id'];
    },
      error => {
        this.toastr.error("Error:" + error.message, "Traer ID de doctor")
      });
    this.spinnerService.show();
    this.CargarTipoDocumento();
    setTimeout(() => {
      this.CargarDoctorPorId();
    }, 200);
  }

  private CargarTipoDocumento() {
    this.hospitalService.ObtenerTipoDocumento().subscribe((resp: any) => {

      if (resp.estado == 1) {
        this.lsTipoDocumento = resp.lsTipoDocumento;
      } else {
        this.toastr.info(' ' + resp.descripcion, 'Tipos de documento');
        console.log("Validacion Pacientes " + resp.descripcion);
      }
    }
      , error => {
        this.spinnerService.hide();
        this.toastr.error('Error Servicio=' + error.message, 'Tipos de documento');
      });
  }

  private CargarDoctorPorId() {
    this.doctorService.ObtenerDoctorPorId(this.idDoctor).subscribe((resp: any) => {
      this.spinnerService.hide();
      if (resp.estado == 1) {
        this.doctorResponse = resp.doctor;
        this.lsPacienteResponse = this.doctorResponse.lsPacientes;
        for (let ob of this.lsTipoDocumento.filter(x => x.id == this.doctorResponse.tipoDocumentoId)) {
          this.tipoDocumentoDoctorTexto = ob.nombre;
        }
      } else {
        this.toastr.info('Validacion. ' + resp.descripcion, 'Doctor');
        console.log("Validacion Doctor " + resp.descripcion);
      }
    }
      , error => {
        this.spinnerService.hide();
        this.toastr.error('Error Servicio=' + error.message, 'Doctor');
      });
  }

}
