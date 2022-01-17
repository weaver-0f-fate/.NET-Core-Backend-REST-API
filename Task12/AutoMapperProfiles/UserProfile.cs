using AutoMapper;
using Models;
using Services.ModelsDTO;

namespace Task12.AutoMapperProfiles {
    public class UserProfile : Profile {

        public UserProfile() {
            CreateMap<OperationType, OperationTypeDTO>();
            CreateMap<OperationTypeDTO, OperationType>();

            CreateMap<Operation, OperationDTO>()
                .ForMember(x => x.OperationType, 
                    y => y.MapFrom(src => src.OperationType.Name));
            CreateMap<OperationDTO, Operation>();
        }
    }
}
