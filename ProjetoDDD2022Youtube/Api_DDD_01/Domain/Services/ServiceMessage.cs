using Domain.Interfaces;
using Domain.Interfaces.InterfaceServices;
using Etidades.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services
{
    public class ServiceMessage : IServiceMessage
    {
        private readonly IMessage _iMessagge;

        public ServiceMessage(IMessage iMessagge)
        {
            _iMessagge = iMessagge;
        }

        public async Task Adicionar(Message objeto)
        {
            var validaMessagge = objeto.ValidaPripriedadeString(objeto.Titulo, "Titulo");
            if (validaMessagge)
            {
                objeto.DataCadastro = DateTime.Now;
                objeto.DataAlteração = DateTime.Now;
                objeto.Ativo = true;
                await _iMessagge.Add(objeto);
                
            }
        }

        public async Task Atualizar(Message objeto)
        {
            var validaMessagge = objeto.ValidaPripriedadeString(objeto.Titulo, "Titulo");
            if (validaMessagge)
            {
                objeto.DataAlteração = DateTime.Now;
               
                await _iMessagge.Update(objeto);
            }
        }

        public async Task<List<Message>> ListarMessageAtivas()
        {
            return await _iMessagge.ListarMessage(m => m.Ativo);
        }
    }
}
