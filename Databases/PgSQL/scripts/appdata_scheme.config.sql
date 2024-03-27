/*
* Creates a schema for the application data and sets the search path to it.
* This is the schema where all the application data will be stored.
*/
CREATE SCHEMA IF NOT EXISTS appdata;
ALTER DATABASE lawyercenter SET search_path TO appdata;