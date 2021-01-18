
use DB_HospitalTest;

create table paciente_doctor(
pacientedoctorId bigint identity(1,1) primary key not null,
pacienteId bigint not null,
doctorId bigint not null
);

