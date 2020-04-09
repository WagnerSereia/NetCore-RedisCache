@echo ######################################
@echo #Sobe o proxy no nginx
@echo ######################################
docker build -t netcore-cache.proxy . -f nginx\dockerfile.prod


@echo ######################################
@echo #Prepara a imagem do service - API
@echo ######################################
cd server
docker build -t netcore-cache.service . -f Dockerfile.prod
docker run -p 443:443 --name netcore-cache.service netcore-cache.service 
cd..

@echo ######################################
@echo #Prepara a imagem do client - WEB
@echo ######################################
cd client
docker build -t netcore-cache.ui . -f src\NetCoreCache.UI\Dockerfile.prod
docker run -p 44336:44336 --name netcore-cache.ui netcore-cache.ui
cd..

@echo ######################################
@echo #Builda os projetos do docker-compose
@echo ######################################
@echo docker-compose -f docker-compose.prod.yml build

@echo ######################################
@echo #Sobe os projetos do docker-compose
@echo ######################################
@echo docker-compose -f docker-compose.prod.yml up --scale serverApi=4