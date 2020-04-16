clear
@echo ######################################
@echo #Para todas os Containers da Aplicação
@echo ######################################
docker stop netcore-rediscache_client_1
docker stop netcore-rediscache_serverApi_1
docker stop netcore-rediscache_serverApi_2
docker stop netcore-rediscache_serverApi_3
docker stop netcore-rediscache_serverApi_4
docker stop netcore-rediscache_netcore-cache.redis_1
docker stop netcore-cache.proxy:prod

@echo ######################################
@echo #Remove os Containers da Aplicação
@echo ######################################
docker rm netcore-rediscache_client_1
docker rm netcore-rediscache_serverApi_1
docker rm netcore-rediscache_serverApi_2
docker rm netcore-rediscache_serverApi_3
docker rm netcore-rediscache_serverApi_4
docker rm netcore-rediscache_nginx_1
@echo docker rm netcore-rediscache_netcore-cache.redis_1 

@echo ######################################
@echo #Remove as Imagens da Aplicação
@echo ######################################
docker rmi netcore-cache.service:prod
docker rmi netcore-cache.ui:prod
docker rmi netcore-cache.proxy:prod
