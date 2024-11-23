// Modelar o sistema de uma escola. Crie classes para Aluno, Professor e Disciplina. A classe Aluno deve ter informações como nome, idade e notas. A classe Professor deve ter informações sobre nome e disciplinas lecionadas. A classe Disciplina deve armazenar o nome da disciplina e a lista de alunos matriculados.

Aluno alunoJaime = new Aluno();
alunoJaime.Nome = "Jaime";
alunoJaime.Idade = 14;
alunoJaime.Notas = new List<double> { 9.6 , 7.5, 7.8, 8.0 };

Aluno alunoMaik = new Aluno();
alunoMaik.Nome = "Maik";
alunoMaik.Idade = 15;
alunoMaik.Notas = new List<double> { 9.6, 7.5, 7.8, 8.0 };

Disciplina disciplinaMatematica =  new Disciplina();
disciplinaMatematica.Nome = "Matemáica";
disciplinaMatematica.AlunosMatriculados = new List<Aluno> { alunoJaime, alunoMaik};

Professor professorCarter = new Professor();
professorCarter.Nome = "Carter";
professorCarter.DisciplinasLecionadas = new List<Disciplina> { disciplinaMatematica }; 