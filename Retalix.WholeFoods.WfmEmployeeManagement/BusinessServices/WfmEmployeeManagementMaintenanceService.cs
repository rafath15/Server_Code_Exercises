using Common.Logging;
using Retalix.Contracts.Generated.Common;
using Retalix.StoreServices.Model.Infrastructure.Exceptions;
using Retalix.StoreServices.Model.Infrastructure.OLAMessage.Exceptions;
using Retalix.StoreServices.Model.Infrastructure.Service;
using Retalix.Wholefoods.Contracts.Generated.WfmEmployeeManagement;
using Retalix.WholeFoods.Common.Services;
using Retalix.WholeFoods.WfmEmployeeManagement.Exceptions;
using Retalix.WholeFoods.WfmEmployeeManagement.Model;
using System;
using System.Linq;

namespace Retalix.WholeFoods.WfmEmployeeManagement.BusinessServices
{
    public class WfmEmployeeManagementMaintenanceService : BusinessServiceBase<WfmEmployeeManagementMaintenanceServiceRequest, WfmEmployeeManagementMaintenanceServiceResponse>
    {
        private readonly IWfmEmployeeManagementMaintenance _iEmployeeManagementMaintenance;
        private static readonly ILog Log = LogManager.GetCurrentClassLogger();
        private readonly IWfmEmployeeManagementFactory _employeeManagementFactory;
        public WfmEmployeeManagementMaintenanceService(IWfmEmployeeManagementMaintenance iEmployeeManagementMaintenance, IWfmEmployeeManagementFactory employeeManagementFactory)
        {
            _iEmployeeManagementMaintenance = iEmployeeManagementMaintenance;
            _employeeManagementFactory = employeeManagementFactory;
        }
        protected override void DoExecute()
        {
            var employeeManagements = Request.EmployeeManagement;
            foreach (var employeeManagement in employeeManagements)
            {
                HandleEmployeeManagementMaintenance(employeeManagement);
            }
        }
        private void HandleEmployeeManagementMaintenance(EmployeeManagementType employeeManagementType)
        {
            BusinessComponents.WfmEmployeeManagementType employeeManagement = _employeeManagementFactory.Create();
            MapContractToModel(employeeManagementType, employeeManagement);

            switch (employeeManagementType.Action)
            {
                case ActionTypeCodes.Add:
                    ValidateBeforeSaving(employeeManagement);
                    _iEmployeeManagementMaintenance.Add(employeeManagement);
                    break;
                case ActionTypeCodes.Update:
                    ValidateBeforeUpdating(employeeManagement);
                    _iEmployeeManagementMaintenance.Update(employeeManagement);
                    break;
                case ActionTypeCodes.Delete:
                    ValidateBeforeDeleting(employeeManagement);
                    _iEmployeeManagementMaintenance.Delete(employeeManagement);
                    break;
                default:
                    throw new NotSupportedActionException("Add, Delete, Update, AddOrUpdate");
            }
        }

        private void ValidateBeforeDeleting(BusinessComponents.WfmEmployeeManagementType employeeManagement)
        {
            if (employeeManagement.Id == 0)
            {
                Log.Error(string.Format("There is no Employee to delete"));
                throw new WfmEmployeeManagementException("Employee details are not found", "WfmEmployeeManagementException");
            }
        }

        private void ValidateBeforeSaving(BusinessComponents.WfmEmployeeManagementType employeeManagement)
        {
            if (employeeManagement.Id==0)
            {
                Log.Error(string.Format("Employee Id is missing"));
                throw new WfmEmployeeManagementException("Id is a mandatory field", "WfmEmployeeManagementException");
            }
            if (employeeManagement.Name == null)
            {
                Log.Error(string.Format("Employee Name is missing"));
                throw new WfmEmployeeManagementException("Name is a mandatory field", "WfmEmployeeManagementException");
            }
            if (employeeManagement.ProjectName == null)
            {
                Log.Error(string.Format("Project Name is missing"));
                throw new WfmEmployeeManagementException("Project Name is a mandatory field", "WfmEmployeeManagementException");
            }
        }
        private void ValidateBeforeUpdating(BusinessComponents.WfmEmployeeManagementType employeeManagement)
        {
            if (employeeManagement.Id == 0)
            {
                Log.Error(string.Format("There is no EmployeeData to save"));
                throw new WfmEmployeeManagementException("There is no EmployeeData to save", "WfmEmployeeManagementException");
            }
        }
        private void MapContractToModel(EmployeeManagementType employeeManagementType, BusinessComponents.WfmEmployeeManagementType employeeManagement)
        {
            employeeManagement.Id = employeeManagementType.Id;
            employeeManagement.Name = employeeManagementType.Name;
            employeeManagement.Email = employeeManagementType.Email;
            employeeManagement.MobileNumber = employeeManagementType.MobileNumber;
            employeeManagement.ProjectName = employeeManagementType.ProjectName;
        }
        public override IDocumentResponse FormatErrorResponse(IDocumentRequest request, Exception exception)
        {
            var response = base.FormatErrorResponse(request, exception);

            if (exception is BusinessException)
                ((WfmEmployeeManagementMaintenanceServiceResponse)response.Response).Header.Response.BusinessError.First().Severity = "Error";

            return response;
        }
    }
}
