# MyMovieFinal
Repositório destinado do projeto final MyMovie

Imaginando que você já tenha baixado o projeto, vá até a pasta do mesmo. Lá você encontrará dois folders (MyMovie e MyMovieApi).
Navegue até MyMovieApi e abra no Visual Studio 2017 a solução MyMovieApi.sln.

Com a solução aberta, realize um build para que as dependencias sejam restauradas.
Feito isso, vamos configurar nossa ConnectionString. Abra o arquivo de configuração appsettings.json e você encontrará uma sessão (ConnectionStrings) com uma chave (MyMovie). Substitua o valor da chave "MyMovie" pela string de conexão do seu BD.

Com a ConnectionString do DB Corretamente configurada, abra o Package Manager Console e execute o comando Update-Database para criar a base de dados de acordo com as Migrations.

Volte na pasta raiz do projeto e agora abra o folder MyMovie.
Abra no Visual Studio 2017 a solução MyMovie.sln. Esse é nosso projeto web, basta apenas realizar um build para que as dependencias sejam restauradas.

Com tudo configurado, execute o MyMovie e o MyMovieApi



