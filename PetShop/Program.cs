using BackPetShop;

using System;

public class Program
{
    public static void Main()
    {
        Console.WriteLine("INICIANDO TESTES QA - PETSHOP AMIGO FIEL\n");

        ProntuarioClinico prontuario = new ProntuarioClinico
        (
            1,
            "Rex",
            EspeciePet.Canino
        );

        ServicoEstetica banho = new ServicoEstetica(10, "Banho Simples", 50.00, false);
        ServicoEstetica tosa = new ServicoEstetica(11, "Tosa Completa", 80.00, true);
        ServicoEstetica consulta = new ServicoEstetica(12, "Consulta Clínica", 100.00, false);

        // ---------------------------------------------------------
        // CT5.03: Atendimento com peso 0.[cite: 1]
        // ---------------------------------------------------------
        
        Console.WriteLine("--- CT5.03: Registrar atendimento com peso 0 ---");
        Atendimento atendimentoInvalido = new Atendimento(1, "Suspeita de virose", 0.0);


        bool registrouInvalido = atendimentoInvalido.ValidarAtendimento(
        DateTime.Now,
        "Suspeita de virose",
        0.0
        );

        Console.WriteLine($"Operação aceita? {registrouInvalido}");
        
        // Criar método para verificar quantidade de atendimentos:
        Console.WriteLine($"Quantidade de atendimentos (Esperado: 0): {prontuario.ObterQuantidadeAtendimentos()}");


        // ---------------------------------------------------------
        // CT5.01: Três atendimentos com serviços cujo total é R$180,00[cite: 1] (Modificado levemente os valores para bater a soma)
        // ---------------------------------------------------------
        Console.WriteLine("\n--- CT5.01: Calcular o custo histórico ---");
        Atendimento at1 = new Atendimento(2, "Rotina", 15.5);

        /// Adicionar método "Adicionar Serviços" ->
        at1.AdicionarServico(banho); // R$ 50

        Atendimento at2 = new Atendimento(3, "Vacina", 15.6);
        at2.AdicionarServico(banho); // R$ 50
        at2.AdicionarServico(tosa);  // R$ 80 -> Subtotal até aqui R$ 180

        prontuario.RegistrarAtendimento(at1);
        prontuario.RegistrarAtendimento(at2);

        Console.WriteLine($"Custo histórico calculado (Esperado: 180,00): {prontuario.CalcularCustoTotalHistorico():F2}");


        // ---------------------------------------------------------
        // CT5.02: Atendimento com diagnóstico consolidado. Tentar alterar.[cite: 1]
        // ---------------------------------------------------------
        Console.WriteLine("\n--- CT5.02: Alterar diagnóstico consolidado ---");
        Atendimento at3 = new Atendimento(4, "Otite leve", 15.5);
        prontuario.RegistrarAtendimento(at3);

        at3.Consolidar(); // Assina o documento

        Console.WriteLine($"Diagnóstico final (Esperado: Otite leve): {at3.Diagnostico}");


        // ---------------------------------------------------------
        // CT5.05: Atendimento com diagnóstico consolidado. Criar novo registro corretivo.[cite: 1]
        // ---------------------------------------------------------
        Console.WriteLine("\n--- CT5.05: Criar novo atendimento corretivo ---");
        // RN04: Uma correção posterior deve ser registrada como novo atendimento[cite: 1]
        Atendimento atCorretivo = new Atendimento(5, "Correção at. 4: Otite grave confirmada", 15.5);
        prontuario.RegistrarAtendimento(atCorretivo);

        
        Console.WriteLine($"Total de atendimentos no histórico (Esperado: 4): {prontuario.ObterQuantidadeAtendimentos()}");


        // ---------------------------------------------------------
        // CT5.04: Prontuário Bloqueado. Tentar registrar atendimento válido.[cite: 1]
        // ---------------------------------------------------------
        Console.WriteLine("\n--- CT5.04: Prontuário Bloqueado ---");
        prontuario.BloquearProntuario();

        Atendimento atAtrasado = new Atendimento(6, "Corte de unhas", 15.6);
        prontuario.RegistrarAtendimento(atAtrasado);

        Console.WriteLine($"Total final de atendimentos (Esperado: 4): {prontuario.ObterQuantidadeAtendimentos()}");
    }
}