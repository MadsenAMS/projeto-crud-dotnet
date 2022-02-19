# Projeto .NET: APP para Cadastro De Series Em Plataforma (Estilo Netflix)

Projeto para cadastro de séries em aplicativo estilo 'Netflix' com .NET para bootcamp Localiza.

Segue abaixo uma lista das principais modificações e adições feitas ao projeto original apresentado pelo instrutor, e na sequência uma lista de coisas novas que aprendi fazendo o projeto.

### Adições e Modificações Maiores em Relação ao Projeto Original.

- O ID da série agora utiliza um Guid único gerado automaticamente no construtor ao invés de um int passado por parâmetro na instanciação do objeto. 
- Utilizado 'Dictionary' ao invés de 'List' no repositório (IRepository) para possibilitar o retorno por chave (Guid) ao invés de ID (int);
- Criado algorítimo para retornar apenas séries não excluídas num dicionário 'clean' no retorno da função "Dictionary()" do repositório;
- Criado um método "ValidateSerieID" com "TryGetValue" para tratar buscas por séries com código inválido ou por séries excluídas evitando excessões de acesso inválidas em métodos 'void'.
- Lançada exceção para tentativa de acesso a séries inválidas em métodos com return que possam receber parâmetros inválidos para acesso a séries.

### Pequenas Modificações em Relação ao Projeto Original

- Utilizada interpolação na criação do output no método "ToString" da classe "Serie";
- Removidos as entradas "using System" (diretiva de uso desnecessária nessa versão do .NET (CS8019));
- Parte significativa do código traduzida para o inglês.

### O que Aprendi de Novo Fazendo o Projeto

- Utilização do 'Environment.NewLine' ao invés de '\n' para garantir o salto de linha na console de diferentes sistemas operacionais;
- Embora já tenha estudado sobre repositório como 'design pattern', foi a primeira oportunidade de exercitar sua implementação.
