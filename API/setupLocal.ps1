docker-compose -f ../Databases\PgSQL\docker-compose.yml up -d

docker rm lc_api_container | docker build -t lc_api_img .

docker run --network host --name lc_api_container -p 5001:5001 -e ASPNETCORE_URLS=http://+:5001 -e ASPNETCORE_ENVIRONMENT=Development lc_api_img
