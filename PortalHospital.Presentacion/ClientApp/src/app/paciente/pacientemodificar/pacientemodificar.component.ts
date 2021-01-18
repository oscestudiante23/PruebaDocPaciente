import { Component, OnInit } from '@angular/core';
import { NgxSpinnerService } from "ngx-spinner";
import { ToastrService } from 'ngx-toastr';
import { Router } from '@angular/router';

import { PacienteResponse } from '../../models/paciente/Response/PacienteResponse.interface';
import { PacienteService } from '../../services/paciente.service';
import { HospitalService } from '../../services/hospital.service';
import { TipoDocumentoResponse } from '../../models/parametricas/Response/TipoDocumentoResponse.interface';

@Component({
  selector: 'app-pacientemodificar',
  templateUrl: './pacientemodificar.component.html',
  styleUrls: ['./pacientemodificar.component.css']
})

export class PacientemodificarComponent implements OnInit {
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
  public DetallePacienteClick(id: string) {
    this.toastr.clear();
    if (id)
      this.router.navigate(['pacientemodificardet/', id]);
  }
}
