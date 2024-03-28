create table lawyer(
	id uuid primary key not null unique,
	name varchar(50) not null unique,
	professionalId varchar(9) not null unique,
    lawyerCategoryId uuid not null references lawyerCategory(id),
	postalcode varchar(8) not null,
	country varchar(12) not null,
	city varchar(12) not null,
	state varchar(2) not null,
	registrationDate date not null,
	lastUpdate date
)PARTITION BY HASH(lawyerCategoryId); -- partition by lawyerCategoryId to improve query performance when filtering by lawyerCategoryId

ALTER TABLE lawyer CREATE INDEX idx_lawyer_id ON lawyer(id); -- number of lawyers is small, so we can use hash partitioning

insert into lawyer(id, name, professionalId, postalcode, country, city, state, registrationDate, lastUpdate)
values('e0e1b721-172e-49a2-bdfb-eb2be627ff98', 'test_user', 'UF 999999', gen_random_uuid(), 'xxxxxxxx', 'Brasil', 'Vitoria', 'ES', current_date, null);