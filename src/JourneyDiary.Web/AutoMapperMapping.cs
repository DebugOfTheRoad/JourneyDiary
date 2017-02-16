using AutoMapper;
using JourneyDiary.Model.DO;
using JourneyDiary.Model.VO;

namespace JourneyDiary.Web
{
	public class AutoMapperMapping
	{
        public  static IMapper Mapper;

        public static void RegisterMapping()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<CustomerVO, CustomerDO>();
                cfg.CreateMap<CustomerDO, CustomerVO>();
            });

            Mapper = config.CreateMapper();
        }
	}
}