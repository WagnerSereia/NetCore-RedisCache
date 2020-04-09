clear
@echo ######################################
@echo #Builda os projetos do docker-compose
@echo ######################################
docker-compose -f docker-compose.prod.yml build

@echo ######################################
@echo #Sobe os projetos do docker-compose
@echo ######################################
docker-compose -f docker-compose.prod.yml up --scale serverApi=4