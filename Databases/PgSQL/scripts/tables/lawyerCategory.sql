create table lawyerCategory(
	id uuid primary key not null unique,
	typeInt int not null,
	alias varchar(15) not null,
	registrationDate date not null
);

insert into lawyerCategory(id, typeInt, alias, registrationDate)
values(gen_random_uuid(), 1, 'Tributário', current_date);