using AutoMapper;
using TestApiJobTitle.Common.Interfaces.Repositories;
using TestApiJobTitle.Common.Interfaces.Services;
using TestApiJobTitle.Common.Models;
using TestApiJobTitle.Common.Models.JobTitle;
using TestApiJobTitle.Domain.Entities;

namespace TestApiJobTitle.Services.Services;

internal sealed class JobTitleService : IJobTitleService
{
    private readonly IJobTitleRepository _jobTitleRepository;
    private readonly IMapper _mapper;

    public JobTitleService(IJobTitleRepository jobTitleRepository, IMapper mapper)
    {
        _jobTitleRepository = jobTitleRepository;
        _mapper = mapper;
    }

    public async Task<List<JobTitleViewModel>> GetJobTitlesAsync(PagingModel? pagingModel = default, CancellationToken cancellationToken = default)
    {
        var entities = await _jobTitleRepository.GetJobTitlesAsync(pagingModel, cancellationToken);
        return _mapper.Map<List<JobTitleViewModel>>(entities);
    }

    public async Task<JobTitleViewModel?> GetJobTitleByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var entity = await _jobTitleRepository.GetJobTitleByIdAsync(id, cancellationToken);
        return _mapper.Map<JobTitleViewModel>(entity);
    }

    public async Task<Guid> CreateJobTitleAsync(JobTitleCreateModel model,
        CancellationToken cancellationToken = default)
    {
        var result = await _jobTitleRepository.CreateJobTitleAsync(_mapper.Map<JobTitle>(model),
            cancellationToken: cancellationToken);
        await _jobTitleRepository.SaveAsync(cancellationToken);

        return result;
    }

    public async Task DeleteJobTitleAsync(Guid id, CancellationToken cancellationToken = default)
    {
        await _jobTitleRepository.DeleteJobTitleAsync(id, cancellationToken);
        await _jobTitleRepository.SaveAsync(cancellationToken);
    }

    public async Task UpdateJobTitleAsync(Guid id, JobTitleUpdateModel model)
    {
        var entity = _mapper.Map<JobTitle>(model);
        entity.Id = id;

        await _jobTitleRepository.UpdateJobTitleAsync(entity);
        await _jobTitleRepository.SaveAsync();
    }
}