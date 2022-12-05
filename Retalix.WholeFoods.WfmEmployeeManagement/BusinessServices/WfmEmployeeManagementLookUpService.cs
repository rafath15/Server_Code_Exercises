using Common.Logging;
using Retalix.Contracts.Generated.Arts.PosLogV6.Source;
using Retalix.Contracts.Generated.Common;
using Retalix.StoreServices.Model.Infrastructure.Service;
using Retalix.Wholefoods.Contracts.Generated.WfmEmployeeManagement;
using Retalix.WholeFoods.Common.Services;
using Retalix.WholeFoods.WfmEmployeeManagement.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using Retalix.StoreServices.Model.Infrastructure.Exceptions;

namespace Retalix.WholeFoods.WfmEmployeeManagement.BusinessServices
{
    public class WfmEmployeeManagementLookUpService : BusinessServiceBase<WfmEmployeeManagementLookUpRequest, WfmEmployeeManagementLookUpResponse>
    {
        private readonly IWfmEmployeeManagementLookUp _employeeManagementLookUp;
        private IList<IWfmEmployeeManagement> _employeeManagements;
        private static readonly ILog Log = LogManager.GetCurrentClassLogger();
        private readonly IWfmEmployeeManagementFactory _employeeManagementFactory;

        public WfmEmployeeManagementLookUpService(IWfmEmployeeManagementLookUp employeeManagementLookUp, IWfmEmployeeManagementFactory employeeManagementFactory)
        {
            _employeeManagementLookUp = employeeManagementLookUp;
            _employeeManagementFactory = employeeManagementFactory;
        }
        public IDocumentResponse FormatErrorResponse(IDocumentRequest request, Exception exception)
        {
            var returnResponse = new WfmEmployeeManagementLookUpResponse
            {
                Header = new RetalixCommonHeaderType
                {
                    Response = new RetalixResponseCommonData
                    {
                        BusinessError =
                            GetContractBusinessError(
                                exception),
                        ResponseCode = "Rejected"
                    }
                }
            };
            return new DocumentResponse(returnResponse);
        }
        protected override void DoExecute()
        {
            if(Request.SearchCriteria == null)
            {
                _employeeManagements = _employeeManagementLookUp.GetAllEmployees();
            }
            else
            {
                _employeeManagements = _employeeManagementLookUp.FindEmployees(Request.SearchCriteria);
            }
        }
        protected override IDocumentResponse BuildResponse(WfmEmployeeManagementLookUpResponse response)
        {
            base.BuildResponse(response);
            
            if (_employeeManagements.Any())
                response.EmployeeManagement = _employeeManagements.Select(ConvertFromConcreteToDto).ToArray();
            
            IDocumentResponse documentResponse = new DocumentResponse(response);
            return documentResponse;
        }
        private static RetalixBusinessErrorCommonData[] GetContractBusinessError(Exception exception)
        {
            var contractError = new RetalixBusinessErrorCommonData
            {
                Description = new DescriptionCommonData
                {
                    Value = exception.Message
                }
            };
            if (exception is BusinessException)
            {
                string code = ((BusinessException)exception).ErrorCode;
                contractError.Code = code;
            }
            return new[] { contractError };
        }
        private EmployeeManagementType ConvertFromConcreteToDto(IWfmEmployeeManagement arg)
        {
            return new EmployeeManagementType
            {
                Name = arg.Name,
                ProjectName = arg.ProjectName,
                Email = arg.Email,
                MobileNumber = arg.MobileNumber,
                Id= arg.Id
            };
        }
    }
}
