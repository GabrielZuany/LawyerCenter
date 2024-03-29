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