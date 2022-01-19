using AutoMapper;
using Core.Models;
using Services.DataTransferObjects.OperationDTOs;
using Services.DataTransferObjects.OperationTypesDTOs;

namespace Task12.AutoMapperProfiles {
    public class UserProfile : Profile {

        public UserProfile() {
            CreateMap<OperationType, OperationTypeDTO>();
            CreateMap<OperationTypeDTO, OperationType>();
            CreateMap<OperationTypeForCreateDTO, OperationTypeDTO>();
            CreateMap<OperationTypeForUpdateDTO, OperationTypeDTO>();


            CreateMap<Operation, OperationDTO>()
                .ForMember(x => x.OperationType, 
                    y => y.MapFrom(src => src.OperationType.Name));
            CreateMap<OperationDTO, Operation>();
            CreateMap<OperationForCreateDTO, OperationDTO>();
            CreateMap<OperationDTO, OperationForCreateDTO>();
            CreateMap<OperationForUpdateDTO, OperationDTO>();
        }
    }
}
