using Domain.Interfaces;
using Etidades.Entities;
using Infrastructure.Configuration;
using Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
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


    }
}
