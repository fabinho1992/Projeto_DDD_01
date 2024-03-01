using Domain.Interfaces;
using Etidades.Entities;
using Infrastructure.Configuration;
using Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class RepositoryMessage : RepositoryGeneric<Message>, IMessage
    {
        private readonly DbContextOptions<ContextBase> _dbContext;

        public RepositoryMessage()
        {
            _dbContext = new DbContextOptions<ContextBase>();
        }

        public async Task<List<Message>> ListarMessage(Expression<Func<Message, bool>> exMessage)// uso a EXPRESSION  para obter apenas messaes ativas
        {
            using (var banco = new ContextBase(_dbContext))
            {
                return await banco.Messages.Where(exMessage).AsNoTracking().ToListAsync();
            }
        }
    }
}
