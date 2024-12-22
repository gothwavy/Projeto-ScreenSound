namespace Screen_Sound
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Screen Sound

            Dictionary<string, List<int>> bandasRegistradas = new Dictionary<string, List<int>>()
            {
                { "Linkin Park", new List<int>() },
                { "Iron Maiden", new List<int> { 7 } },
                { "Nirvana", new List<int> { 7, 9, 9, 0, 1 } }
            };

            ExibirOpcoesDoMenu();

            void ExibirMensagemDeBoasVindas()
            {
                Console.WriteLine(@"
                ░██████╗░█████╗░██████╗░███████╗███████╗███╗░░██╗  ░██████╗░█████╗░██╗░░░██╗███╗░░██╗██████╗░
                ██╔════╝██╔══██╗██╔══██╗██╔════╝██╔════╝████╗░██║  ██╔════╝██╔══██╗██║░░░██║████╗░██║██╔══██╗
                ╚█████╗░██║░░╚═╝██████╔╝█████╗░░█████╗░░██╔██╗██║  ╚█████╗░██║░░██║██║░░░██║██╔██╗██║██║░░██║
                ░╚═══██╗██║░░██╗██╔══██╗██╔══╝░░██╔══╝░░██║╚████║  ░╚═══██╗██║░░██║██║░░░██║██║╚████║██║░░██║
                ██████╔╝╚█████╔╝██║░░██║███████╗███████╗██║░╚███║  ██████╔╝╚█████╔╝╚██████╔╝██║░╚███║██████╔╝
                ╚═════╝░░╚════╝░╚═╝░░╚═╝╚══════╝╚══════╝╚═╝░░╚══╝  ╚═════╝░░╚════╝░░╚═════╝░╚═╝░░╚══╝╚═════╝░
                ");
                Console.WriteLine("\nBoas vindas ao Screen Sound!");
            }

            void ExibirOpcoesDoMenu()
            {
                Console.Clear();

                ExibirMensagemDeBoasVindas();

                Console.WriteLine("\nDigite 1 para registrar uma banda");
                Console.WriteLine("Digite 2 para mostrar todas as bandas");
                Console.WriteLine("Digite 3 para avaliar uma banda");
                Console.WriteLine("Digite 4 para exibir a media de uma banda");
                Console.WriteLine("Digite -1 para sair");

                Console.Write("\nDigite a sua opcao: ");
                int opcaoEscolhida = Convert.ToInt32(Console.ReadLine());

                Console.Clear();

                switch (opcaoEscolhida)
                {
                    case 1:
                        RegistrarBanda();
                        break;

                    case 2:
                        ConsultarBandas();
                        break;

                    case 3:
                        AvaliarBanda();
                        break;

                    case 4:
                        MediaBanda();
                        break;

                    case -1:
                        Console.WriteLine($"Tchau tchau! ;)");
                        break;

                    default:
                        Console.WriteLine("Opcao invalida!");
                        break;
                }
            }

            void RegistrarBanda()
            {
                ExibirTituloOpcoes("Registrando banda");

                Console.Write("Digite o nome da banda que voce deseja registrar: ");
                string novaBanda = Console.ReadLine()!;

                bandasRegistradas.Add(novaBanda, new List<int>());
                Console.WriteLine($"\nA banda {novaBanda} foi registrada com sucesso!");

                Thread.Sleep(3000);

                ExibirOpcoesDoMenu();
            }

            void ConsultarBandas()
            {
                ExibirTituloOpcoes("Consultando bandas");

                foreach (var banda in bandasRegistradas)
                {
                    Console.WriteLine($"\nBanda: {banda.Key}");
                    Console.Write("Notas da banda: ");
                    foreach (var nota in banda.Value)
                    {
                        Console.Write($"{nota} ");
                    }
                }

                Console.WriteLine("\nPressione qualquer tecla para voltar ao menu principal!");
                Console.ReadKey();

                ExibirOpcoesDoMenu();
            }

            void AvaliarBanda()
            {
                // Digite qual banda deseja avaliar
                ExibirTituloOpcoes("Avaliando Bandas");
                Console.Write("Digite o nome da banda que deseja avaliar: ");
                string nomeBanda = Console.ReadLine()!;

                // Banda existe? >> Atribuir nota
                if (bandasRegistradas.ContainsKey(nomeBanda))
                {
                    Console.WriteLine($"Qual nota deseja atribuir a {nomeBanda}?");
                    int nota = Convert.ToInt32(Console.ReadLine());
                    bandasRegistradas[nomeBanda].Add(nota);

                    Console.WriteLine($"\nA nota da banda {nomeBanda} foi registrada com sucesso!");
                    Thread.Sleep(3000);

                    ExibirOpcoesDoMenu();
                }
                // Banda nao existe? >> Menu principal
                else
                {
                    Console.WriteLine($"\nA banda {nomeBanda} nao existe!");
                    Console.WriteLine("Pressione qualquer tecla para voltar!");
                    Console.ReadKey();

                    ExibirOpcoesDoMenu();
                }
            }

            void MediaBanda()
            {
                Console.Write("Digite o nome da banda para saber a media: ");
                string nomeBanda = Console.ReadLine()!;

                if (bandasRegistradas.ContainsKey(nomeBanda))
                {
                    if (bandasRegistradas[nomeBanda].Count >= 1)
                    {
                        Console.WriteLine($"A banda {nomeBanda} possui media {bandasRegistradas[nomeBanda].Average()}");
                    }
                    else
                    {
                        Console.Write($"A banda {nomeBanda} nao possui nenhuma avaliacao ainda!");
                    }
                }
                else
                {
                    Console.WriteLine($"A banda {nomeBanda} nao existe!");
                }

                Thread.Sleep(3000);

                ExibirOpcoesDoMenu();
            }

            void ExibirTituloOpcoes(string titulo)
            {
                int quantidadeLetras = titulo.Length;
                string asteriscos = string.Empty.PadLeft(quantidadeLetras, '*');

                Console.WriteLine(asteriscos);
                Console.WriteLine(titulo);
                Console.WriteLine(asteriscos + "\n");
            }
        }
    }
}