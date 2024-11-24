PodCast podCast1 = new PodCast("Igão e Mítico", "Podpah");

Episodio ep1 = new Episodio("Entrevista com o Thor", 1, 120);
ep1.AdicionarConvidados("Chris Hemsworth");
ep1.AdicionarConvidados("Robert Downey Jr");
podCast1.AdicionarEpisodio(ep1);

Episodio ep3 = new Episodio("24hrs", 5, 45);
podCast1.AdicionarEpisodio(ep3);

Episodio ep2 = new Episodio("Conselhos Amorosos", 2, 134);
podCast1.AdicionarEpisodio(ep2);

podCast1.ExibirDetalhes();

