# GitHub API Showcase

## Visão Geral

O **GitHub API Showcase** é um projeto desenvolvido para demonstrar a utilização da API do GitHub, com uma aplicação web e uma API que fornecem informações sobre repositórios e usuários. O projeto é composto por dois componentes principais:

- **GitHubApiShowcase.WebApi**: Um serviço de API que se comunica diretamente com a API do GitHub para buscar e processar dados.
- **GitHubApiShowcase.WebApp**: Uma aplicação web que consome a API para exibir as informações de maneira amigável ao usuário.

## Tecnologias Utilizadas

- **C#**: Linguagem de programação utilizada para o desenvolvimento do backend.
- **ASP.NET Core**: Framework utilizado para construir a Web API.
- **React**: Framework utilizado para construir a interface do usuário na aplicação App.
- **Entity Framework Core**: Utilizado para o acesso e manipulação de dados.
- **SQL Server**: Banco de dados utilizado no projeto.
- **GitHub API**: Serviço externo utilizado para obter informações sobre repositórios e usuários.
- **Docker**: Container e orquestração de containers.

## Funcionalidades

- Exibição de informações sobre repositórios públicos do GitHub.
- Pesquisa por usuários do GitHub e exibição de seus repositórios.
- Exibição de detalhes específicos de um repositório selecionado.

## Requisitos

- **Visual Studio 2022** ou superior.
- **.NET 6.0 SDK** ou superior.
- **SQL Server** (local ou remoto).

## Instruções para Executar o Projeto

Siga as etapas abaixo para inicializar o projeto:

1. **Clone o repositório**:
    ```bash
    git clone https://github.com/JoseHenriqueRG/GitHubAPIShowcase.git
    cd GitHubAPIShowcase
    ```

2. **Configuração do Projeto**

- Abra o terminal na raiz do projeto `GitHubAPIShowcase` e execute o seguinte comando: `docker-compose up --build`. Certifique-se de que o Docker está instalado.
- Após a conclusão do comando, verifique se ambos os containers (SQL Server e `githubapishowcasewebapi`) estão em execução.
- Em seguida, abra outro terminal, navegue até a pasta `.\githubapishowcase.app\` e execute o comando `npm start` para iniciar o projeto React.

## Contribuições

Contribuições são bem-vindas! Sinta-se à vontade para abrir issues ou pull requests.

## Licença

Este projeto está licenciado sob os termos da [MIT License](LICENSE).

## Contato

Para mais informações, entre em contato com [José Henrique](https://github.com/JoseHenriqueRG).
