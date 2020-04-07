# NetCore-RedisCache
Aplicação que utiliza AspNet.Mvc acessando uma api configurada com Cache utilizando o Redis.

O objetivo da aplicação é demonstrar a utilização de cache evitando assim a necessidade de a cada requisição realizar uma consulta em repositorios (Banco, arquivos, etc), sendo esse cache renovado a cada X tempo.

Para usar a aplicação será necessário:
1) Instalar o redis, que pode ser baixado dos links a seguir
  - Imagem Docker
  https://hub.docker.com/_/redis/
Obs.: Atenção para usar a imagem do redis utilizar o comando a seguir, pois é a configuração indicada nas configurações da aplicação.
Para isso abra um terminal de comando ou powershell e digitar o comando a seguir:
	docker run --name redisLabNetCoreCache -d redis

O nome "redisLabNetCoreCache" é o nome configurado em connectionsStrings para indicar a instancia do redis na aplicação.

  - Instalação para windows
  https://github.com/ServiceStack/redis-windows
 
2) Após a instalação do Redis, clone da aplicação, abrir a aplicação no visual Studio e setar o inicio da aplicação como multiplos projetos.
Para realizar essa tarefa, clicar com o botão direito em cima da solução e "Set StartUp Project" e selecionar "Multiple startup projects" deixando na ordem NetCoreCache.Service e NetCoreCache.UI com a action "Start".

3) Após todo o processo rodar o projeto, e se tudo acontecer como esperado a aplicação já estara em funcionamento.

Para avaliar o funcionamento do cache, poderá ir ate a controller AreaController do projeto NetCoreCache.Service e avaliar o funcionamento na linha 40 e linha 45.
Quando passar pela linha 40, significa que esta recuperando os dados em cache e renovado a cada 10 segundos pondendo ser configurado através do código na linha 48
Quando passar pela linha 45, significa que a aplicação batera no Banco de Dados (inicialmente configurado no arquivo json)
