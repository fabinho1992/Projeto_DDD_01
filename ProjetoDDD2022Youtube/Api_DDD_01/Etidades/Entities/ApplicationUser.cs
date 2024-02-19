using Etidades.Enuns;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Etidades.Entities
{
    public class ApplicationUser: IdentityUser
    {
        public ApplicationUser() : base () { }

        [Column("USR_CPF")]
        public string CPF {  get; set; }
        [Column("USR_TIPO")]
        public TypeUser? Tipo { get; set; }

    }
}
