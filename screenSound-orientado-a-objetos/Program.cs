//Musica musica1 = new Musica();
//musica1.Nome = "Faroeste Caboclo";
//musica1.Artista = "Legião Urbana";
//musica1.Duracao = (9 * 60);
//musica1.Disponivel = true;

//musica1.ExibirInfosDaMusica();

//Musica musica2 = new Musica();
//musica2.Nome = "Sweet child on mine";
//musica2.Artista = "Guns and Roses";
//musica2.Duracao = 303; 
//musica2.Disponivel = false;

//musica2.ExibirInfosDaMusica();

Musica faroesteCaboclo = new Musica();
faroesteCaboclo.Artista = "Legião Urbana";
faroesteCaboclo.Duracao = (9 * 60);
faroesteCaboclo.Disponivel = true;
faroesteCaboclo.Nome = "Faroeste Caboclo";

Musica eduardoEMonica = new Musica();
eduardoEMonica.Artista = "Legião Urbana";
eduardoEMonica.Duracao = (231);
eduardoEMonica.Disponivel = true;
eduardoEMonica.Nome = "Eduardo e Mônica";

Album albumDoLegiaoUrbana = new Album();
albumDoLegiaoUrbana.AdicionarMusica(faroesteCaboclo);
albumDoLegiaoUrbana.AdicionarMusica(eduardoEMonica);

albumDoLegiaoUrbana.ListarMusicas();
Thread.Sleep(5000);