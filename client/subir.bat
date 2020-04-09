docker build -t netcore-cache.ui . -f src\NetCoreCache.UI\Dockerfile.prod
docker run -p 44336:44336 --name netcore-cache.ui netcore-cache.ui