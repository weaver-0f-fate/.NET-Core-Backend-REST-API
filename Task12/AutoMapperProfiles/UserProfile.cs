using AutoMapper;
using Core.Models;
using Services.DataTransferObjects.OperationDTOs;
using Services.DataTransferObjects.OperationTypesDTOs;

namespace Task12.AutoMapperProfiles {
    public class UserProfile : Profile {

        public UserProfile() {
            CreateMap<OperationType, OperationTypeDTO>()
                .ReverseMap();
            CreateMap<OperationTypeForCreateDTO, OperationType>();
            CreateMap<OperationTypeForUpdateDTO, OperationType>();


            CreateMap<Operation, OperationDTO>()
                .ForMember(x => x.OperationTypeName, y => y.MapFrom(src => src.OperationType.Name))
                .ReverseMap();
            CreateMap<OperationForCreateDTO, Operation>();
            CreateMap<OperationForUpdateDTO, Operation>();
        }
    }
}
