# API para Manutenção de Cadastro de Pessoas

O projeto foi desenvolvido utilizando: 

  - Visual Studio Comununity 2019, Versão 16.7.7 
  - Banco de Dados SQL Server Express
  
### Tecnologias

* [C#](https://docs.microsoft.com/pt-br/dotnet/csharp/) - linguagem de programação
* [.Net Core 3.1](https://docs.microsoft.com/pt-br/dotnet/core/whats-new/dotnet-core-3-1) -  uma plataforma de desenvolvimento de código aberto de uso geral mantida pela Microsoft e pela comunidade .NET
* [Entity Framework Core](https://docs.microsoft.com/pt-br/dotnet/core/whats-new/dotnet-core-3-1) -  mapeador de banco de dados de objeto para .NET
* [SQL Server Express LocalDB](https://docs.microsoft.com/pt-br/sql/database-engine/configure-windows/sql-server-express-localdb?view=sql-server-ver15#description) - recurso do SQL Server Express para utilização de mecanismos de Banco de Dados 
* [Swagger](https://swagger.io/) - uma plataforma para descrição, consumo e visualização de serviços RESTful
* [XUnit](https://xunit.net/) - ferramenta para testes de Unidade 

### Orientações para baixar e executar o projeto 

Clonar o Projeto com usando GIT:
```sh
$ git clone https://github.com/deboradea85/API-Pessoas.git
```
Ou Realizar o Download através do Link abaixo e em seguida, descompactar os arquivos para uma pasta no seu computador:
```sh
$ https://github.com/deboradea85/API-Pessoas/archive/refs/heads/master.zip
```
Executar o projeto - Utilizando Visual Studio
```sh
$ Ao abrir o Visual Studio 2019, 

$ Escolher a opção Open a project or solution, caso tenha clicado em Continue without code

$ Caso o Visual Studio 2019 já esteja aberto, selecionar o menu File, em seguida, selecionar a opção Open, 

$ Em seguida, selecionar a opção Project/Solution

$ Buscar o arquivo Pessoas.API.sln (..\API-Pessoas\Pessoas.API\Pessoas.API.sln)no diretório onde o projeto foi baixado, 

$ Em seguida, clicar em Abrir

$ Clicar no Menu Debug, em seguida, clicar na opção Start Debugging 

$ Ao Iniciar o Projeto pela primeira vez, o Visual Studio irá varificar o Certificado SSL

$ Ao ser perguntado Se deseja confiar no certificado SSL do ASP, clicar em Sim 

$ Ao ser perguntado Se deseja instalar o certificado, clicar em Sim 

$ A página inicial do Swagger será inicializada no navegador Web

$ O Banco de Dados é gerado na primeira inicialização da aplicação

$ A API poderá ser testada a partir da página aberta no navegador, 

$ Escolhendo o método desejado e clicando em Try it Out, informando no campo version o valor 1 

$ Os dados ficam salvos no Banco de Dados: (localdb)\MSSQLLocalDB\Pessoas
```

Testes unitários
```sh
$ Apesar de já existir o projeto de Testes Unitários, o mesmo ainda não foi iniciado, possui apenas uma estrutura inicial.

$ Após finalização de implementação, será possível executá-lo acessando o Menu Test, 

$ Em seguida Test Explorer, clicando no Botão Run All Tests In View
```
