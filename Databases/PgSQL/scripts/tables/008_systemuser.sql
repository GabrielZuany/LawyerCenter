create table appdata.systemuser (
	id uuid not null unique,
	email varchar(75) not null unique,
	password varchar(256) not null,
	usertype int not null check (usertype between 1 and 3),
	registrationDate date not null,
	lastUpdate date
);

create index idx_email on appdata.systemuser(email);

insert into appdata.systemuser(id, email, password, usertype, registrationDate, lastUpdate)
values(gen_random_uuid(), 'lawyer@mail.com', 'some_hash', 1, current_date, null);
insert into appdata.systemuser(id, email, password, usertype, registrationDate, lastUpdate)
values(gen_random_uuid(), 'client@mail.com', 'some_hash', 2, current_date, null);