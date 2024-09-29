using AutoMapper;
using CourseRoleWebAPI.Dtos;
using CourseRoleWebAPI.Models;



namespace CourseRoleWebAPI.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Course, CourseDto>()
            .ForMember(dest => dest.id_course, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.namedto, opt => opt.MapFrom(src => src.Name))
            .ForMember(dest => dest.descriptiondto, opt => opt.MapFrom(src => src.Description))
            .ForMember(dest => dest.type, opt => opt.MapFrom(src => src.CourseTypeId));

            CreateMap<CourseDto, Course>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.id_course))
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.namedto))
            .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.descriptiondto))
            .ForMember(dest => dest.CourseTypeId, opt => opt.MapFrom(src => src.type));


            CreateMap<Log, LogDto>()
            .ForMember(dest => dest.datadto, opt => opt.MapFrom(src => src.Data))
            .ForMember(dest => dest.dataiddto, opt => opt.MapFrom(src => src.DataId))
            .ForMember(dest => dest.datedto, opt => opt.MapFrom(src => src.Date))
            .ForMember(dest => dest.userdto, opt => opt.MapFrom(src => src.User));

            CreateMap<LogDto, Log>()
            .ForMember(dest => dest.Data, opt => opt.MapFrom(src => src.datadto))
            .ForMember(dest => dest.DataId, opt => opt.MapFrom(src => src.dataiddto))
            .ForMember(dest => dest.Date, opt => opt.MapFrom(src => src.datedto))
            .ForMember(dest => dest.User, opt => opt.MapFrom(src => src.userdto));

            CreateMap<CourseType, CourseTypeDto>()
                .ForMember(dest => dest.id_type, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.nametype, opt => opt.MapFrom(src => src.Name));

            CreateMap<CourseTypeDto, CourseType>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.id_type))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.nametype));

            CreateMap<Permission, PermissionDto>();

        }
    }
}
