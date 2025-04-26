# This script is used on the server that hosts the auth manager.
dotnet publish -c Release -o out
docker login 172.17.0.3:5001
docker build -t 172.17.0.3:5001/repository/docker-autotf/AutoTf.AuthManager:latest .
docker push 172.17.0.3:5001/repository/docker-autotf/AutoTf.AuthManager:latest
