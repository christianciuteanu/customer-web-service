---Create dabases---
CREATE DATABASE "Dell.Customers"
    WITH 
    OWNER = postgres
    ENCODING = 'UTF8'
    LC_COLLATE = 'English_United States.1252'
    LC_CTYPE = 'English_United States.1252'
    TABLESPACE = pg_default
    CONNECTION LIMIT = -1;


---Enable extension for auto generating uuid at insert---
CREATE EXTENSION IF NOT EXISTS "uuid-ossp";

---Create Customer table---
CREATE TABLE public."Customer"
(
    "Id" uuid NOT NULL DEFAULT uuid_generate_v1(),
    "Name" text COLLATE pg_catalog."default" NOT NULL,
    "Email" text COLLATE pg_catalog."default" NOT NULL,
    CONSTRAINT customer_pkey PRIMARY KEY ("Id")
)
WITH (
    OIDS = FALSE
)
TABLESPACE pg_default;

ALTER TABLE public."Customer"
    OWNER to postgres;