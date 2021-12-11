<h2>API Em C# utilizando o .NetCore 6</h2><br />
Essa é uma API de produtos com um crud basico, para fins de estudo.<br />
Nessa API será utilizado o Docker para criar um container do banco de dados PostgreSql para utilização em localhost.<br />
Para mapear os objetos com as entidades do banco de dados, será utilizado o Entity Framework Core 6.<br />
Para este projeto será utilizado também o padrão de modelagem DDD com IoC.<br /><br />

Para a utilização do docker, está sendo utilizado uma virtualização do sistema do Fedora na VirtualBox.<br />
Comando do docker utilizado para criar o container:<br />
docker run -d -p 5432:5432 --name postgres -e POSTGRES_PASSWORD=estudoapi -e POSTGRES_USER=estudoapi postgres
