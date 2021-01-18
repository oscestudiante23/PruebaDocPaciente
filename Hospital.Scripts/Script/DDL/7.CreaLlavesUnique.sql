

use DB_HospitalTest;

alter table paciente add constraint [UN_pacienteNumeroDocumento] unique(pacienteNumeroDocumento)
alter table doctor add constraint [UN_doctorNumeroDocumento] unique(doctorNumeroDocumento)