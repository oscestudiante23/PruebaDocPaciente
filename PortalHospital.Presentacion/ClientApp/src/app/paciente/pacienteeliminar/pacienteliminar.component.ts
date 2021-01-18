import { Component, OnInit } from '@angular/core';
import { NgxSpinnerService } from "ngx-spinner";
import { ToastrService } from 'ngx-toastr';
import { Router } from '@angular/router';

import { PacienteResponse } from '../../models/paciente/Response/PacienteResponse.interface';
import { PacienteService } from '../../services/paciente.service';
import { HospitalService } from '../../services/hospital.service';
import { TipoDocumentoResponse } from '../../models/parametricas/Response/TipoDocumentoResponse.interface';

@Component({
  selector: 'app-pacienteliminar',
  templateUrl: './pacienteliminar.component.html',
  styleUrls: ['./pacienteliminar.component.css']
})

export class PacienteeliminarComponent implements OnInit {
  public lsPacienteResponse = [] as PacienteResponse[];
  public lsTipoDocumento = [] as TipoDocumentoResponse[];
  constructor(private toastr: ToastrService, private router: Router, private spinnerService: NgxSpinnerService,
    private pacienteService: PacienteService, private hospitalService: HospitalService) {
  }

  ngOnInit() {
    this.spinnerService.show();
    this.CargarPacientes();
  }

  private CargarPacientes() {
    this.pacienteService.ObtenerPacientes().subscribe((resp: any) => {
      this.spinnerService.hide();
      if (resp.estado == 1) {
        this.lsPacienteResponse = resp.lsPacientes;
      } else {
        this.toastr.info(' ' + resp.descripcion, 'Pacientes');
        console.log("Validacion Pacientes " + resp.descripcion);
      }
    }
      , error => {
        this.spinnerService.hide();
        console.log('Error al consultar Pacientes. ' + error.message);
        this.toastr.error('Error Servicio=' + error.message, 'Pacientes');
      });
  }

  ///////////////////************************Eventos******************////////////////
  public EliminarPacienteClick(id: number) {

    this.toastr.clear();
    this.spinnerService.show();
    this.pacienteService.BorrarPacientePorId(id).subscribe((resp: any) => {
      this.spinnerService.hide();
      if (resp.estado == 1) {
        this.toastr.info("Paciente Eliminado");
        window.location.reload();
      } else {
        this.toastr.info(' ' + resp.descripcion, 'Paciente Borrar');
        console.log("Validacion Paciente Borrar " + resp.descripcion);
      }
    }, error => {
      this.spinnerService.hide();
      console.log('Error al Borrar Paciente. ' + error.message);
      this.toastr.error('Error Servicio=' + error.message, 'Paciente Borrar');

    });
  }

}
