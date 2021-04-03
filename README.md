# Projeto Transferencias Bancarias.NET
 Projeto "Criando uma aplicação de transferências bancárias com .NET", atividade proposta e guiada disponível na plataforma web.digitalinnovation.one. Faz parte dos Bootcamps ".Net Fundamentals" e "LocalizaLabs .NET Developer".
 
 Funcionalidades básicas apresentadas nos vídeos do projeto da DIO foram implementadas.

Algumas modificações/melhorias feitas:
 
 -  Classe Conta:
    - Adicionado atributo NumeroConta: Essencial para um sistema bancário identificar contas;
        - Adicionado método getter para esse atributo.
    - Criado método VerSaldo;
    - Sacar:
        - if que verifica disponibilidade simplificado;
        - Agora chama o método VerSaldo ao fim, em vez de ter um Console.WriteLine() próprio.
    - Depositar:
        - Agora possui um argumento opcional booleano, para identificar se o saldo deve ser mostrado ou não.
    - Transferir:
        - Usa a modificação do método depositar para não mostrar o saldo da conta destino.
    - ToString:
        - Preferência pessoal: Agora imprime cada atributo do objeto em uma linha separada;
        - Desvantagem: Ocupa muito espaço quando "ListaContas()" da classe Program é chamada;
        - Vantagem: Cada conta impressa é mais legível.
 - Classe Program:
    - Adicionados métodos para salvar informações em um arquivo, e ler informações do mesmo, assim mantendo os dados entre sessões;
    - Modificado modo de identificação das contas relevantes nos métodos Depositar, Sacar e Transferir.
        - Agora faz uso do atributo NumeroConta da classe Conta;
        - Vantagem: Permite que contas sejam identificadas corretamente mesmo caso uma conta seja excluída, ou a forma de armazenamento das contas mude.
        
 Melhorias/expansões possíveis:
 
  - Realizar validação de input, como sugerido nos vídeos
  - Criação de um programa usuário (Em oposição à classe Program atual, que é voltado para uso por um gerente do banco
