using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackPetShop
{

    internal class Atendimento
    {
        private int idAtendimento;
        private DateTime dataAtendimento;
        private string diagnostico;
        private double pesoAtual;
        private bool consolidado;
        private List<ServicoEstetica> servicos;

        public int IdAtendimento { get { return idAtendimento;} }
        public DateTime DataAtendimento { get {return dataAtendimento;} }
        public string Diagnostico { get { return diagnostico;} }
        public double PesoAtual { get {  return pesoAtual;} }
        public bool Consolidado { get { return consolidado; } }
        public List<ServicoEstetica> Servicos { get; } = new();

        public Atendimento(int idAtendimento, string diagnostico, double pesoAtual)
        {
            this.idAtendimento = idAtendimento;
            this.diagnostico = diagnostico;
            this.pesoAtual = pesoAtual;
            this.dataAtendimento = DateTime.Now;
            this.consolidado = false;
        }

        public bool ValidarAtendimento(DateTime data, string diagnostico, double peso)
        {

            if (data > DateTime.Now)
            {
                Console.WriteLine("Data inválida.");
                return false;
            }

          if (diagnostico == null || diagnostico == "")
            {
                Console.WriteLine("Diagnóstico inválido.");
                return false;
            }

            if (peso <= 0)
            {
                Console.WriteLine("Peso inválido.");
                return false;
            }

            return true;
        }


        public void AtualizarDiagnostico(string novoDiagnostico)
        {
            if (!consolidado)
            {
                diagnostico = novoDiagnostico;
            }
            else
            {
                Console.WriteLine("Erro: o diagnóstico não pode ser alterado porque o atendimento está consolidado.");
            }
            
        }

        public bool ValidarPeso(double peso)
        {

            return peso > 0;


            //return peso <= 0;
        }


        public void Consolidar()
        {
            consolidado = true;
        }

        public bool AdicionarServico(ServicoEstetica servico)
        {
            if (servico == null)
            {
                return false;
            }

            Servicos.Add(servico);
            return true;
        }

       




    }
}
