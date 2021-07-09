using AutoMapper;
using MetricsAgent.DAL;
using MetricsAgent.Responses;

namespace MetricsAgent
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<CpuMetric, CpuMetricDto>();
            CreateMap<RamMetric, RamMetricDto>();
            CreateMap<HddMetric, HddMetricDto>();
            CreateMap<DotNetMetric, DotNetMetricDto>();
            CreateMap<NetworkMetric, NetworkMetricDto>();
        }
    }
}
