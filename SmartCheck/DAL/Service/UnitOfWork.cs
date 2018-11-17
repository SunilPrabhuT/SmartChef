using SmartChef.DAL.Models;
using SmartChef.DAL.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SmartChef.DAL.Service
{
    /// <summary>
    /// UnitOfWork Class responsible for creating the 
    /// repositories for Db tables and inserting updating 
    /// the records to the DB 
    /// </summary>
    public class UnitOfWork : IUnitOfWork
    {
        /// <summary>
        /// CascadeDb context
        /// </summary>
       private readonly SmartChecfDbContext _dbContext;
        
        /// <inheritdoc />
        /// <summary>
        /// This method will 
        /// insert/update
        /// the entries to the Db
        /// </summary>
        public void Save()
        {
            try
            {
                _dbContext.Configuration.AutoDetectChangesEnabled = false;
                _dbContext.SaveChanges(); // Insert the data to the Db 
            }
            finally
            {
                _dbContext.Configuration.AutoDetectChangesEnabled = true;
            }
        }
        private bool _disposed;
        /// <summary>
        /// Disposes the object
        /// </summary>
        /// <param name="disposing"></param>
        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _dbContext.Dispose();
                }
            }
            _disposed = true;
        }
        /// <summary>
        /// Disposes the Object By
        /// Supressing the Finalize 
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}