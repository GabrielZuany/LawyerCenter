CREATE SCHEMA IF NOT EXISTS appdata;
ALTER DATABASE lawyercenter SET search_path TO appdata;

CREATE SCHEMA IF NOT EXISTS databasebackup AUTHORIZATION lawyercenter_aka_ifood_advogad

CREATE ROLE lc_readonly WITH LOGIN password 'lc_readonly_pwd';
GRANT CONNECT ON DATABASE lawyercenter TO lc_readonly;
GRANT SELECT ON ALL TABLES IN SCHEMA appdata TO lc_readonly;

create table client(
	id uuid primary key not null unique,
	name varchar(50) not null unique,
	cpf varchar(11) not null unique,
	usertype int not null,
	postalcode varchar(8) not null,
	country varchar(12) not null,
	city varchar(12) not null,
	state varchar(2) not null,
	registrationDate date not null,
	lastUpdate date
);

CREATE INDEX idx_client_id ON client(id);

insert into client(id, name, cpf, usertype, postalcode, country, city, state, registrationDate, lastUpdate)
values('004ea55e-d1db-4c68-8002-e2957b81c67b', 'test_user', '16116116111', 1, 'xxxxxxxx', 'Brasil', 'Vitoria', 'ES', current_date, null);

create table lawyerCategory(
	id uuid primary key not null unique,
	typeInt int not null,
	alias varchar(15) not null,
	registrationDate date not null
);

insert into lawyerCategory(id, typeInt, alias, registrationDate)
values('93ecdf50-9cb8-40a2-ab53-7e1b8874fa08', 1, 'Tributário', current_date);


create table lawyer(
	id uuid primary key not null unique,
	name varchar(50) not null unique,
	cpf varchar(11) not null unique,
	professionalId varchar(9) not null unique,
    lawyerCategoryId uuid not null references lawyerCategory(id),
	postalcode varchar(8) not null,
	country varchar(12) not null,
	city varchar(12) not null,
	state varchar(2) not null,
	registrationDate date not null,
	lastUpdate date
);

CREATE INDEX idx_lawyer_id ON lawyer(id);

insert into lawyer(id, name, cpf, professionalId, lawyerCategoryId, postalcode, country, city, state, registrationDate, lastUpdate)
values('e0e1b721-172e-49a2-bdfb-eb2be627ff98', 'test_user', '16116116111', 'UF 999999', '93ecdf50-9cb8-40a2-ab53-7e1b8874fa08', 'xxxxxxxx', 'Brasil', 'Vitoria', 'ES', current_date, null);

create table clientlawyer(
	id uuid primary key not null unique,
	lawyerId uuid references lawyer(id) ,
	clientId uuid references client(id),
	relationCreatedIn date not null
);

CREATE INDEX idx_client ON clientlawyer(clientId);

insert into clientlawyer(id, lawyerId, clientId, relationCreatedIn)
values(gen_random_uuid(), 'e0e1b721-172e-49a2-bdfb-eb2be627ff98', '004ea55e-d1db-4c68-8002-e2957b81c67b', current_date);