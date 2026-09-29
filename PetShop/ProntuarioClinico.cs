using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackPetShop
{

    public enum EspeciePet
    {
        Canino,
        Felino,
        Ave,
        Roedor
    }

    public enum StatusProntuario
    {
        Ativo,
        Bloqueado,
        EmObservacao,
        Arquivado
    }

    internal class ProntuarioClinico
    {

        private int idPet;
        private string nomePet;
        private EspeciePet especie;
        private List<Atendimento> historicoAtendimentos;
        private StatusProntuario statusProntuario;


       public ProntuarioClinico(int idPet, string nomePet, EspeciePet especie)
        {
            this.idPet = idPet;
            this.nomePet = nomePet;
            this.especie = especie;

            historicoAtendimentos = new List<Atendimento>();
            statusProntuario = StatusProntuario.Ativo;
        }

        public bool RegistrarAtendimento(Atendimento atendimento)
        {
            if (statusProntuario == StatusProntuario.Bloqueado ||
                statusProntuario == StatusProntuario.Arquivado)
            {
                Console.WriteLine("Operação rejeitada.");
                return false;
            }

            if (atendimento.ValidarAtendimento(atendimento.DataAtendimento, atendimento.Diagnostico, atendimento.PesoAtual) == false)
            {
                return false;
            }

            historicoAtendimentos.Add(atendimento);
            return true;
        }

        public void BloquearProntuario()
        {
            if (statusProntuario == StatusProntuario.Bloqueado || statusProntuario == StatusProntuario.Arquivado)
            {
                Console.WriteLine("Operação rejeitada.");
                return;
            }

            statusProntuario = StatusProntuario.Bloqueado;

        }



        public List<Atendimento> ListarPorEspecie(EspeciePet especie)
        {
            List<Atendimento> filtrados = new();

            foreach (Atendimento a in historicoAtendimentos)
            {
                if (this.especie == especie)
                {
                    filtrados.Add(a);
                }
            }
            return filtrados;
        }

        public double CalcularCustoTotalHistorico()
        {
            double total = 0;

            foreach (Atendimento atendimento in historicoAtendimentos)
            {
                foreach (ServicoEstetica servico in atendimento.Servicos)
                {
                    total += servico.PrecoBase;
                }
            }
            
            return total;
        }

        public double ObterQuantidadeAtendimentos()
        {
            return historicoAtendimentos.Count;
        }


    }
}
