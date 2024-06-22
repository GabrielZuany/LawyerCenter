# Script to initialize the application -> Port forwarding, and docker-compose up

sudo ssh -f -N -L 5432:localhost:5432 -i /home/zuany/Desktop/dev/auth/oracle/sudo/ssh-rsa-30-03-2024.key ubuntu@168.138.151.184

sudo docker rm lc_api_container | docker build . -t lc_api_img && docker run --network host --name lc_api_container -p 5001:5001 -e ASPNETCORE_URLS=http://+:5001 -e ASPNETCORE_ENVIRONMENT=Development lc_api_img