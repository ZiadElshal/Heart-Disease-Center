create database hospital;
use hospital;

create table room
(
	id varchar(5),
	status_room bit,
	primary key (id),
);

create table patient
(
	id int IDENTITY(1,1),
	name varchar(70),
	phone varchar(20),
	address varchar(50),
	sex varchar(10),
	age int,
	bill numeric(10,2),
	id_room varchar(5), 

	primary key (id),
	foreign key (id_room) references room (id)
	on delete cascade,
);

create table staff
(
	id int IDENTITY(1,1),
	ssn varchar(20),
	name varchar(70),
	phone varchar(20),
	address varchar(50),
	sex varchar(10),
	age int,
	password varchar(50),
	position varchar(10),
	primary key (id),
);

create table report
(
	id_staff int,
	id_patient int,
	up_info varchar(100),

	primary key (id_staff, id_patient, up_info),
	foreign key (id_patient) references patient (id)
	on delete cascade,
	foreign key (id_staff) references staff (id)
	on delete cascade,

);
