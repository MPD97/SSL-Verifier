docker build -t service.ssl . ;
docker tag service.user mateusz9090/ssl:local ;
docker push mateusz9090/ssl:local