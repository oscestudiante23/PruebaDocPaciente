use DB_HospitalTest;

create table tipodocumento(
tipodocumentoId int primary key not null,
tipodocumentoNombreCorto varchar(10) not null,
tipodocumentoNombre varchar(40) not null
)