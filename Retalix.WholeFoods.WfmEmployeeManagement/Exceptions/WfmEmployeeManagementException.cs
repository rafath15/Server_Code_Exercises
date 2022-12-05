using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Retalix.StoreServices.Model.Infrastructure.Exceptions;

namespace Retalix.WholeFoods.WfmEmployeeManagement.Exceptions
{
    public class WfmEmployeeManagementException:BusinessException
    {
        public WfmEmployeeManagementException(string errorMessage, string code) : base(errorMessage, code) { }
    }
}
