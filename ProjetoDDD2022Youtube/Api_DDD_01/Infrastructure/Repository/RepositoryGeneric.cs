﻿using Domain.Interfaces.Generics;
using Infrastructure.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Win32.SafeHandles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository
{
    public class RepositoryGeneric<T> : IGeneric<T>, IDisposable where T : class
    {
        private readonly DbContextOptions<ContextBase> _dbContext;

        public RepositoryGeneric()
        {
            _dbContext = new DbContextOptions<ContextBase>();
        }

        public async Task Add(T entity)
        {
            using (var data = new ContextBase(_dbContext))
            {
                await data.Set<T>().AddAsync(entity);
                await data.SaveChangesAsync();

            }
        }

        public async Task Delete(T entity)
        {
            using (var data = new ContextBase(_dbContext))
            {
                data.Set<T>().Remove(entity);
                await data.SaveChangesAsync();  
            }
        }

        public async Task Update(T entity)
        {
            using(var data = new ContextBase(_dbContext))
            {
                data.Set<T>().Update(entity);
                await data.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            using (var data = new ContextBase(_dbContext))
            {
                return await data.Set<T>().ToListAsync();
            }
        }

        public async Task<T> GetById(int id)
        {
            using(var data = new ContextBase(_dbContext))
            {
                return await data.Set<T>().FindAsync(id);
            }
        }

        

        #region Disposed https://docs.microsoft.com/pt-br/dotnet/standard/garbage-collection/implementing-dispose
        // Flag: Has Dispose already been called?
        bool disposed = false;
        // Instantiate a SafeHandle instance.
        SafeHandle handle = new SafeFileHandle(IntPtr.Zero, true);



        // Public implementation of Dispose pattern callable by consumers.
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }


        // Protected implementation of Dispose pattern.
        protected virtual void Dispose(bool disposing)
        {
            if (disposed)
                return;

            if (disposing)
            {
                handle.Dispose();
                // Free any other managed objects here.
                //
            }

            disposed = true;
        }
        #endregion
    }


}
