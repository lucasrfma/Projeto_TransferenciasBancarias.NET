namespace DIO.Bank
{
    public class Conta
    {
        // Atributos
        private TipoConta TipoConta { get; set; }
        private double Saldo { get; set; }
        private double Credito { get; set; }
        private string Nome { get; set; }
        // Adicionado atributo de número da conta, essencial para identificar precisamente as contas
        private long NumeroConta { get; set; }
        static private long Ultimo;

        //Métodos
        public Conta(TipoConta tipoConta, double saldo, double credito, string nome)
        {
            this.TipoConta = tipoConta;
            this.Saldo = saldo;
            this.Credito = credito;
            this.Nome = nome;
            this.NumeroConta = ++Ultimo;
        }

        // Função para ver saldo. Reutilizada nas funções Sacar e Depositar.
        public void verSaldo()
        {
            double disponivel = Saldo + Credito;
            System.Console.WriteLine($"Saldo atual da conta de {Nome} é {Saldo}. {System.Environment.NewLine}"+
                                    "Total disponível para saque: " + disponivel.ToString("N2"));
        }
        
        public bool Sacar(double valorSaque)
        {
            // modifiquei essa verificação para uma mais simples que tem o mesmo efeito
            if( valorSaque > Saldo + Credito )
            {
                System.Console.WriteLine("Saldo insuficiente!");
                return false;
            }

            Saldo -= valorSaque;
            verSaldo();

            return true;
        }

        // Modificações
        //     Possibilidade de receber um bool que indica se o saldo deve ser impresso ou não
        public void Depositar(double valorDeposito, bool imprimeSaldo = true)
        {
            Saldo += valorDeposito;
            if(imprimeSaldo)
                verSaldo();
        }

        // Modificações:
        //     Retorna bool, mesma lógica do Sacar()
        //     Não imprime saldo do destinatário.
        public bool Transferir(double valorTransferencia, Conta contaDestino)
        {
            if(Sacar(valorTransferencia))
            {
                contaDestino.Depositar(valorTransferencia,false);
                return true;
            }
            return false;
        }

        // Preferi deixar cada atributo em uma linha separada para facilitar leitura
        public override string ToString()
        {
            string retorno =                  "Conta número : " + NumeroConta + 
            $"{System.Environment.NewLine}" + "Nome         : " + Nome +
            $"{System.Environment.NewLine}" + "Tipo da conta: " + TipoConta +
            $"{System.Environment.NewLine}" + "Saldo        : " + Saldo.ToString("N2") +
            $"{System.Environment.NewLine}" + "Crédito      : " + Credito.ToString("N2");
            return retorno;
        }

        internal long getNumeroConta()
        {
            return NumeroConta;
        }
    }
}