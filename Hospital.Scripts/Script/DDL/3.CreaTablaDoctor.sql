
use DB_HospitalTest;

create table doctor (
doctorId bigint identity(1,1) primary key not null,
tipodocumentoId int not null,
doctorNumeroDocumento varchar(20) not null,
doctorNombreCompleto varchar(150) not null,
doctorEspecialidad varchar(80)  not null,
doctorNumeroCredencial varchar(20) not null,
doctorNombreHospital varchar(80) not null
);

