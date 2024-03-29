create table lawyerCategory(
	id uuid primary key not null unique,
	typeInt int not null,
	alias varchar(15) not null,
	registrationDate date not null
);

insert into lawyerCategory(id, typeInt, alias, registrationDate)
values('93ecdf50-9cb8-40a2-ab53-7e1b8874fa08', 1, 'Tributário', current_date);