using System.Net;
using Microsoft.EntityFrameworkCore;
using TestApiJobTitle.Common.Constants;
using TestApiJobTitle.Common.Exceptions;
using TestApiJobTitle.Common.Interfaces.Repositories;
using TestApiJobTitle.Common.Models;
using TestApiJobTitle.Domain.Entities;
using TestApiJobTitle.Persistence.Database;

namespace TestApiJobTitle.Persistence.Repositories;

internal sealed class JobTitleRepository : IJobTitleRepository
{
    private readonly JobTitleDbContext _context;

    public JobTitleRepository(JobTitleDbContext context)
    {
        _context = context;
    }

    public Task<List<JobTitle>> GetJobTitlesAsync(PagingModel pagingModel = null,
        CancellationToken cancellationToken = default)
    {
        pagingModel ??= new();

        return _context.JobTitles.Skip(pagingModel.Page * pagingModel.PageSize).Take(pagingModel.PageSize)
            .ToListAsync(cancellationToken: cancellationToken);
    }

    public async Task<JobTitle> GetJobTitleByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var result = await _context.JobTitles.FirstOrDefaultAsync(entity => entity.Id.Equals(id),
            cancellationToken: cancellationToken);

        if (result is null)
        {
            throw new BusinessException(HttpStatusCode.NotFound, ErrorMessages.ObjectNotFound);
        }

        return result;
    }

    public async Task<Guid> CreateJobTitleAsync(JobTitle jobTitle, CancellationToken cancellationToken = default)
    {
        jobTitle.Id = Guid.NewGuid();
        
        var entity = await _context.JobTitles.AddAsync(jobTitle, cancellationToken);

        return entity.Entity.Id;
    }

    public async Task DeleteJobTitleAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var entity = await _context.JobTitles.FindAsync(id, cancellationToken);
        
        if (entity is null)
        {
            return;
        }
        
        _context.JobTitles.Remove(entity);
    }

    public Task UpdateJobTitleAsync(JobTitle jobTitle)
    {
        _context.Entry(jobTitle).State = EntityState.Modified;
        
        return Task.CompletedTask;
    }

    public Task SaveAsync(CancellationToken cancellationToken = default)
    {
        return _context.SaveChangesAsync(cancellationToken);
    }
}