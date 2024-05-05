using AutoMapper;
using TestApiJobTitle.Common.Models.JobTitle;
using TestApiJobTitle.Domain.Entities;

namespace TestApiJobTitle.Core.MappingProfiles;

public class JobTitleProfile : Profile
{
    public JobTitleProfile()
    {
        CreateMap<JobTitle, JobTitleViewModel>();
        CreateMap<JobTitleBaseModel, JobTitle>()
            .ForMember(dest => dest.Id, options => options.Ignore());
    }
}