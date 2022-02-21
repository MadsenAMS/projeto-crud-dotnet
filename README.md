# Projeto .NET: APP para Cadastro De Series Em Plataforma

Projeto praticar a implementação de um 'CRUD' rudimentar para administração de séries em uma plataforma utilizando C#.

Segue abaixo uma lista das principais modificações e adições feitas ao projeto original apresentado pelo instrutor, e na sequência uma lista de coisas novas que aprendi fazendo o projeto.

### Adições e Modificações Maiores em Relação ao Projeto Original.

- O ID da série agora utiliza um Guid único gerado automaticamente no construtor ao invés de um int passado por parâmetro na instanciação do objeto;
- Utilizado 'Dictionary' ao invés de 'List' no repositório (IRepository) para possibilitar o retorno por chave (Guid) ao invés de ID (int);
- Criado algorítimo para retornar apenas séries não excluídas num dicionário 'clean' no retorno da função "Dictionary()" do repositório;
- Criado um método "ValidateSerieID" com "TryGetValue" para tratar buscas por séries com código inválido ou por séries excluídas evitando excessões de acesso inválidas em alguns métodos.
- Lançada exceção para tentativa de acesso a séries inválidas em métodos com return que possam receber parâmetros inválidos para acesso a séries;
- Criados métodos para agregar código repetitivo: EndQuery (Insere texto na console informando fim da query), InvalidInput (informa presença de input inválido ao usuário), CheckID(confere se a ID ou Titulo inserido em uma busca corresponde a uma série de fato);
- Criado mecanismo para busca da série por nome ou ID, facilitando a busca para exclusão, edição e exibição;
- A opção "ClearConsole" foi removida do menu, e a limpeza de console foi imbuída no fluxo do programa em pontos de necessidade;

### Pequenas Modificações em Relação ao Projeto Original

- Utilizada interpolação na criação do output no método "ToString" da classe "Serie";
- Removidos as entradas "using System" (diretiva de uso desnecessária nessa versão do .NET (CS8019));
- Parte significativa do código traduzida para o inglês.

### O que Aprendi de Novo Fazendo o Projeto

- Utilização do 'Environment.NewLine' ao invés de '\n' para garantir o salto de linha na console de diferentes sistemas operacionais;
- Embora já tenha estudado sobre repositório como 'design pattern', foi a primeira oportunidade de exercitar sua implementação.

### Considerações Finais
  
- Embora a utilização do "Dictionary" ao invés da "List" não fosse necessária, e nem fosse necessariamente uma opção melhor para lidar com os dados em questão, não havia tido oportunidade de trabalhar com o Dictionary até o momento, então optei por utilizá-lo para fins de prática. Fiquei impressionado com a quantidade de modificações de código decorrentes de uma decisão simples acerca da estrutura de dados utilizada. 
- Cogitei extrair classes adicionais da class "Program.cs" de maneira a tornar o código desta classe mais limpo, mas sob o risco de criar classes redundantes. Por exemplo, já havia a classe "SerieRepository" com métodos enxutos para manipulação mais objetiva dos dados... Mas as funções de "Program.cs" que chamam estes métodos ficaram volumosas no código, inclusive devido às tratativas de exceções. Achei que talvez valesse apena extrair estas funções, mas realmente havia risco de ter dois códigos com responsabilidades muito semelhantes. Acredito que as demandas de um projeto real ajudariam a definir a preferência pela extração destas funções, ou a manutenção delas no corpo principal do app. 
