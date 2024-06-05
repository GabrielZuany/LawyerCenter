yay -S dotnet-sdk-7.0
dotnet add package Microsoft.EntityFrameworkCore.Tools --version 7.0
dotnet add package Npgsql.EntityFrameworkCore.PostgreSQL --version 7.0

# docker build . -t api
# docker run -p <out port>:<docker port> -e ASPNETCORE_URLS=http://+:<docker port> -e ASPNETCORE_ENVIRONMENT=<environment> api
# docker run -p 5001:5001 -e ASPNETCORE_URLS=http://+:5001 -e ASPNETCORE_ENVIRONMENT=Development api

docker rm lc_api_container | docker build . -t lc_api_img && docker run --name lc_api_container  -p 5001:5001 -e ASPNETCORE_URLS=http://+:5001 -e ASPNETCORE_ENVIRONMENT=Development lc_api_img