using Microsoft.EntityFrameworkCore.Storage;
using SboxServersManager.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SboxServersManager.Infrastructure.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ServersManagerDbContext _context;
        private IDbContextTransaction _transaction;

        public UnitOfWork(ServersManagerDbContext context)
        {
            _context = context;
        }

        public async Task BeginTransactionAsync()
        {
            _transaction = await _context.Database.BeginTransactionAsync();
        }

        public async Task CommitAsync()
        {
            await _transaction.CommitAsync();
        }

        public async Task RollbackAsync()
        {
            await _transaction.RollbackAsync();
        }
    }
}
