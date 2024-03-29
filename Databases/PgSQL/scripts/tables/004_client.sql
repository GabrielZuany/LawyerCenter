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
