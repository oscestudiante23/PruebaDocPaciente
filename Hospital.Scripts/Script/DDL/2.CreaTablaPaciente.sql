

use DB_HospitalTest;

create table paciente(
pacienteId bigint identity(1,1) primary key not null,
tipodocumentoId int not null,
pacienteNumeroDocumento varchar(20) not null,
pacienteNombreCompleto varchar(150) not null,
pacienteNumeroSeguridadSocial varchar(50) not null,
pacienteCodigoPostal varchar(20),
pacienteTelefono varchar(12)
);
