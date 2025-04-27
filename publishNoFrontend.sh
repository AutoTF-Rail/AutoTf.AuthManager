# This script is used on the server that hosts the auth manager.
dotnet publish -c ReleaseNoFrontend -o out
docker login 172.17.0.3:5001
docker build -f DockerfileNoFrontend -t 172.17.0.3:5001/repository/docker-autotf/autotf.authentikdashboard:latest .
docker push 172.17.0.3:5001/repository/docker-autotf/autotf.authentikdashboard:latest
