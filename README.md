# NetCore-RedisCache
Aplicação que utiliza AspNet.Mvc acessando uma api configurada com Cache utilizando o Redis.

O objetivo da aplicação é demonstrar a utilização de cache evitando assim a necessidade de a cada requisição realizar uma consulta em repositorios (Banco, arquivos, etc), sendo esse cache renovado a cada X tempo.

Para usar a aplicação será necessário:
Após os ajustes do commit numero 11, o sistema poderá ser rodado atraves do docker, portanto para:

1) Subir a aplicação com toda a infra necessária, abrir o powersheel e executar o arquivo "subirAplicacao.bat"
2) Derrubar toda a infraestrutura e aplicação, abrir o powersheel e executar o arquivo "derrubarAplicacao.bat"

Após todo o processo de subida da aplicação, e se tudo acontecer como esperado, a aplicação já estara em funcionamento e respondendo através do endereço:

http://localhost

Para avaliar o funcionamento do cache, poderá ir ate a controller AreaController do projeto NetCoreCache.Service e avaliar o funcionamento na linha 44 e linha 50.
Na linha 44 o sistema está recuperando os dados em cache
Na linha 50 o sistema esta buscando os dados no Repositorio (nesse caso um arquivo json) e com tempo de expiração de X minutos pondendo ser configurado através do arquivo de configuração appSettings.json da camada de Servicos na linha 15

Após os dados estarem serem colocados em cache, toda requisição será recuperada do cache e somente quando expirar o mesmo será consultado o repositorio novamente.


Obs.: Para rodar a aplicação diretamente no visual studio algumas configurações deverão serem realizadas no appSettings
