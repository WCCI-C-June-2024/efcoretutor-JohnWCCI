using EFCoreTutoral.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace EFCoreTutoral.Controllers
{
    public abstract class BaseController<TEntity> : ControllerBase
        where TEntity : class
    {
        private readonly MusicContext context;
        private readonly ILogger logger;

        public BaseController(MusicContext context, ILogger logger)
        {
            this.context = context;
            this.logger = logger;
        }

        protected DbContext DataContext { get => context; }

        [HttpGet]
        public virtual async Task<ActionResult<List<TEntity>>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            List<TEntity> result = new List<TEntity>();
            try
            {
                result = await DataContext.Set<TEntity>()
                    .AsNoTracking()
                    .ToListAsync(cancellationToken);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Get all Failed");
                throw;
            }
            return result;
        }

        [HttpGet("GetById")]
        public virtual async Task<ActionResult<TEntity?>> GetByIdAsync(int id, CancellationToken cancellation = default)
        {
           return await GetByIDAsync(id, cancellation); 
        }

        [HttpGet("GetByPage")]
        public virtual async Task<List<TEntity>> GetByPageAsync(int pageNumber, int pageSize, CancellationToken cancellationToken = default)
        {
            int startingRecordNumber = (pageNumber - 1) * pageSize;
            IQueryable<TEntity> query = DataContext.Set<TEntity>()
                 .AsNoTracking()
                .Skip(startingRecordNumber)
                .Take(pageSize);
            return await query.ToListAsync(cancellationToken);
        }

        [HttpPost]
        public virtual async Task<TEntity> AddAsync(TEntity entity, CancellationToken cancellationToken = default)
        {
            await DataContext.Set<TEntity>().AddAsync(entity,cancellationToken);
            await DataContext.SaveChangesAsync(cancellationToken);
            return entity;
        }

        [HttpPut]
        public virtual async Task<TEntity> UpdateAsync(TEntity entity, CancellationToken cancellationToken = default)
        {
            DataContext.Set<TEntity>().Add(entity).State = EntityState.Modified;
            await DataContext.SaveChangesAsync(cancellationToken);
            return entity;
        }

        [HttpDelete]
        public virtual async ValueTask<bool> DeleteAsync(int Id, CancellationToken cancellationToken)
        {
            bool result = false;
            TEntity? entity = await GetByIDAsync(Id, cancellationToken);
            if (entity is not null) {
                DataContext.Remove(entity);
                await DataContext.SaveChangesAsync(cancellationToken);
                result = true;
            }
            return result;

        }

        [HttpGet("FindAll")]
        public virtual async Task<List<TEntity>> FindEntityAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default)
        {
            IQueryable<TEntity> query = DataContext.Set<TEntity>()
                .AsNoTracking()
                .Where(predicate);
            return await query.ToListAsync();
        }

        private async Task<TEntity?> GetByIDAsync(int id , CancellationToken cancellationToken  = default)
        {
            IQueryable<TEntity?> query = DataContext.Set<TEntity>()
                .AsNoTracking()
               .Where(w => EF.Property<int>(w, "Id") == id);
            return await query.FirstOrDefaultAsync();
        }
    }
}
