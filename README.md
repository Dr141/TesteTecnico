## Teste Técnico - Desenvolvedor Backend Junior
### 1. Configuração:
- No arquivo appsettings.json, preencher a string de conexão do DB Postgres. Para o sistema conseguir conectar na base de dados e executar as migrations.
## Métodos
### 1. Get:
- Retornar todos os produtos cadastrados.
### 2. Get/id:
- Retornar o produto com id fornecido.
### 3. Post:
- Cadastra um novo produto.
### 4. Put/id:
- Atualiza um produto.
### 5. Delete/id:
- Apaga um produto. 
## Perguntas
### 1. Quais princípios SOLID foram usados? Qual foi o motivo da escolha deles?
- R: Single Responsiblity Principle - por facilitar a implementação de testes de unidade.
### 2. Dado um cenário que necessite de alta performance, cite 2 locais possíveis de melhorar a performance da API criada e explique como seria a implementação desta melhoria.
- R1: Realizaria melhorias no método Get para trazer as informações em partes usando Take() e Skip(). Pois muitas vezes não há necessidade de trazer todas informações de uma só vez.
- R2: Separaria a autenticação para outra APIRest, visto que seria possivel usar o mesmo método de auteticação em diversos sistema ou mini APis e assim manter o padrão.
