<h2>API Em C# utilizando o .NetCore 6</h2><br />
Essa é uma API de produtos com um crud basico, para fins de estudo pessoal.<br />
Nessa API será utilizado o Docker para criar um container do banco de dados PostgreSql para utilização em localhost.<br />
Será utilizado também o padrão de modelagem DDD com IoC.<br />

Comando do docker utilizado para criar o container:<br />
docker run -d -p 5432:5432 --name postgres -e POSTGRES_PASSWORD=estudoapi postgres
