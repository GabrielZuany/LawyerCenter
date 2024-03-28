create table client(
	id uuid primary key not null unique,
	name varchar(50) not null unique,
	usertype int not null,
	postalcode varchar(8) not null,
	country varchar(12) not null,
	city varchar(12) not null,
	state varchar(2) not null,
	registrationDate date not null,
	lastUpdate date
);

ALTER TABLE client CREATE INDEX idx_client_id ON client(id);

insert into client(id, name, usertype, postalcode, country, city, state, registrationDate, lastUpdate)
-- values(gen_random_uuid(), 'test_user', 1, 'xxxxxxxx', 'Brasil', 'Vitoria', 'ES', current_date, null);
values('004ea55e-d1db-4c68-8002-e2957b81c67b', 'test_user', 1, 'xxxxxxxx', 'Brasil', 'Vitoria', 'ES', current_date, null);
