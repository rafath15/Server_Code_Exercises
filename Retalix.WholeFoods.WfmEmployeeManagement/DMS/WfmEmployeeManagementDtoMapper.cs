using Retalix.StoreServices.Model.Infrastructure.DataMovement;
using Retalix.StoreServices.Model.Infrastructure.DataMovement.Versioning;
using Retalix.WholeFoods.WfmEmployeeManagement.DAL;
using System;
using System.Linq;

namespace Retalix.WholeFoods.WfmEmployeeManagement.DMS
{
    public class WfmEmployeeManagementDtoMapper : IEntityToDtoMapper
    {
        public INamedObject MovableToDto(IMovable movable)
        {
            var mapping = (WfmEmployeeManagementDto)movable;
            return new WfmEmployeeManagementDtoDms
            {
                Id = mapping.Id,
                Name = mapping.Name,
                Email = mapping.Email,
                ProjectName = mapping.ProjectName,
                MobileNumber = mapping.MobileNumber
            };
        }

        public IMovable DtoToMovable(INamedObject dto)
        {
            var mapping = (WfmEmployeeManagementDtoDms)dto;
            return new WfmEmployeeManagementDto
            {
                Id = mapping.Id,
                Name = mapping.Name,
                Email = mapping.Email,
                ProjectName = mapping.ProjectName,
                MobileNumber = mapping.MobileNumber
            };
        }
        public Type GetNamedObjectType(string entityName, MappingMetadata mappingMetadata)
        {
            return typeof(WfmEmployeeManagementDtoDms);
        }
        public string[] GetEntityNamesForVersion(string entityName, MappingMetadata mappingMetadata, StoreServices.Model.Infrastructure.UnitOfWork.DataChangeType changeType)
        {
            return new[] { entityName };
        }
        public DtosForVersions[] Map(IMovable[] movables, MappingMetadata mappingMetadata, StoreServices.Model.Infrastructure.UnitOfWork.DataChangeType changeType)
        {
            return mappingMetadata.TargetNodesVersion.Select(
                targetNodeVersion => new DtosForVersions
                {
                    Dtos =
                        movables.Select(MovableToDto).Where(
                            movableToDto => movableToDto != null).ToArray(),
                    Versions = new[] { targetNodeVersion }
                }).ToArray();
        }
        public IMovable[] MapBack(INamedObject[] dtos, MappingMetadata mappingMetadata, StoreServices.Model.Infrastructure.UnitOfWork.DataChangeType changeType)
        {
            return dtos.Select(DtoToMovable).Where(movable => movable != null).ToArray();
        }
    }
}
