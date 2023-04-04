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
                    if (VerificarListaVazia("Lista de Equipamentos", ">> A lista de equipamentos está vazia", "EQUIPAMENTOS"))
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
                    if (VerificarListaVazia("Editar Equipamento", "\n>> Não há item para ser editado!", "EQUIPAMENTOS"))
                        continue;

                    ModificarListas("EDITAR-EQUIPAMENTO");
                    continue;
                }

                else if (opcaoEquipamentos == "4")
                {
                    if (VerificarListaVazia("Remover Equipamento", "\n>> Não há item para ser removido!", "EQUIPAMENTOS"))
                        continue;

                    ModificarListas("REMOVER-EQUIPAMENTO");
                    continue;
                }

                if (opcaoChamados == "1")
                {
                    if (VerificarListaVazia("Lista de Chamados", "\n>> A lista de chamados está vazia", "CHAMADOS"))
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
                    if (VerificarListaVazia("Editar Chamado", "\n>> Não há chamados para editar", "CHAMADOS"))
                        continue;

                    ModificarListas("EDITAR-CHAMADO");
                    continue;
                }

                else if (opcaoChamados == "4")
                {
                    if (VerificarListaVazia("Remover Chamado", "\n>> Não há chamados para remover", "CHAMADOS"))
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

                opcao = ValidarMenuDeRetorno(ApresentarMenuDeRetorno());

                if (opcao == "S")
                    break;
            }
        }
        static string ValidarMenuDeRetorno(string opcao)
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

            return Console.ReadLine().ToUpper();
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

            ValidarMenu("EQUIPAMENTOS");
        }
        static void ValidarMenu(string tipoDeValidacao)
        {
            switch (tipoDeValidacao)
            {
                case "EQUIPAMENTOS":
                    while (opcaoEquipamentos != "1" && opcaoEquipamentos != "2" && opcaoEquipamentos != "3" && opcaoEquipamentos != "4" && opcaoEquipamentos != "S")
                    {
                        ColorirMensagem("\n>> Opção inválida, escolha outra: ", ConsoleColor.Red, "NAO-QUEBRAR-LINHA");
                        opcaoEquipamentos = Console.ReadLine().ToUpper();
                    }
                    break;

                case "CHAMADOS":
                    while (opcaoChamados != "1" && opcaoChamados != "2" && opcaoChamados != "3" && opcaoChamados != "4" && opcaoChamados != "S")
                    {
                        ColorirMensagem("\n>> Opção inválida, escolha outra: ", ConsoleColor.Red, "NAO-QUEBRAR-LINHA");
                        opcaoChamados = Console.ReadLine().ToUpper();
                    }
                    break;

                default:
                    break;
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

            ValidarMenu("CHAMADOS");
        }
        static string ApresentarMenuDeRetorno()
        {
            Console.WriteLine("\n>> Digite 1 para retornar ao controle de equipamentos");
            Console.WriteLine(">> Digite 2 para retornar ao controle de chamados");
            Console.WriteLine("\n>> Digite S para fechar o programa");
            
            return Console.ReadLine().ToUpper();
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
        static void VisualizarChamados()
        {
            Console.Clear();

            Cabecalho("Controle de Chamados");

            ColorirMensagem("\n>> Visualizando Chamados...", ConsoleColor.DarkYellow, "QUEBRAR-LINHA");

            Console.ForegroundColor = ConsoleColor.Red;

            Console.WriteLine("\n{0,-5}| {1,-25}| {2,-13}| {3,-17}| {4,-10}", "ID", "Equipamento", "Título", "Data de Abertura", "Dias em Aberto");
            Console.WriteLine("----------------------------------------------------------------------------------");

            Console.ResetColor();

            for (int i = 0; i < listaTitulosChamados.Count; i++)
            {
                Console.Write("{0,-5}| ", listaIDsChamados[i]);

                Console.Write("{0,-25}| ", listaNomesEquipamentosChamados[i]);

                Console.Write("{0,-13}| ", listaTitulosChamados[i]);

                DateTime dataParaImpressao = (DateTime)listaDataDeAberturaChamados[i];

                Console.Write("{0,-17}| ", dataParaImpressao.ToString("dd/MM/yyyy"));

                DateTime diasEmAberto = (DateTime)listaDataDeAberturaChamados[i];
                TimeSpan diasFormatado = DateTime.Now.Subtract(diasEmAberto);

                Console.WriteLine("{0,-10}", $"{diasFormatado.Days} dias");
            }
        }
        static bool VerificarListaVazia(string cabecalho, string mensagem, string tipoDeLista)
        {
            bool listaVazia = false;

            switch (tipoDeLista)
            {
                case "EQUIPAMENTOS":
                    if (listaIDsEquipamentos.Count == 0)
                    {
                        Console.Clear();

                        Cabecalho(cabecalho);
                        ColorirMensagem(mensagem, ConsoleColor.Red, "QUEBRAR-LINHA");
                        VoltarAoMenu();
                        listaVazia = true;
                    }
                    break;

                case "CHAMADOS":
                    if (listaIDsChamados.Count == 0)
                    {
                        Console.Clear();

                        Cabecalho(cabecalho);
                        ColorirMensagem(mensagem, ConsoleColor.Red, "QUEBRAR-LINHA");
                        VoltarAoMenu();
                        listaVazia = true;
                    }
                    break;

                default:
                    break;
            }

            return listaVazia;
        }
        static string ObterNomeEquipamento(string mensagem)
        {
            Console.Write(mensagem);

            return ValidarTamanhoNomeEquipamento(Console.ReadLine());
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
        static void ModificarListas(string tipoOperacao)
        {
            if (tipoOperacao == "ADD-EQUIPAMENTO")
            {
                Console.Clear();

                Cabecalho("Adicione um equipamento");

                listaNomesEquipamentos.Add(ObterNomeEquipamento($"\n>> Nome do equipamento com no minímo {minimoDeCaracteres} caracteres: "));
                listaPrecosEquipamentos.Add(ObterDecimal("\n>> Preço de aquisição: "));
                listaNumeroSerieEquipamentos.Add(ObterString("\n>> Número de série: "));
                listaDataFabricacaoEquipamentos.Add(FormatarData(ObterString("\n>> Data de fabricação (DD/MM/AAAA): ")));
                listaFabricanteEquipamentos.Add(ObterString("\n>> Digite o fabricante: "));
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
                        listaNomesEquipamentos[posicao] = ValidarTamanhoNomeEquipamento(ObterNomeEquipamento($"\n>> Novo nome do equipamento com no mínimo {minimoDeCaracteres} caracteres: "));
                        listaPrecosEquipamentos[posicao] = Math.Round(Convert.ToDecimal(ObterDecimal("\n>> Novo preço de aquisição: ")), 2);
                        listaNumeroSerieEquipamentos[posicao] = ObterString("\n>> Novo número de série: ");                      
                        listaDataFabricacaoEquipamentos[posicao] = VerificarFormatoData(ObterString("\n>> Nova data de fabricação (DD/MM/AAAA): "));
                        listaFabricanteEquipamentos[posicao] = ObterString("\n>> Novo fabricante: ");
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

                listaTitulosChamados.Add(ObterString($"\n>> Título do chamado: "));
                listaNomesEquipamentosChamados.Add(ObterString("\n>> Digite o nome do equipamento: "));
                listaDescricoesChamados.Add(ObterString("\n>> Digite a descrição do chamado: "));
                listaDataDeAberturaChamados.Add(FormatarData(ObterString("\n>> Data de abertura do chamado (DD/MM/AAAA): ")));
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
                        listaTitulosChamados[posicao] = ObterString($"\n>> Digite o novo título do chamado: ");
                        listaNomesEquipamentosChamados[posicao] = ObterString("\n>> Digite o novo nome do equipamento: ");
                        listaDescricoesChamados[posicao] = ObterString("\n>> Nova descrição do chamado: ");
                        listaDataDeAberturaChamados[posicao] = FormatarData(ObterString("\n>> Nova data de abertura do chamado (DD/MM/AAAA): "));
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
        static decimal ObterDecimal(string mensagem)
        {
            Console.Write(mensagem);
            
            while (true)
            {
                try
                {
                    return Math.Round(Convert.ToDecimal(Console.ReadLine().Replace(',', '.'), CultureInfo.InvariantCulture), 2);
                }
                catch (FormatException)
                {
                    ColorirMensagem("\n>> Apenas números são aceitos!", ConsoleColor.Red, "QUEBRAR-LINHA");
                    ColorirMensagem("\n>> Digite outro número: ", ConsoleColor.Yellow, "NAO-QUEBRAR-LINHA");
                }
            }
        }
        static string ObterString(string mensagem)
        {
            Console.Write(mensagem);

            return Console.ReadLine();
        }
        static void VoltarAoMenu()
        {
            ColorirMensagem("\n>> Pressione Enter para voltar ao menu", ConsoleColor.Yellow, "QUEBRAR-LINHA");
            Console.ReadKey();
        }
        static void Cabecalho(string mensagem)
        {
            ColorirMensagem($"------ {mensagem} ------\n", ConsoleColor.Green, "QUEBRAR-LINHA");
        }
        static void ColorirMensagem(string mensagem, ConsoleColor cor, string quebrarLinha)
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
        }
        static DateTime FormatarData(string dataStr)
        {
            while (true)
            {
                try
                {
                    return DateTime.ParseExact(dataStr, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                }
                catch
                {
                    ColorirMensagem("\n>> Ocorreu um erro na escrita da data!", ConsoleColor.Red, "QUEBRAR-LINHA");
                    ColorirMensagem("\n>> Reescreva utilizando o formato correto (DD/MM/AAAA): ", ConsoleColor.Yellow, "NAO-QUEBRAR-LINHA");
                    dataStr = Console.ReadLine();
                }
            }       
        }
        static DateTime VerificarFormatoData(string mensagem)
        {
            while (true)
            {
                try
                {
                    return DateTime.ParseExact(mensagem, "dd/MM/yyyy", CultureInfo.InvariantCulture);

                }
                catch
                {
                    ColorirMensagem("\n>> Ocorreu um erro na escrita da data!", ConsoleColor.Red, "QUEBRAR-LINHA");
                    ColorirMensagem("\n>> Reescreva utilizando o formato correto (DD/MM/AAAA): ", ConsoleColor.Yellow, "NAO-QUEBRAR-LINHA");
                    mensagem = Console.ReadLine();
                }
            }
        }
    }
}