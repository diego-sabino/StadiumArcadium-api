# StadiumArcadium API
Este é um repositório contendo uma API construída em ASP.NET que fornece informações sobre a banda Red Hot Chili Peppers. A API consome dados de uma base de dados e expõe endpoints para permitir que usuários obtenham informações sobre álbuns, músicas e membros da banda.

## Instalação
Clone este repositório em sua máquina local.
Certifique-se de ter o ASP.NET Core instalado em sua máquina. Você pode baixá-lo em https://dotnet.microsoft.com/download.
Instale as dependências executando dotnet restore na raiz do projeto.
## Uso
Execute o comando dotnet run na raiz do projeto para iniciar a API.
Acesse http://localhost:3001/swagger/index.html para visualizar a documentação da API.
Use um cliente HTTP, como o Postman, para fazer requisições para a API.
Endpoints
A API fornece os seguintes endpoints:

* /api/albums: Retorna uma lista de todos os álbuns do Red Hot Chili Peppers.
* /api/albums/{id}: Retorna informações sobre um álbum específico.
* /api/members: Retorna uma lista de todos os membros do Red Hot Chili Peppers.
* /api/members/{id}: Retorna informações sobre um membro específico.
* /api/songs: Retorna uma lista de todas as músicas do Red Hot Chili Peppers.
* /api/songs/{id}: Retorna informações sobre uma música específica.
## Contribuição
Se você deseja contribuir para o projeto, sinta-se à vontade para fazer um fork do repositório e criar uma pull request com suas alterações. Certifique-se de que seus commits sejam descritivos e que sua contribuição seja útil para o projeto.
