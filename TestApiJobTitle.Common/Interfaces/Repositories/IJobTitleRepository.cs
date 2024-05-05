using TestApiJobTitle.Common.Models;
using TestApiJobTitle.Domain.Entities;

namespace TestApiJobTitle.Common.Interfaces.Repositories;

public interface IJobTitleRepository
{
    Task<List<JobTitle>> GetJobTitlesAsync(PagingModel? pagingModel = default,
        CancellationToken cancellationToken = default);

    Task<JobTitle> GetJobTitleByIdAsync(Guid id, CancellationToken cancellationToken = default);
    Task<Guid> CreateJobTitleAsync(JobTitle jobTitle, CancellationToken cancellationToken = default);
    Task DeleteJobTitleAsync(Guid id, CancellationToken cancellationToken = default);
    Task UpdateJobTitleAsync(JobTitle jobTitle);
    Task SaveAsync(CancellationToken cancellationToken = default);
}