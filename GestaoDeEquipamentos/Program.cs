using System.Collections;
using System.Globalization;

namespace GestaoDeEquipamentos
{
    internal class Program
    {
        static ArrayList listaNomesEquipamentos = new();
        static ArrayList listaPrecosEquipamentos = new();
        static ArrayList listaNumeroSerieEquipamentos = new();
        static ArrayList listaDataFabricacaoEquipamentos = new();
        static ArrayList listaFabricanteEquipamentos = new();
        static ArrayList listaIDsEquipamentos = new();

        static ArrayList listaTitulosChamados = new();
        static ArrayList listaNomesEquipamentosChamados = new();
        static ArrayList listaDescricoesChamados = new();
        static ArrayList listaDataDeAberturaChamados = new();
        static ArrayList listaIDsChamados = new();

        static string opcaoEquipamentos = " ";
        static string opcaoChamados = " ";

        static int minimoDeCaracteres = 6;
        static int idEquipamento = 1;
        static int idChamado = 1;
        static int obterID = 0;
        static int posicao = 0;

        static void Main(string[] args)
        {
            string opcao = ApresentarMenuPrincipal();

            opcao = ValidarOpcaoMenuPrincipal(opcao);

            while (opcao != "S")
            {
                switch (ValidarOpcaoMenuPrincipal(opcao))
                {
                    case "1":
                        ApresentarMenuEquipamentos();                       
                        break;

                    case "2":
                        ApresentarMenuChamados();                      
                        break;

                    default:
                        break;
                }

                if (opcaoEquipamentos == "1")
                {
                    if (VerificarListaEquipamentosVazia("Lista de Equipamentos", ">> A lista de equipamentos está vazia"))
                        continue;

                    VisualizarEquipamentos();

                    VoltarAoMenu();
                    continue;
                }

                else if (opcaoEquipamentos == "2")
                {
                    ModificarListas("ADD-EQUIPAMENTO");
                    continue;
                }

                else if (opcaoEquipamentos == "3")
                {
                    if (VerificarListaEquipamentosVazia("Editar Equipamento", "\n>> Não há item para ser editado!"))
                        continue;

                    ModificarListas("EDITAR-EQUIPAMENTO");
                    continue;
                }

                else if (opcaoEquipamentos == "4")
                {
                    if (VerificarListaEquipamentosVazia("Remover Equipamento", "\n>> Não há item para ser removido!"))
                        continue;

                    ModificarListas("REMOVER-EQUIPAMENTO");
                    continue;
                }

                if (opcaoChamados == "1")
                {
                    if (VerificarListaChamadosVazia("Lista de Chamados", "\n>> A lista de chamados está vazia"))
                        continue;

                    VisualizarChamados();

                    VoltarAoMenu();
                    continue;
                }

                else if (opcaoChamados == "2")
                {

                    ModificarListas("ADD-CHAMADO");
                    continue;
                }

                else if (opcaoChamados == "3")
                {
                    if (VerificarListaChamadosVazia("Editar Chamado", "\n>> Não há chamados para editar"))
                        continue;

                    ModificarListas("EDITAR-CHAMADO");               
                    continue;
                }

                else if (opcaoChamados == "4")
                {
                    if (VerificarListaChamadosVazia("Remover Chamado", "\n>> Não há chamados para remover"))
                        continue;

                    ModificarListas("REMOVER-CHAMADO");                    
                    continue;
                }

                else if (opcaoChamados == "S" || opcaoEquipamentos == "S")
                {
                    Console.Clear();

                    opcao = ApresentarMenuPrincipal();

                    opcao = ValidarOpcaoMenuPrincipal(opcao);

                    continue;
                }

                Console.WriteLine("\n>> Digite 1 para retornar ao controle de equipamentos");
                Console.WriteLine(">> Digite 2 para retornar ao controle de chamados");
                Console.WriteLine("\n>> Digite S para fechar o programa");

                opcao = Console.ReadLine().ToUpper();

                while (opcao != "1" && opcao != "2" && opcao != "S")
                {
                    ColorirMensagem("\n>> Opção inválida, escolha outra: ", ConsoleColor.Red, "NAO-QUEBRAR-LINHA");
                    opcao = Console.ReadLine().ToUpper();
                }

                if (opcao == "S")
                    break;
            }
        }

        static DateTime FormatarDataAbertura(string dataAberturaStr)
        {
            return DateTime.ParseExact(dataAberturaStr, "dd/MM/yyyy", CultureInfo.InvariantCulture);
        }
        static void VisualizarChamados()
        {
            Console.Clear();

            Cabecalho("Controle de Chamados");

            ColorirMensagem("\n>> Visualizando Chamados...", ConsoleColor.DarkYellow, "QUEBRAR-LINHA");

            Console.ForegroundColor = ConsoleColor.Red;

            Console.WriteLine("\n{0,-5}| {1,-25}| {2,-13}| {3,-10}| {4,-10}", "ID", "Equipamento", "Título", "Descrição", "Data de Abertura");
            Console.WriteLine("-----------------------------------------------------------------------------");

            Console.ResetColor();

            for (int i = 0; i < listaTitulosChamados.Count; i++)
            {
                Console.Write("{0,-5}| ", listaIDsChamados[i]);

                Console.Write("{0,-25}| ", listaNomesEquipamentosChamados[i]);

                Console.Write("{0,-13}| ", listaTitulosChamados[i]);

                Console.Write("{0,-10}| ", listaDescricoesChamados[i]);

                DateTime dataParaImpressao = (DateTime)listaDataDeAberturaChamados[i];

                Console.WriteLine("{0,-10}", dataParaImpressao.ToString("dd/MM/yyyy"));
            }        
        }
        static bool VerificarListaChamadosVazia(string cabecalho, string mensagem)
        {
            bool listaVazia = false;

            if (listaIDsChamados.Count == 0)
            {
                Console.Clear();

                Cabecalho(cabecalho);
                ColorirMensagem(mensagem, ConsoleColor.Red, "QUEBRAR-LINHA");
                VoltarAoMenu();
                listaVazia = true;
            }

            return listaVazia;
        }
        static void ObterID(string mensagem, string tipoDeID)
        {
            Console.Write(mensagem);
            obterID = Convert.ToInt32(Console.ReadLine());

            if (tipoDeID == "EQUIPAMENTO")
            {
                posicao = listaIDsEquipamentos.IndexOf(obterID);
            }

            else if (tipoDeID == "CHAMADO")
            {
                posicao = listaIDsChamados.IndexOf(obterID);
            }
            
        }
        static void ModificarListas(string tipoOperacao)
        {
            if (tipoOperacao == "ADD-EQUIPAMENTO")
            {
                listaNomesEquipamentos.Add(ObterNomeEquipamento());
                listaPrecosEquipamentos.Add(ObterPrecoAquisicao());
                listaNumeroSerieEquipamentos.Add(ObterNumeroSerie());
                listaDataFabricacaoEquipamentos.Add(FormatarDataFabricacao(ObterDataFabricacao()));
                listaFabricanteEquipamentos.Add(ObterFabricante());
                listaIDsEquipamentos.Add(idEquipamento);

                idEquipamento++;

                ColorirMensagem("\n>> Equipamento registrado com sucesso!", ConsoleColor.Green, "QUEBRAR-LINHA");

                VoltarAoMenu();
            }

            else if (tipoOperacao == "EDITAR-EQUIPAMENTO")
            {
                VisualizarEquipamentos();

                ObterID("\n>> Digite o ID do equipamento para editá-lo: ", "EQUIPAMENTO");

                for (int i = 0; i <= listaIDsEquipamentos.Count; i++)
                {

                    if (i == posicao)
                    {
                        Console.Write($"\n>> Novo nome do equipamento com no mínimo {minimoDeCaracteres} caracteres: ");
                        string nomeEquipamento = Console.ReadLine();

                        while (nomeEquipamento.Length < minimoDeCaracteres)
                        {
                            Console.WriteLine($"\n>> O nome possui menos de {minimoDeCaracteres} caracteres");
                            Console.Write($"\n>> Digite outro nome com mais de {minimoDeCaracteres} caracteres: ");
                            nomeEquipamento = Console.ReadLine();
                        }

                        listaNomesEquipamentos[posicao] = nomeEquipamento;

                        Console.Write("\n>> Novo preço de aquisição: ");
                        decimal precoAquisicao = Math.Round(Convert.ToDecimal(Console.ReadLine()), 2);
                        listaPrecosEquipamentos[posicao] = precoAquisicao;

                        Console.Write("\n>> Novo número de série: ");
                        string numeroSerie = Console.ReadLine();
                        listaNumeroSerieEquipamentos[posicao] = numeroSerie;

                        Console.Write("\n>> Nova data de fabricação (DD/MM/AAAA): ");
                        string dataFabricacaoStr = Console.ReadLine();
                        DateTime dataFabricacao = DateTime.ParseExact(dataFabricacaoStr, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                        listaDataFabricacaoEquipamentos[posicao] = dataFabricacao;

                        Console.Write("\n>> Novo fabricante: ");
                        string fabricante = Console.ReadLine();
                        listaFabricanteEquipamentos[posicao] = fabricante;

                        listaIDsEquipamentos[posicao] = obterID;

                        ColorirMensagem("\n>> Equipamento editado com sucesso!", ConsoleColor.Green, "QUEBRAR-LINHA");

                        VoltarAoMenu();
                    }
                }
            }

            else if (tipoOperacao == "REMOVER-EQUIPAMENTO")
            {
                VisualizarEquipamentos();

                ObterID("\n>> Digite o ID do equipamento para removê-lo: ", "EQUIPAMENTO");

                for (int i = 0; i <= listaIDsEquipamentos.Count; i++)
                {
                    if (i == posicao)
                    {
                        listaNomesEquipamentos.RemoveAt(posicao);
                        listaPrecosEquipamentos.RemoveAt(posicao);
                        listaNumeroSerieEquipamentos.RemoveAt(posicao);
                        listaDataFabricacaoEquipamentos.RemoveAt(posicao);
                        listaFabricanteEquipamentos.RemoveAt(posicao);
                        listaIDsEquipamentos.RemoveAt(posicao);

                        ColorirMensagem("\n>> Equipamento removido com sucesso!", ConsoleColor.Green, "QUEBRAR-LINHA");
                        VoltarAoMenu();
                    }
                }
            }

            else if (tipoOperacao == "ADD-CHAMADO")
            {
                Console.Clear();

                Cabecalho("Crie um Chamado");

                Console.Write($"\n>> Título do chamado: ");
                string tituloChamado = Console.ReadLine();

                listaTitulosChamados.Add(tituloChamado);

                Console.Write("\n>> Digite o nome do equipamento: ");
                string nomeEquipamento = Console.ReadLine();
                listaNomesEquipamentosChamados.Add(nomeEquipamento);

                Console.Write("\n>> Digite a descrição do chamado: ");
                string descricaoChamado = Console.ReadLine();
                listaDescricoesChamados.Add(descricaoChamado);

                Console.Write("\n>> Data de abertura do chamado (DD/MM/AAAA): ");
                string dataAberturaStr = Console.ReadLine();
                DateTime dataAbertura = FormatarDataAbertura(dataAberturaStr);
                listaDataDeAberturaChamados.Add(dataAbertura);

                listaIDsChamados.Add(idChamado);

                idChamado++;

                ColorirMensagem("\n>> Equipamento registrado com sucesso!", ConsoleColor.Green, "QUEBRAR-LINHA");

                VoltarAoMenu();
            }

            else if (tipoOperacao == "EDITAR-CHAMADO")
            {
                VisualizarChamados();

                ObterID("\n>> Digite o ID do chamado para editá-lo: ", "CHAMADO");

                for (int i = 0; i < listaIDsChamados.Count; i++)
                {

                    if (i == posicao)
                    {
                        Console.Write($"\n>> Digite o novo título do chamado: ");
                        string tituloChamado = Console.ReadLine();
                        listaTitulosChamados[posicao] = tituloChamado;

                        Console.Write("\n>> Digite o novo nome do equipamento: ");
                        string nomeEquipamento = Console.ReadLine();
                        listaNomesEquipamentosChamados[posicao] = nomeEquipamento;

                        Console.Write("\n>> Nova descrição do chamado: ");
                        string descricaoChamado = Console.ReadLine();
                        listaDescricoesChamados[posicao] = descricaoChamado;

                        Console.Write("\n>> Nova data de abertura do chamado (DD/MM/AAAA): ");
                        string dataAberturaStr = Console.ReadLine();
                        DateTime dataAbertura = DateTime.ParseExact(dataAberturaStr, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                        listaDataDeAberturaChamados[posicao] = dataAbertura;

                        listaIDsChamados[posicao] = obterID;

                        ColorirMensagem("\n>> Equipamento editado com sucesso!", ConsoleColor.Green, "QUEBRAR-LINHA");
                        VoltarAoMenu();
                    }
                }
            }

            else if (tipoOperacao == "REMOVER-CHAMADO")
            {
                VisualizarChamados();

                ObterID("\n>> Digite o ID do chamado para removê-lo: ", "CHAMADO");

                for (int i = 0; i <= listaIDsChamados.Count; i++)
                {

                    if (i == posicao)
                    {
                        listaTitulosChamados.RemoveAt(posicao);
                        listaNomesEquipamentosChamados.RemoveAt(posicao);
                        listaDescricoesChamados.RemoveAt(posicao);
                        listaDataDeAberturaChamados.RemoveAt(posicao);
                        listaIDsChamados.RemoveAt(posicao);

                        ColorirMensagem("\n>> Chamado removido com sucesso!", ConsoleColor.Green, "QUEBRAR-LINHA");

                        VoltarAoMenu();
                    }
                }
            }
        }
        static void VoltarAoMenu()
        {
            ColorirMensagem("\n>> Pressione Enter para voltar ao menu", ConsoleColor.Yellow, "QUEBRAR-LINHA");
            Console.ReadKey();
        }
        static string ObterFabricante()
        {
            Console.Write("\n>> Digite o fabricante: ");
            string fabricante = Console.ReadLine();

            return fabricante;
        }
        static DateTime FormatarDataFabricacao(string dataFabricacaoStr)
        {
            return DateTime.ParseExact(dataFabricacaoStr, "dd/MM/yyyy", CultureInfo.InvariantCulture);
        }
        static string ObterDataFabricacao()
        {
            Console.Write("\n>> Data de fabricação (DD/MM/AAAA): ");
            string dataFabricacaoStr = Console.ReadLine();
            return dataFabricacaoStr;
        }
        static string ObterNumeroSerie()
        {
            Console.Write("\n>> Número de série: ");
            string numeroSerie = Console.ReadLine();
            return numeroSerie;
        }
        static decimal ObterPrecoAquisicao()
        {
            Console.Write("\n>> Preço de aquisição: ");
            decimal precoAquisicao = Math.Round(Convert.ToDecimal(Console.ReadLine()), 2);
            return precoAquisicao;
        }
        static string ObterNomeEquipamento()
        {
            Console.Clear();
            Cabecalho("Adicione um equipamento");
            Console.Write($"\n>> Nome do equipamento com no minímo {minimoDeCaracteres} caracteres: ");
            string nomeEquipamento = Console.ReadLine();

            nomeEquipamento = ValidarTamanhoNomeEquipamento(nomeEquipamento);

            return nomeEquipamento;
        }
        static string ValidarTamanhoNomeEquipamento(string nomeEquipamento)
        {
            while (nomeEquipamento.Length < minimoDeCaracteres)
            {
                ColorirMensagem($"\n>> O nome possui menos de {minimoDeCaracteres} caracteres", ConsoleColor.Red, "QUEBRAR-LINHA");
                ColorirMensagem($"\n>> Digite outro nome com mais de {minimoDeCaracteres} caracteres: ", ConsoleColor.Yellow, "NAO-QUEBRAR-LINHA");
                nomeEquipamento = Console.ReadLine();
            }

            return nomeEquipamento;
        }
        static void VisualizarEquipamentos()
        {
            Console.Clear();

            Cabecalho("Controle de Equipamentos");

            ColorirMensagem("\n>> Visualizando Equipamentos...", ConsoleColor.DarkYellow, "QUEBRAR-LINHA");

            Console.ForegroundColor = ConsoleColor.Red;

            Console.WriteLine("\n{0,-5}| {1,-25}| {2,-13}| {3,-10}| {4,-15}| {5,-10}", "ID", "Nome", "Preço", "Série", "Fabricante", "Data de Fabricação");
            Console.WriteLine("-------------------------------------------------------------------------------------------------");

            Console.ResetColor();

            for (int i = 0; i < listaNomesEquipamentos.Count; i++)
            {
                Console.Write("{0,-5}| ", listaIDsEquipamentos[i]);

                Console.Write("{0,-25}| R$ ", listaNomesEquipamentos[i]);

                decimal precoParaImpressao = (decimal)listaPrecosEquipamentos[i];

                Console.Write("{0,-10}| ", Math.Round(precoParaImpressao, 2));

                Console.Write("{0,-10}| ", listaNumeroSerieEquipamentos[i]);

                Console.Write("{0,-15}| ", listaFabricanteEquipamentos[i]);

                DateTime dataParaImpressao = (DateTime)listaDataFabricacaoEquipamentos[i];

                Console.WriteLine("{0,-10}", dataParaImpressao.ToString("dd/MM/yyyy"));
            }
        }
        static bool VerificarListaEquipamentosVazia(string cabecalho, string mensagem)
        {
            bool listaVazia = false;

            if (listaIDsEquipamentos.Count == 0)
            {
                Console.Clear();

                Cabecalho(cabecalho);
                ColorirMensagem(mensagem, ConsoleColor.Red, "QUEBRAR-LINHA");
                VoltarAoMenu();
                listaVazia = true;
            }

            return listaVazia;
        }
        static void ValidarMenuChamados()
        {
            while (opcaoChamados != "1" && opcaoChamados != "2" && opcaoChamados != "3" && opcaoChamados != "4" && opcaoChamados != "S")
            {
                ColorirMensagem("\n>> Opção inválida, escolha outra: ", ConsoleColor.Red, "NAO-QUEBRAR-LINHA");
                opcaoChamados = Console.ReadLine().ToUpper();
            }
        }
        static void ApresentarMenuChamados()
        {
            Console.Clear();
            Cabecalho("Bem vindo ao controle de chamados");
            Console.WriteLine(">> Digite 1 para visualizar chamados");
            Console.WriteLine(">> Digite 2 para adicionar um chamado");
            Console.WriteLine(">> Digite 3 para editar um chamado");
            Console.WriteLine(">> Digite 4 para remover um chamado");
            Console.WriteLine("\n>> Digite S para voltar ao menu principal");

            opcaoChamados = Console.ReadLine().ToUpper();

            ValidarMenuChamados();
        }
        static void ValidarMenuEquipamentos()
        {
            while (opcaoEquipamentos != "1" && opcaoEquipamentos != "2" && opcaoEquipamentos != "3" && opcaoEquipamentos != "4" && opcaoEquipamentos != "S")
            {
                ColorirMensagem("\n>> Opção inválida, escolha outra: ", ConsoleColor.Red, "NAO-QUEBRAR-LINHA");
                opcaoEquipamentos = Console.ReadLine().ToUpper();
            }
        }
        static void ApresentarMenuEquipamentos()
        {
            Console.Clear();
            Cabecalho("Bem-vindo ao controle de equipamentos");
            Console.WriteLine(">> Digite 1 para visualizar equipamentos");
            Console.WriteLine(">> Digite 2 para adicionar equipamentos");
            Console.WriteLine(">> Digite 3 para editar equipamentos");
            Console.WriteLine(">> Digite 4 para remover equipamentos");
            Console.WriteLine("\n>> Digite S para voltar ao menu principal");

            opcaoEquipamentos = Console.ReadLine().ToUpper();

            ValidarMenuEquipamentos();
        }
        static string ValidarOpcaoMenuPrincipal(string opcao)
        {
            while (opcao != "1" && opcao != "2" && opcao != "S")
            {
                ColorirMensagem("\n>> Opção inválida, escolha outra: ", ConsoleColor.Red, "NAO-QUEBRAR-LINHA");
                opcao = Console.ReadLine().ToUpper();
            }

            return opcao;
        }
        static string ApresentarMenuPrincipal()
        {
            Cabecalho("Bem-Vindo à Gestão de Equipamentos");
            Console.WriteLine(">> Digite 1 para usar o controle de equipamentos");
            Console.WriteLine(">> Digite 2 para usar o controle de chamados");
            Console.WriteLine("\n>> Digite S para fechar o programa");

            string opcao = Console.ReadLine().ToUpper();

            return opcao;
        }
        static string Cabecalho(string mensagem)
        {
            ColorirMensagem($"------ {mensagem} ------\n", ConsoleColor.Green, "QUEBRAR-LINHA");

            return mensagem;
        }
        static string ColorirMensagem(string mensagem, ConsoleColor cor, string quebrarLinha)
        {
            if (quebrarLinha == "QUEBRAR-LINHA")
            {
                Console.ForegroundColor = cor;
                Console.WriteLine(mensagem);
                Console.ResetColor();
            }

            else if (quebrarLinha == "NAO-QUEBRAR-LINHA")
            {
                Console.ForegroundColor = cor;
                Console.Write(mensagem);
                Console.ResetColor();
            }

            return mensagem;
        }
    }
}
