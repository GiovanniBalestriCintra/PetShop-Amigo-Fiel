using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackPetShop
{
    internal class ServicoEstetica
    {
        private int idServico;
        private string descricaoServico;
        private double precoBase;
        private bool incluiTosaHigienica;

        public int IdServico { get { return idServico; } }
        public string DescricaoServico { get { return descricaoServico; } }
        public double PrecoBase { get { return precoBase; } }
        public bool IncluiTosaHigienica { get { return incluiTosaHigienica; } }



        public ServicoEstetica (int idServico, string descricaoServico, double precoBase, bool incluiTosaHigienica)
        {
            this.idServico = idServico;
            this.descricaoServico = descricaoServico;
            this.precoBase = precoBase;
            this.incluiTosaHigienica = incluiTosaHigienica;
        }

        public void AjustarPreco(double novoPreco)
        {
            this.precoBase = novoPreco;
        }


    }
}
