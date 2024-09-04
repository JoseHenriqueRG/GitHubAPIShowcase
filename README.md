# GitHub API Showcase

## Visão Geral

O **GitHub API Showcase** é um projeto desenvolvido para demonstrar a utilização da API do GitHub, com uma aplicação web e uma API que fornecem informações sobre repositórios e usuários. O projeto é composto por dois componentes principais:

- **GitHubApiShowcase.WebApi**: Um serviço de API que se comunica diretamente com a API do GitHub para buscar e processar dados.
- **GitHubApiShowcase.WebApp**: Uma aplicação web que consome a API para exibir as informações de maneira amigável ao usuário.

## Tecnologias Utilizadas

- **C#**: Linguagem de programação utilizada para o desenvolvimento do backend.
- **ASP.NET Core**: Framework utilizado para construir a Web API.
- **Angular**: Framework utilizado para construir a interface do usuário na aplicação WebApp.
- **Entity Framework Core**: Utilizado para o acesso e manipulação de dados.
- **SQL Server**: Banco de dados utilizado no projeto.
- **GitHub API**: Serviço externo utilizado para obter informações sobre repositórios e usuários.

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

2. **Abra o projeto no Visual Studio**:
   - Abra o arquivo `GitHubApiShowcase.sln` no Visual Studio.

3. **Configuração do Projeto de Inicialização**:
   - No **Solution Explorer**, clique com o botão direito na solução (no topo da árvore de diretórios) e selecione **Propriedades**.
   - No menu lateral, selecione **Propriedades Comuns** e depois **Projeto de Inicialização**.
   - Escolha a opção **Selecionar vários projetos de inicialização**.
   - Na coluna **Ação**:
     - Para `GitHubApiShowcase.WebApi`, marque a opção **Iniciar**.
     - Para `GitHubApiShowcase.WebApp`, marque a opção **Iniciar**.
   - Clique em **Aplicar** e depois em **OK**.

4. **Executar o Projeto**:
   - Pressione **F5** ou clique no botão **Iniciar** no Visual Studio para compilar e executar o projeto.

## Configuração do Banco de Dados

O projeto já inclui o banco de dados necessário, localizado no arquivo `database.mdf`, que está integrado ao projeto. Portanto, não há necessidade de configurar ou instalar um banco de dados separadamente.

## Contribuições

Contribuições são bem-vindas! Sinta-se à vontade para abrir issues ou pull requests.

## Licença

Este projeto está licenciado sob os termos da [MIT License](LICENSE).

## Contato

Para mais informações, entre em contato com [José Henrique](https://github.com/JoseHenriqueRG).
