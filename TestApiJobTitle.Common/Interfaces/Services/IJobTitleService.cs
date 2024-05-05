using TestApiJobTitle.Common.Models;
using TestApiJobTitle.Common.Models.JobTitle;

namespace TestApiJobTitle.Common.Interfaces.Services;

public interface IJobTitleService
{
    Task<List<JobTitleViewModel>> GetJobTitlesAsync(PagingModel? pagingModel = default,
        CancellationToken cancellationToken = default);

    Task<JobTitleViewModel?> GetJobTitleByIdAsync(Guid id, CancellationToken cancellationToken = default);
    Task<Guid> CreateJobTitleAsync(JobTitleCreateModel model, CancellationToken cancellationToken = default);
    Task DeleteJobTitleAsync(Guid id, CancellationToken cancellationToken = default);
    Task UpdateJobTitleAsync(Guid id, JobTitleUpdateModel model);
}