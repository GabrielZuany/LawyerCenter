yay -S dotnet-sdk-7.0
dotnet add package Microsoft.EntityFrameworkCore.Tools --version 7.0
dotnet add package Npgsql.EntityFrameworkCore.PostgreSQL --version 7.0

sudo docker rm lc_api_container | docker build . -t lc_api_img && docker run --network host --name lc_api_container -p 5001:5001 -e ASPNETCORE_URLS=http://+:5001 -e ASPNETCORE_ENVIRONMENT=Development lc_api_img