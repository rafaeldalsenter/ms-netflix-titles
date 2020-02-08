# ms-netflix-titles

🎞 Microservice para consulta de base de dados do Netflix

Base de dados obtida no [Kaggle](https://www.kaggle.com/shivamb/netflix-shows/data#)

Esse Microservice foi criado para a série de artigos [Criando um microservice de alta disponibilidade em C# com banco de dados NoSQL](https://rafaeldalsenter.github.io/csharp/cassandra/aws/2020/01/19/microservice-alta-disponibilidade-1.html), onde demonstro desde a instalação do banco de dados Cassandra, a criação deste MS para leitura e escrita nele, e posteriormente a publicação dos mesmos na AWS e configurações de escalabilidade.

Projetos da Solution:
- Domain: Classe de domínio e Builder da mesma.
- Application: Classes de serviço (montagem do domínio e inserção no banco de dados) e repositório (leitura do banco de dados).
- CrossCutting: Classes que podem ser utilizadas em qualquer camada, extensões, objetos Dto e conexão com o banco Cassandra.
- Api: Controller para acesso as funções. Implementado Swagger para facilitar os testes.

| CodeFactor |
|:---:|
|[![CodeFactor](https://www.codefactor.io/repository/github/rafaeldalsenter/ms-netflix-titles/badge)](https://www.codefactor.io/repository/github/rafaeldalsenter/ms-netflix-titles)|
