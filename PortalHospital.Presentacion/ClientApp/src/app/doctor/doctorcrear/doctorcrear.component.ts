import { Component, OnInit } from '@angular/core';
import { NgxSpinnerService } from "ngx-spinner";
import { ToastrService } from 'ngx-toastr';
import { Router } from '@angular/router';
import { DoctorService } from '../../services/doctor.service';
import { HospitalService } from '../../services/hospital.service';
import { FormControl, Validators } from '@angular/forms';
import { TipoDocumentoResponse } from '../../models/parametricas/Response/TipoDocumentoResponse.interface';
import { DoctorRequest } from '../../models/doctor/Request/DoctorRequest.interface';
import { PacienteRequest } from '../../models/paciente/Request/PacienteRequest.interface';
import { PacienteResponse } from '../../models/paciente/Response/PacienteResponse.interface';
import { PacienteService } from '../../services/paciente.service';
import { PacienteListaViewModel } from '../../models/paciente/ViewModel/PacienteListaViewModel.interface';

@Component({
  selector: 'app-doctorcrear',
  templateUrl: './doctorcrear.component.html',
  styleUrls: ['./doctorcrear.component.css']
})

export class DoctorcrearComponent implements OnInit {
  tipoDocumentoIdControl = new FormControl('', [Validators.required, Validators.pattern('^[0-9]*$')]);
  numeroDocumentoControl = new FormControl('', [Validators.required, Validators.pattern('^[0-9]*$')]);
  nombreCompletoControl = new FormControl('', [Validators.required, Validators.pattern('^[a-zA-Z áéíóú.]*$')]);
  especialidadControl = new FormControl('', [Validators.required, Validators.pattern('^[a-zA-Z áéíóú]*$')]);
  numeroCredencialControl = new FormControl('', [Validators.required, Validators.pattern('^[0-9]*$')]);
  nombreHospitalControl = new FormControl('', [Validators.required, Validators.pattern('^[a-zA-Z 0-9áéíóú]*$')]);

  pacienteIdControl = new FormControl('', [Validators.required, Validators.pattern('^[0-9]*$')]);

  public lsTipoDocumento = [] as TipoDocumentoResponse[];
  public lsPacienteResponseOriginal = [] as PacienteResponse[];
  public lsPacienteListaDB = [] as PacienteListaViewModel[];
  public lsPacienteResponseAsignados = [] as PacienteResponse[];

  constructor(private toastr: ToastrService, private router: Router, private spinnerService: NgxSpinnerService,
    private doctorService: DoctorService, private pacienteService: PacienteService, private hospitalService: HospitalService) {
  }

  ngOnInit() {
    this.spinnerService.show();
    this.CargarTipoDocumento();
    setTimeout(() => {
      this.CargarPacientes();
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

  private CargarPacientes() {
    this.lsPacienteListaDB = [] as PacienteListaViewModel[];
    this.lsPacienteResponseOriginal = [] as PacienteResponse[];
    this.pacienteService.ObtenerPacientes().subscribe((resp: any) => {
      this.spinnerService.hide();
      if (resp.estado == 1) {
        this.lsPacienteResponseOriginal = resp.lsPacientes;
        let pacienteListaItem;
        for (let ob of this.lsPacienteResponseOriginal) {
          pacienteListaItem = {} as PacienteListaViewModel;
          pacienteListaItem.id = ob.id;
          pacienteListaItem.numeroDocumentoNombre = ob.numeroDocumento + ' ' + ob.nombreCompleto;
          this.lsPacienteListaDB.push(pacienteListaItem);
        }

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
    } else {
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
    } else {
      let campoVal: string = this.numeroDocumentoControl.value;
      if (campoVal.length > 20) {
        this.toastr.info('El valor del campo Numero de Documento No tiene una longitud Correcta');
        return false;
      }
    }

    if (!this.nombreCompletoControl.valid) {
      if (this.nombreCompletoControl.getError('required') != null) {
        this.toastr.info('El valor del campo Nopmbre es obligatorio');
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

    if (!this.especialidadControl.valid) {
      if (this.especialidadControl.getError('required') != null) {
        this.toastr.info('El valor del campo Especialidad es obligatorio');
        return false;
      }
      if (this.especialidadControl.getError('pattern') != null) {
        this.toastr.info('El valor del campo Especialidad tiene caracteres no validos');
        return false;
      }
    } else {
      let campoVal: string = this.especialidadControl.value;
      if (campoVal.length > 80) {
        this.toastr.info('El valor del campo Especialidad No tiene una longitud Correcta');
        return false;
      }
    }

    if (!this.numeroCredencialControl.valid) {
      if (this.numeroCredencialControl.getError('required') != null) {
        this.toastr.info('El valor del campo Numero de Credencial es obligatorio');
        return false;
      }
      if (this.numeroCredencialControl.getError('pattern') != null) {
        this.toastr.info('El valor del campo Numero de Credencial tiene caracteres no validos');
        return false;
      }
    } else {
      let campoVal: string = this.numeroCredencialControl.value;
      if (campoVal.length > 20) {
        this.toastr.info('El valor del campo Numero de Credencial No tiene una longitud Correcta');
        return false;
      }
    }

    if (!this.nombreHospitalControl.valid) {
      if (this.nombreHospitalControl.getError('required') != null) {
        this.toastr.info('El valor del campo Nombre del Hospital es obligatorio');
        return false;
      }
      if (this.nombreHospitalControl.getError('pattern') != null) {
        this.toastr.info('El valor del campo Nombre del Hospital tiene caracteres no validos');
        return false;
      }
    } else {
      let campoVal: string = this.nombreHospitalControl.value;
      if (campoVal.length > 80) {
        this.toastr.info('El valor del campo Nombre del Hospital No tiene una longitud Correcta');
        return false;
      }
    }

    return true;
  }

  private ValidarpacienteIdDBControl(): boolean {
    if (!this.pacienteIdControl.valid) {
      if (this.pacienteIdControl.getError('required') != null) {
        this.toastr.info('Debe elegir un Paciente para poderlo asignar');
        return false;
      }
      if (this.pacienteIdControl.getError('pattern') != null) {
        this.toastr.info('El valor del Paciente elegido no tiene formato correcto');
        return false;
      }
    } else {
      let campoVal: string = this.pacienteIdControl.value;
      if (campoVal == '0' || campoVal == '') {
        this.toastr.info('Es necesario que elija un Paciente para poderlo asignar');
        return false;
      }
    }

    return true;
  }

  ////////////////////******************Eventos*******************//////////////////
  public GuardarClick() {
    this.toastr.clear();
    if (this.ValidarCampos()) {
      let doctorRequest = {} as DoctorRequest;
      doctorRequest.id = 0;
      doctorRequest.tipoDocumentoId = this.tipoDocumentoIdControl.value;
      doctorRequest.numeroDocumento = (this.numeroDocumentoControl.value as string).toLowerCase();
      doctorRequest.nombreCompleto = (this.nombreCompletoControl.value as string).toLowerCase();
      doctorRequest.especialidad = (this.especialidadControl.value as string).toLowerCase();
      doctorRequest.numeroCredencial = (this.numeroCredencialControl.value as string).toLowerCase();
      doctorRequest.nombreHospital = (this.nombreHospitalControl.value as string).toLowerCase();

      doctorRequest.lsPacientes = [] as number[];
      for (let ob of this.lsPacienteResponseAsignados) {
        doctorRequest.lsPacientes.push(ob.id);
      }

      this.spinnerService.show();
      this.doctorService.CrearDoctor(doctorRequest).subscribe((resp: any) => {
        this.spinnerService.hide();
        if (resp.estado == 1) {
          this.toastr.info("Doctor Creado correctamente");
          window.location.reload();
          //this.router.navigateByUrl("doctores");
        } else {
          this.toastr.info('No se logro Crear el Doctor.' + resp.descripcion, "Crear Doctor");
        }
      }, error => {
        this.spinnerService.hide();
        this.toastr.error('Error Servicio=' + error.message, 'Crear Doctor');
      });
    }
  }

  public ExcluirPacienteClick(idPaciente: number) {

    for (let ob of this.lsPacienteResponseAsignados.filter(x => x.id == idPaciente)) {
      let indx = this.lsPacienteResponseAsignados.indexOf(ob);
      this.lsPacienteResponseAsignados.splice(indx, 1);
    }
  }

  public AsignarPacienteClick() {

    if (this.ValidarpacienteIdDBControl()) {
      for (let ob of this.lsPacienteResponseOriginal.filter(x => x.id == this.pacienteIdControl.value)) {
        var arrObj = this.lsPacienteResponseAsignados.filter(x => x.id == ob.id);
        if (arrObj == undefined || arrObj == null || arrObj.length == 0) {
          let pacienteResponsePorAsignarLocal = {} as PacienteResponse;
          pacienteResponsePorAsignarLocal.id = ob.id;
          pacienteResponsePorAsignarLocal.tipoDocumentoId = ob.tipoDocumentoId;
          pacienteResponsePorAsignarLocal.numeroDocumento = ob.numeroDocumento;
          pacienteResponsePorAsignarLocal.nombreCompleto = ob.nombreCompleto;
          pacienteResponsePorAsignarLocal.numeroSeguridadSocial = ob.numeroSeguridadSocial;
          pacienteResponsePorAsignarLocal.codigoPostal = ob.codigoPostal;
          pacienteResponsePorAsignarLocal.telefono = ob.telefono;

          this.lsPacienteResponseAsignados.push(pacienteResponsePorAsignarLocal);
        } else {
          this.toastr.info("El paciente ya se encuentra asignado");
        }
        break;
      }

    }
  }
}
