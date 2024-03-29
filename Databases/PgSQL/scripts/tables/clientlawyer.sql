create table clientlawyer(
	id uuid primary key not null unique,
	lawyerId uuid references lawyer(id) ,
	clientId uuid references client(id),
	relationCreatedIn date not null
)PARTITION BY HASH (lawyerId);

CREATE INDEX idx_client ON clientlawyer(clientId);

insert into clientlawyer(id, lawyerId, clientId, relationCreatedIn)
values(gen_random_uuid(), 'e0e1b721-172e-49a2-bdfb-eb2be627ff98', '004ea55e-d1db-4c68-8002-e2957b81c67b', current_date);