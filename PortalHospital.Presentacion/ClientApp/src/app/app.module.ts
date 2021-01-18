import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';

import { MatCardModule } from '@angular/material/card';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatToolbarModule, MatMenuModule } from '@angular/material';
import { MatInputModule } from '@angular/material/input';
import { MatButtonModule } from '@angular/material/button';
import { MatSidenavModule } from '@angular/material/sidenav';
import { MatSelectModule } from '@angular/material/select';
import { MatDialogModule } from '@angular/material/dialog';
import { MatTabsModule } from '@angular/material/tabs';
import { MatListModule } from '@angular/material/list';
import { MatIconModule } from '@angular/material/icon';
import { MatTooltipModule } from '@angular/material/tooltip';
import { MatCheckboxModule } from '@angular/material/checkbox';

import { HomeComponent } from './home/home.component';
import { CounterComponent } from './counter/counter.component';
import { FetchDataComponent } from './fetch-data/fetch-data.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';


import { NgxSpinnerModule } from "ngx-spinner";
import { ToastrModule } from 'ngx-toastr';

import { DoctorconsultarComponent } from './doctor/doctorconsultar/doctorconsultar.component';
import { PacienteconsultarComponent } from './paciente/pacienteconsultar/pacienteconsultar.component';
import { DoctorcrearComponent } from './doctor/doctorcrear/doctorcrear.component';
import { DoctorconsultardetalleComponent } from './doctor/doctorconsultardetalle/doctorconsultardetalle.component';
import { PacientecrearComponent } from './paciente/pacientecrear/pacientecrear.component';
import { PacientemodificarComponent } from './paciente/pacientemodificar/pacientemodificar.component';
import { PacientemoddetalleComponent } from './paciente/pacientemoddetalle/pacientemoddetalle.component';
import { PacienteeliminarComponent } from './paciente/pacienteeliminar/pacienteliminar.component';
import { PacienteconsultardetalleComponent } from './paciente/pacienteconsultardetalle/pacienteconsultardetalle.component';


@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    CounterComponent,
    FetchDataComponent,
    DoctorconsultarComponent,
    PacienteconsultarComponent,
    DoctorcrearComponent,
    DoctorconsultardetalleComponent,
    PacientecrearComponent,
    PacientemodificarComponent,
    PacientemoddetalleComponent,
    PacienteeliminarComponent,
    PacienteconsultardetalleComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    ReactiveFormsModule,
    MatCardModule,
    MatFormFieldModule,
    MatMenuModule,
    MatToolbarModule,
    MatInputModule,
    MatButtonModule,
    MatSidenavModule,
    MatSelectModule,
    MatDialogModule,
    MatTabsModule,
    MatListModule,
    MatIconModule,
    MatTooltipModule,
    MatCheckboxModule,

    NgxSpinnerModule,
    ToastrModule.forRoot(),

    FormsModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      //{ path: 'counter', component: CounterComponent },
      //{ path: 'fetch-data', component: FetchDataComponent },
      { path: 'doctores', component: DoctorconsultarComponent },
      { path: 'doctordetalle/:id', component: DoctorconsultardetalleComponent },
      { path: 'doctorcrear', component: DoctorcrearComponent },
      { path: 'pacientes', component: PacienteconsultarComponent },
      { path: 'pacientecrear', component: PacientecrearComponent },
      { path: 'pacientemodificar', component: PacientemodificarComponent },
      { path: 'pacientemodificardet/:id', component: PacientemoddetalleComponent },
      { path: 'pacienteconsultardet/:id', component: PacienteconsultardetalleComponent },
      { path: 'pacienteeliminar', component: PacienteeliminarComponent },

    ]),
    BrowserAnimationsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
