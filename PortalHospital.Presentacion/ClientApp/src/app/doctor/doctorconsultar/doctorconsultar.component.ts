import { Component, OnInit } from '@angular/core';
import { NgxSpinnerService } from "ngx-spinner";
import { ToastrService } from 'ngx-toastr';
import { Router } from '@angular/router';
import { DoctorService } from '../../services/doctor.service';
import { DoctorResponse } from '../../models/doctor/Response/DoctorResponse.interface';

@Component({
  selector: 'app-doctorconsultar',
  templateUrl: './doctorconsultar.component.html',
  styleUrls: ['./doctorconsultar.component.css']
})

export class DoctorconsultarComponent implements OnInit {
  public lsDoctorResponse = [] as DoctorResponse[];
  constructor(private toastr: ToastrService, private router: Router, private spinnerService: NgxSpinnerService,
    private doctorService: DoctorService) {
  }

  ngOnInit() {
    this.spinnerService.show();
    this.CargarDoctores();
  }

  private CargarDoctores() {
    this.doctorService.ObtenerDoctores().subscribe((resp: any) => {
      this.spinnerService.hide();
      if (resp.estado == 1) {
        this.lsDoctorResponse = resp.lsDoctores;
      } else {
        this.toastr.info('Validacion. ' + resp.descripcion, 'Doctores');
        console.log("Validacion Doctores " + resp.descripcion);
      }
    }
      , error => {
        this.spinnerService.hide();
        console.log('Error al consultar Doctores. ' + error.message);
        this.toastr.error('Error Servicio=' + error.message, 'Doctores');
      });
  }



  ///////////////////************************Eventos******************////////////////
  public DetalleDoctorClick(id: string) {
    this.toastr.clear();
    if (id)
      this.router.navigate(['doctordetalle/', id]);
  }
}
