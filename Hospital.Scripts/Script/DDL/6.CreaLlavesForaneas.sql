
use DB_HospitalTest;

alter table paciente add constraint [FK_paciente-tipodocumento] foreign key(tipodocumentoId) references tipodocumento(tipodocumentoId);
alter table doctor add constraint [FK_doctor_tipodocumento] foreign key(tipodocumentoId) references tipodocumento(tipodocumentoId);
alter table paciente_doctor add constraint [FK_paciente_doctor-paciente] foreign key(pacienteId) references paciente(pacienteId);