using System;

namespace Revisao
{
    class Program
    {
        static void Main(string[] args)
        {
            Aluno[] alunos = new Aluno[5];
            var indiceAluno = 0;
            string opcaoUsuario = ObterOpcaoUsusario();

            while (opcaoUsuario.ToUpper() != "X")
            {
                switch (opcaoUsuario)
                {
                    case "1":
                        Console.WriteLine("Informe o nome do aluno:");
                        Aluno aluno = new Aluno();
                        aluno.Nome = Console.ReadLine();

                        Console.WriteLine("Informe a nota do aluno: ");
                        if (decimal.TryParse(Console.ReadLine(), out decimal nota))
                        {
                            aluno.Nota = nota;
                        }
                        else
                        {
                            throw new ArgumentException("Valor da nota deve ser decimal");
                        }

                        alunos[indiceAluno] = aluno;
                        indiceAluno++;

                        break;
                    case "2":
                        foreach (var a in alunos)
                        {
                            if (string.IsNullOrEmpty(a.Nome))
                            { Console.WriteLine($"Aluno: {a.Nome} - NOTA: {a.Nota}"); }
                        };
                        break;
                    case "3":
                        decimal notaTotal = 0;
                        var nrAlunos = 0;
                        for (int i = 0; i < alunos.Length; i++)
                        {
                            if (string.IsNullOrEmpty(alunos[i].Nome))
                            {
                                notaTotal = notaTotal + alunos[i].Nota;
                                nrAlunos++;
                            };

                            var mediaGeral = notaTotal / nrAlunos;
                            ConceitoEnum conceitoGeral;
                            if (mediaGeral < 4)
                            {
                                conceitoGeral = ConceitoEnum.E;

                            }
                            else if (mediaGeral < 5)
                            {
                                conceitoGeral = ConceitoEnum.D;

                            }
                            else if (mediaGeral < 7)
                            {
                                conceitoGeral = ConceitoEnum.C;

                            }
                            else if (mediaGeral < 8)
                            {
                                conceitoGeral = ConceitoEnum.B;

                            }
                            else
                            {
                                conceitoGeral = ConceitoEnum.A;

                            }

                            Console.WriteLine($"MÉDIA GERAL: {mediaGeral} - CONCEITO: {conceitoGeral}");

                        }
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
                opcaoUsuario = ObterOpcaoUsusario();
            }
        }

        private static string ObterOpcaoUsusario()
        {
            Console.WriteLine("Informe a opção desejada: ");
            Console.WriteLine("1 - Inserir novo Aluno");
            Console.WriteLine("2 - Listar Alunos");
            Console.WriteLine("3 - calcular média geral");
            Console.WriteLine("X - Sair");
            Console.WriteLine();

            string opcaoUsuario = Console.ReadLine();
            Console.WriteLine();
            return opcaoUsuario;
        }
    }
}
