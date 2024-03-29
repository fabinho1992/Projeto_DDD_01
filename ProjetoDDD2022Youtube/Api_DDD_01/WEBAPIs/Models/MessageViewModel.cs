﻿using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPIs.Models
{
    public class MessageViewModel
    {
        
        public int Id { get; set; }
        
        public string Titulo { get; set; }
        
        public bool Ativo { get; set; }
        
        public DateTime DataCadastro { get; set; }
        
        public DateTime DataAlteração { get; set; }
       
        public string UserId { get; set; }
    }
}
