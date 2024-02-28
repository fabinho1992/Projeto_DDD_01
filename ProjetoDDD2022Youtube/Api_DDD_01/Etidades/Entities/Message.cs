using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Etidades.Entities
{
    [Table("Tb_Message")]
    public class Message : Notifies
    {
        [Column("MSN_ID")]
        public int Id { get; set; }
        [Column("MSN_TITULO")]
        public string Titulo { get; set; }
        [Column("MSN_ATIVO")]
        public bool Ativo { get; set; }
        [Column("MSN_DATA_CADASTRO")]
        public DateTime DataCadastro { get; set; }
        [Column("MSN_DATA_ALTERAÇÃO")]
        public DateTime DataAlteração { get; set; }
        [ForeignKey("ApplicationUser")]// chave estrangeira na tabela
        [Column(Order = 1)]// será oq vai aparecer primeiro na tabela
        public string UserId { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }
    }
}
