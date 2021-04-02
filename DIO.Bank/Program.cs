using System;
using System.Collections.Generic;

namespace DIO.Bank
{
    class Program
    {
        static List<Conta> listContas = new List<Conta>();
        static void Main(string[] args)
        {   
            string opcaoUsuario = ObterOpcaoUsuario();;
            while(opcaoUsuario != "X"){
                switch (opcaoUsuario)
                {
                    case "1":
                        ListarContas(); 
                        break;
                    case "2":
                        InserirConta(); 
                        break;
                    case "3":
                        Transferir(); 
                        break;
                    case "4":
                        Sacar(); 
                        break;
                    case "5":
                        Depositar(); 
                        break;
                    case "C":
                        Console.Clear();
                        break;
                    default:
                        Console.WriteLine("Opção inválida, por fazer digite novamente.");
                        break;
                }
                opcaoUsuario = ObterOpcaoUsuario();
            }
            Console.WriteLine("Obrigado por utilizar nossos serviços!");
            Console.ReadLine();
        }

        // Modifiquei para usar o atributo "NumeroConta"
        // Dessa forma, mesmo que haja exclusão de uma conta, ou a forma de armazenamento das contas mude
        //      o programa continuará funcionando corretamente.
        private static void Depositar()
        {
            Console.WriteLine($"Digite o número da conta.");
            int numeroConta = int.Parse(Console.ReadLine());

            Console.WriteLine($"Digite o valor a depositar.");
            double valorDeposito = double.Parse(Console.ReadLine());

            listContas.Find( i => i.getNumeroConta().Equals(numeroConta)).Depositar(valorDeposito);
        }

        private static void Sacar()
        {
            Console.WriteLine($"Digite o número da conta.");
            int numeroConta = int.Parse(Console.ReadLine());

            Console.WriteLine($"Digite o valor a sacar.");
            double valorSaque = double.Parse(Console.ReadLine());

            listContas.Find( i => i.getNumeroConta().Equals(numeroConta)).Sacar(valorSaque);
        }

        private static void Transferir()
        {
            Console.WriteLine($"Digite o número da conta origem.");
            int contaOrigem = int.Parse(Console.ReadLine());
            
            Console.WriteLine($"Digite o número da conta destino.");
            int contaDestino = int.Parse(Console.ReadLine());

            Console.WriteLine($"Digite o valor a transferir.");
            double valorTransf = double.Parse(Console.ReadLine());

            listContas.Find( i => i.getNumeroConta().
                                Equals(contaOrigem)).
                Transferir(valorTransf,listContas.Find( j => j.getNumeroConta().Equals(contaDestino)));

        }

        private static void ListarContas()
        {
            Console.WriteLine($"Lista de contas:");

            if( listContas.Count == 0 )
            {
                Console.WriteLine($"Nenhuma conta cadastrada.");
                return;
            }

            for (int i = 0; i < listContas.Count ; i++)
            {
                Console.WriteLine($"{Environment.NewLine}"+listContas[i]);
            }
        }

        private static void InserirConta()
        {
            Console.WriteLine($"Digite 1 para conta Pessoa Física ou 2 para Pessoa Jurídica.");
            int tipoConta = int.Parse(Console.ReadLine());

            Console.WriteLine($"Digite o nome do cliente.");
            string nomeCliente = Console.ReadLine();

            Console.WriteLine($"Digite o saldo inicial.");
            double saldo = double.Parse(Console.ReadLine());
            
            Console.WriteLine($"Digite o crédito disponível para o cliente.");
            double credito = double.Parse(Console.ReadLine());

            Conta novaConta = new Conta( (TipoConta)tipoConta,saldo,credito,nomeCliente);

            listContas.Add(novaConta);
        }

        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine($"{Environment.NewLine}DIO Bank a seu dispor!!!" +
                              $"{Environment.NewLine}Informe a opção desejada: " + 
                              $"{Environment.NewLine}" + 
                              $"{Environment.NewLine} 1 - Listar contas" + 
                              $"{Environment.NewLine} 2 - Inserir nova conta" + 
                              $"{Environment.NewLine} 3 - Transferir" + 
                              $"{Environment.NewLine} 4 - Sacar" + 
                              $"{Environment.NewLine} 5 - Depositar" + 
                              $"{Environment.NewLine} C - Limpar tela" + 
                              $"{Environment.NewLine} X - Sair" + 
                              $"{Environment.NewLine}");

            string opcao = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcao; 
        }
    }
}
