using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Etidades.Entities
{
    public class Notifies
    {
        public Notifies()
        {
            Notitycoes = new List<Notifies>();
        }

        [NotMapped]// PARA QUANDO FIZER O MIGRATION, NÃO SER MAPEADO
        public string NomePropriedade { get; set; }
        [NotMapped]
        public string Mensagem { get; set; }
        [NotMapped]
        public List<Notifies> Notitycoes { get; set; }

        public bool ValidaPripriedadeString(string valor, string nomePropriedade)
        {
            if (string.IsNullOrWhiteSpace(valor) || string.IsNullOrWhiteSpace(nomePropriedade) )
            {
                Notitycoes.Add(new Notifies 
                { Mensagem = "Campo obrigatório", NomePropriedade = nomePropriedade 
                });

                return false;
            }

            return true;

        }

        public bool ValidaPripriedadeInt(int valor, string nomePropriedade)
        {
            if (valor < 1 || string.IsNullOrWhiteSpace(nomePropriedade))
            {
                Notitycoes.Add(new Notifies
                {
                    Mensagem = "Campo obrigatório",
                    NomePropriedade = nomePropriedade
                });

                return false;
            }

            return true;

        }
    }
}
