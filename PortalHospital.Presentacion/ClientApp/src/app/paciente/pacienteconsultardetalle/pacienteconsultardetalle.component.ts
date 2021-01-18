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
  selector: 'app-pacienteconsultardetalle',
  templateUrl: './pacienteconsultardetalle.component.html',
  styleUrls: ['./pacienteconsultardetalle.component.css']
})

export class PacienteconsultardetalleComponent implements OnInit {

  public lsTipoDocumento = [] as TipoDocumentoResponse[];
  public lsDoctorResponse = [] as DoctorResponse[];
  public pacienteResponse = {} as PacienteResponse;
  private idPaciente: number = 0;
  public tipoDocumentoPacienteTexto: string;

  constructor(private toastr: ToastrService, private router: Router, private spinnerService: NgxSpinnerService, private activeRoute: ActivatedRoute,
    private doctorService: DoctorService, private pacienteService: PacienteService, private hospitalService: HospitalService) {
  }
  ngOnInit() {
    this.spinnerService.show();
    this.activeRoute.params.subscribe(parametros => {
      this.idPaciente = parametros['id'];
    },
      error => {
        this.toastr.error("Error:" + error.message, "Traer ID del Paciente")
      });

    this.CargarTipoDocumento();
    setTimeout(() => {
      this.CargarPacientePorId();
    }, 200);
  }

  private CargarTipoDocumento() {
    this.hospitalService.ObtenerTipoDocumento().subscribe((resp: any) => {
      this.spinnerService.hide();
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

  private CargarPacientePorId() {
    this.pacienteService.ObtenerPacientePorId(this.idPaciente).subscribe((resp: any) => {
      this.spinnerService.hide();
      if (resp.estado == 1) {
        this.pacienteResponse = resp.paciente;
        this.lsDoctorResponse = this.pacienteResponse.lsDoctores;
        for (let ob of this.lsTipoDocumento.filter(x => x.id == this.pacienteResponse.tipoDocumentoId)) {
          this.tipoDocumentoPacienteTexto = ob.nombre;
        }
      } else {
        this.toastr.info('Validacion. ' + resp.descripcion, 'Paciente');
        console.log("Validacion Paciente id. " + resp.descripcion);
      }
    }
      , error => {
        this.spinnerService.hide();
        this.toastr.error('Error Servicio=' + error.message, 'Paciente');
      });
  }

}
