docker build -t netcore-cache.service . -f Dockerfile.prod
docker run -p 443:443 --name netcore-cache.service netcore-cache.service 