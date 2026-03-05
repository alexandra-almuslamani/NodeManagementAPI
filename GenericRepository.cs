using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using NodeManagementAPI.Core.Dtos;
using NodeManagementAPI.Core.Entities.OrgManagementEntities;
using NodeManagementAPI.Core.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace NodeManagementAPI.Infrastructure.Repository
{
    public class GenericRepository<T> : IRepository<T> where T : class
    {
        // Custom method added by Alexandra
        public async Task<IEnumerable<Node>> GetChildrenAsync(int parentId)
        {
            // gets the children(that not deleted) of the Node
            var parentEntity = await _dbSet.OfType<Node>()
            .Include(n => n.Children.Where(c => c.StatusId != 4))
            .FirstOrDefaultAsync(n => n.Id == parentId);

            return parentEntity?.Children ?? new List<Node>();
        }
		}
}
