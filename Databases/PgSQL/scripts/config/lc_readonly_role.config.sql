/*
* Database: lawyercenter
* User: lc_readonly
* Password: lc_readonly_pwd
* Schema: appdata
* Permissions: Connect and Select (read-only)
*/
CREATE ROLE lc_readonly WITH LOGIN password 'lc_readonly_pwd';
GRANT CONNECT ON DATABASE lawyercenter TO lc_readonly;
GRANT SELECT ON ALL TABLES IN SCHEMA appdata TO lc_readonly;