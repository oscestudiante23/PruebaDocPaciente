import { Component, OnInit } from '@angular/core';
import { NgxSpinnerService } from "ngx-spinner";
import { ToastrService } from 'ngx-toastr';
import { Router } from '@angular/router';
import { DoctorService } from '../../services/doctor.service';
import { HospitalService } from '../../services/hospital.service';
import { FormControl, Validators } from '@angular/forms';
import { PacienteService } from '../../services/paciente.service';
import { TipoDocumentoResponse } from '../../models/parametricas/Response/TipoDocumentoResponse.interface';
import { DoctorResponse } from '../../models/doctor/Response/DoctorResponse.interface';
import { DoctorListaViewModel } from '../../models/doctor/ViewModel/DoctorListaViewModel';
import { PacienteRequest } from '../../models/paciente/Request/PacienteRequest.interface';

@Component({
  selector: 'app-pacientecrear',
  templateUrl: './pacientecrear.component.html',
  styleUrls: ['./pacientecrear.component.css']
})

export class PacientecrearComponent implements OnInit {

  tipoDocumentoIdControl = new FormControl('', [Validators.required, Validators.pattern('^[0-9]*$')]);
  numeroDocumentoControl = new FormControl('', [Validators.required, Validators.pattern('^[0-9]*$')]);
  nombreCompletoControl = new FormControl('', [Validators.required, Validators.pattern('^[a-zA-Z áéíóú.]*$')]);
  numeroSeguridadSocialControl = new FormControl('', [Validators.required, Validators.pattern('^[0-9a-zA-Z]*$')]);
  codigoPostalControl = new FormControl('', [Validators.required, Validators.pattern('^[0-9a-zA-Z]*$')]);
  telefonoControl = new FormControl('', [Validators.required, Validators.pattern('^[0-9]*$')]);

  public lsTipoDocumento = [] as TipoDocumentoResponse[];
  public lsDoctorListaDB = [] as DoctorListaViewModel[];

  public lsDoctorResponseOriginal = [] as DoctorResponse[];
  public lsDoctorResponseAsignados = [] as DoctorResponse[];

  doctorIdControl = new FormControl('', [Validators.required, Validators.pattern('^[0-9]*$')]);

  constructor(private toastr: ToastrService, private router: Router, private spinnerService: NgxSpinnerService,
    private doctorService: DoctorService, private pacienteService: PacienteService, private hospitalService: HospitalService) {
  }

  ngOnInit() {
    this.spinnerService.show();
    this.CargarTipoDocumento();
    this.CargarDoctores();
  }

  private CargarTipoDocumento() {
    this.hospitalService.ObtenerTipoDocumento().subscribe((resp: any) => {
      // this.spinnerService.hide();
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

  private CargarDoctores() {
    this.lsDoctorListaDB = [] as DoctorListaViewModel[];
    this.lsDoctorResponseOriginal = [] as DoctorResponse[];
    this.doctorService.ObtenerDoctores().subscribe((resp: any) => {
      this.spinnerService.hide();
      if (resp.estado == 1) {
        this.lsDoctorResponseOriginal = resp.lsDoctores;
        let doctorListaItem;
        for (let ob of this.lsDoctorResponseOriginal) {
          doctorListaItem = {} as DoctorListaViewModel;
          doctorListaItem.id = ob.id;
          doctorListaItem.numeroDocumentoNombre = ob.numeroDocumento + ' ' + ob.nombreCompleto;
          this.lsDoctorListaDB.push(doctorListaItem);
        }
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

  private ValidardoctorIdControl(): boolean {
    if (!this.doctorIdControl.valid) {
      if (this.doctorIdControl.getError('required') != null) {
        this.toastr.info('Debe elegir un Doctor para poderlo asignar');
        return false;
      }
      if (this.doctorIdControl.getError('pattern') != null) {
        this.toastr.info('El valor del Doctor elegido no tiene formato correcto');
        return false;
      }
    } else {
      let campoVal: string = this.doctorIdControl.value;
      if (campoVal == '0' || campoVal == '') {
        this.toastr.info('Es necesario que elija un Doctor para poderlo asignar');
        return false;
      }
    }

    return true;
  }
  private ValidarCampos(): boolean {
    if (!this.tipoDocumentoIdControl.valid) {
      if (this.tipoDocumentoIdControl.getError('required') != null) {
        this.toastr.info('El valor del campo Tipo de Documento es obligatorio');
        return false;
      }
      if (this.tipoDocumentoIdControl.getError('pattern') != null) {
        this.toastr.info('El valor del campo Tipo de Documento tiene caracteres no validos');
        return false;
      }
    }
    else {
      let campoVal: string = this.tipoDocumentoIdControl.value;
      if (campoVal.length > 2) {
        this.toastr.info('El valor del campo Tipo de Documento No tiene una longitud Correcta');
        return false;
      }
    }

    if (!this.numeroDocumentoControl.valid) {
      if (this.numeroDocumentoControl.getError('required') != null) {
        this.toastr.info('El valor del campo Numero de Documento es obligatorio');
        return false;
      }
      if (this.numeroDocumentoControl.getError('pattern') != null) {
        this.toastr.info('El valor del campo Numero de Documento tiene caracteres no validos');
        return false;
      }
    }
    else {
      let campoVal: string = this.numeroDocumentoControl.value;
      if (campoVal.length > 20) {
        this.toastr.info('El valor del campo Numero de Documento No tiene una longitud Correcta');
        return false;
      }
    }

    if (!this.nombreCompletoControl.valid) {
      if (this.nombreCompletoControl.getError('required') != null) {
        this.toastr.info('El valor del campo Nombre es obligatorio');
        return false;
      }
      if (this.nombreCompletoControl.getError('pattern') != null) {
        this.toastr.info('El valor del campo Nombre tiene caracteres no validos');
        return false;
      }
    } else {
      let campoVal: string = this.nombreCompletoControl.value;
      if (campoVal.length > 100) {
        this.toastr.info('El valor del campo Nombre No tiene una longitud Correcta');
        return false;
      }
    }

    if (!this.numeroSeguridadSocialControl.valid) {
      if (this.numeroSeguridadSocialControl.getError('required') != null) {
        this.toastr.info('El valor del campo Numero de Seguridad Social es obligatorio');
        return false;
      }
      if (this.numeroSeguridadSocialControl.getError('pattern') != null) {
        this.toastr.info('El valor del campo Numero de Seguridad Social tiene caracteres no validos');
        return false;
      }
    } else {
      let campoVal: string = this.numeroSeguridadSocialControl.value;
      if (campoVal.length > 50) {
        this.toastr.info('El valor del campo Numero de Seguridad Social No tiene una longitud Correcta');
        return false;
      }
    }

    if (!this.codigoPostalControl.valid) {
      if (this.codigoPostalControl.getError('required') != null) {
        this.toastr.info('El valor del campo Codigo Postal es obligatorio');
        return false;
      }
      if (this.codigoPostalControl.getError('pattern') != null) {
        this.toastr.info('El valor del campo Codigo Postal tiene caracteres no validos');
        return false;
      }
    } else {
      let campoVal: string = this.codigoPostalControl.value;
      if (campoVal.length > 20) {
        this.toastr.info('El valor del campo Codigo Postal No tiene una longitud Correcta');
        return false;
      }
    }
    if (!this.telefonoControl.valid) {
      if (this.telefonoControl.getError('required') != null) {
        this.toastr.info('El valor del campo Telefono es obligatorio');
        return false;
      }
      if (this.telefonoControl.getError('pattern') != null) {
        this.toastr.info('El valor del campo Telefono tiene caracteres no validos');
        return false;
      }
    } else {
      let campoVal: string = this.telefonoControl.value;
      if (campoVal.length > 12) {
        this.toastr.info('El valor del campo Telefono No tiene una longitud Correcta');
        return false;
      }
    }

    return true;
  }

  /////////////////////////////////**********************Eventos************************************////

  public GuardarClick() {
    this.toastr.clear();
    if (this.ValidarCampos()) {
      let pasienteRequest = {} as PacienteRequest;
      pasienteRequest.id = 0;
      pasienteRequest.tipoDocumentoId = this.tipoDocumentoIdControl.value;
      pasienteRequest.numeroDocumento = (this.numeroDocumentoControl.value as string).toLowerCase();
      pasienteRequest.nombreCompleto = (this.nombreCompletoControl.value as string).toLowerCase();
      pasienteRequest.numeroSeguridadSocial = (this.numeroSeguridadSocialControl.value as string).toLowerCase();
      pasienteRequest.codigoPostal = (this.codigoPostalControl.value as string).toLowerCase();
      pasienteRequest.telefono = (this.telefonoControl.value as string).toLowerCase();

      for (let ob of this.lsDoctorResponseAsignados) {
        pasienteRequest.lsDoctores = [] as number[];
        pasienteRequest.lsDoctores.push(ob.id);
      }

      this.spinnerService.show();
      this.pacienteService.CrearPaciente(pasienteRequest).subscribe((resp: any) => {
        this.spinnerService.hide();
        if (resp.estado == 1) {
          this.toastr.info("Paciente Creado correctamente");
          window.location.reload();

        } else {
          this.toastr.info('No se logro Crear el Paciente.' + resp.descripcion, "Crear Paciente");
        }
      }, error => {
        this.spinnerService.hide();
        this.toastr.error('Error Servicio=' + error.message, 'Crear Paciente');
      });
    }
  }

  public ExcluirDoctorClick(idDoctor: number) {

    for (let ob of this.lsDoctorResponseAsignados.filter(x => x.id == idDoctor)) {
      let indx = this.lsDoctorResponseAsignados.indexOf(ob);
      this.lsDoctorResponseAsignados.splice(indx, 1);
    }
  }

  public AsignarDoctorClick() {

    if (this.ValidardoctorIdControl()) {
      for (let ob of this.lsDoctorResponseOriginal.filter(x => x.id == this.doctorIdControl.value)) {
        var arrObj = this.lsDoctorResponseAsignados.filter(x => x.id == ob.id);
        if (arrObj == undefined || arrObj == null || arrObj.length == 0) {
          let doctorResponsePorAsignarLocal = {} as DoctorResponse;
          doctorResponsePorAsignarLocal.id = ob.id;
          doctorResponsePorAsignarLocal.tipoDocumentoId = ob.tipoDocumentoId;
          doctorResponsePorAsignarLocal.numeroDocumento = ob.numeroDocumento;
          doctorResponsePorAsignarLocal.nombreCompleto = ob.nombreCompleto;
          doctorResponsePorAsignarLocal.especialidad = ob.especialidad;
          doctorResponsePorAsignarLocal.numeroCredencial = ob.numeroCredencial;
          doctorResponsePorAsignarLocal.nombreHospital = ob.nombreHospital;

          this.lsDoctorResponseAsignados.push(doctorResponsePorAsignarLocal);
        } else {
          this.toastr.info("El Doctor ya se encuentra asignado");
        }
        break;
      }
    }
  }



}
