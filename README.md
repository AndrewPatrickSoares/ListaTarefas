# Projeto Tarefas

## Visão Geral

O projeto **Tarefas** é uma aplicação web desenvolvida com ASP.NET Web Forms, destinada à gestão de tarefas. Permite aos usuários criar, editar, excluir e visualizar tarefas, com funcionalidades de validação e interatividade melhoradas através de JavaScript e CSS. Utiliza MySQL como banco de dados para persistência de dados.

## Estrutura do Projeto

### Pastas e Arquivos

#### `App`

A pasta `App` contém a lógica principal do projeto, dividida em subpastas para organização do código.

- **`App_Assets`**
    
    - **`Css`**
        - `Default.css`: Define estilos para a página principal (`Default.aspx`). Inclui regras para cabeçalhos, truncamento de texto, e status visual das tarefas.
        - `Adicionar.css`: Contém estilos específicos para a página de adicionar/editar tarefas (`Adicionar.aspx`), como estilos para títulos e descrições.
    - **`Img`**
        - `Task.jpeg`: Imagem utilizada no backgroud para as páginas.
    - **`Js`**
        - `Default.js`: Scripts para a página principal (`Default.aspx`). Inclui manipulação de eventos para expandir/retrair títulos e descrições truncados e para a exclusão de tarefas com a biblioteca SweetAlert.
        - `Adicionar.js`: Scripts para a página de adicionar/editar tarefas (`Adicionar.aspx`). Utiliza SweetAlert para exibir mensagens de erro em caso de falhas de validação ao adicionar ou editar tarefas.
    
- **`App_Models`**
    
    - `Tarefa.cs`: Define o modelo de dados para uma tarefa com as propriedades `Tarefa_id`, `Titulo`, `Descricao`, `Feito`, e `Desfeito`. É usado para mapear as tarefas no banco de dados.
- **`App_Repo`**
    
    - **`ITarefaRepo.cs`**: Interface que define os métodos para operações CRUD em tarefas, como `TodasTarefas`, `Tarefa_id`, `AdicionarTarefa`, `AtualizarTarefa`, e `ExcluirTarefa`.
    - **`TarefaRepo.cs`**: Implementação da interface `ITarefaRepo`. Fornece a lógica para acessar e manipular dados no banco de dados MySQL, incluindo a verificação de tarefas existentes e operações CRUD.
- **`App_Services`**
    
    - **`ITarefaServices.cs`**: Interface que define os métodos para a lógica de negócios relacionada a tarefas, como marcar tarefas como feitas ou desfeitas e obter todas as tarefas.
    - **`TarefaServices.cs`**: Implementação da interface `ITarefaServices`. Contém a lógica de negócios para marcar tarefas como feitas ou desfeitas e para obter todas as tarefas, utilizando o repositório `TarefaRepo`.


### Páginas Web

- **`Default.aspx`**
    
    - Página inicial do aplicativo que lista todas as tarefas em uma `GridView`. Permite edição e exclusão de tarefas. Utiliza o `Default.css` para estilos e `Default.js` para scripts de interação.
    - O código-behind (`Default.aspx.cs`) é responsável por carregar e exibir as tarefas, bem como tratar os eventos de exclusão e edição de tarefas.
- **`Adicionar.aspx`**
    
    - Página para adicionar ou editar tarefas. Utiliza `Adicionar.css` para estilos específicos e `Adicionar.js` para validação e exibição de mensagens de erro.
    - O código-behind (`Adicionar.aspx.cs`) lida com a lógica para adicionar novas tarefas ou atualizar tarefas existentes, incluindo a validação dos dados inseridos.

## Configuração do Banco de Dados

- **Banco de Dados**: MySQL
- **Nome da Base de Dados**: ListaTarefas
- **Tabela**: `TB_TAREFAS`
    - **Colunas**:
        - `TAREFA_ID`: Identificador da tarefa (chave primária)
        - `TITULO`: Título da tarefa
        - `DESCRICAO`: Descrição da tarefa
        - `FEITO`: Indica se a tarefa está concluída (booleano)
        - `DESFEITO`: Indica se a tarefa está marcada como não concluída (booleano)

## Funcionalidades

1. **CRUD de Tarefas**:
    
    - **Criar**: Adiciona uma nova tarefa à lista.
    - **Ler**: Visualiza todas as tarefas na página principal.
    - **Atualizar**: Edita uma tarefa existente.
    - **Excluir**: Remove uma tarefa da lista.
2. **Validações**:
    
    - Impede a criação de tarefas com títulos em branco ou repetidos.
3. **Interatividade**:
    
    - Utiliza SweetAlert para confirmar a exclusão de tarefas e para exibir mensagens de erro na adição/edição de tarefas.
    - Scripts JavaScript para manipulação de eventos na página, como expansão/retratação de texto.

## Dependências

- As seguintes bibliotecas e frameworks são utilizados e estão referenciados diretamente nas páginas HTML:

- **Bootstrap**: Framework CSS para estilização.
- **Font Awesome**: Ícones para representar status das tarefas.
- **jQuery**: Biblioteca JavaScript para manipulação de DOM e eventos.
- **SweetAlert**: Biblioteca para exibição de alertas estilizados.
