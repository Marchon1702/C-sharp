Musica musica1 = new Musica();
musica1.Nome = "Faroeste Caboclo";
musica1.Artista = "Legião Urbana";
musica1.Duracao = (9 * 60);
musica1.Disponivel = true;

musica1.ExibirInfosDaMusica();

Musica musica2 = new Musica();
musica2.Nome = "Sweet child on mine";
musica2.Artista = "Guns and Roses";
musica2.Duracao = 303; 
musica2.Disponivel = false;

musica2.ExibirInfosDaMusica();

Thread.Sleep(10000);