using NHibernate;
using NHibernate.Criterion;
using Retalix.StoreServices.Model.Infrastructure.DataAccess;
using Retalix.StoreServices.Model.Infrastructure.DataMovement;
using Retalix.StoreServices.Model.Infrastructure.Exceptions;
using Retalix.Wholefoods.Contracts.Generated.WfmEmployeeManagement;
using Retalix.WholeFoods.WfmEmployeeManagement.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using Retalix.WholeFoods.WfmEmployeeManagement.BusinessComponents;
using Retalix.WholeFoods.WfmEmployeeManagement.Exceptions;

namespace Retalix.WholeFoods.WfmEmployeeManagement.DAL
{
    public class EmployeeManagementDao : IWfmEmployeeManagementDao
    {
        ISessionProvider<ISession> _sessionProvider;

        private const string DuplicateKeyError = "Cannot insert duplicate key";
        public EmployeeManagementDao(ISessionProvider<ISession> sessionProvider)
        {
            _sessionProvider = sessionProvider;
        }

        #region Adding Employees Data
        public void Add(BusinessComponents.WfmEmployeeManagementType employee)
        {
            AddEmployee(employee);
        }
        public void AddEmployee(BusinessComponents.WfmEmployeeManagementType employee)
        {
            try
            {
                if (employee.Id == 0)
                {
                    throw new WfmEmployeeManagementException("Employee with Id as 0 cannot be added", "WfmEmployeeManagementException");
                }
                _sessionProvider.Session.Save(employee);
                _sessionProvider.Session.Flush();
            }
            catch (Exception exception)
            {
                var sqlException = exception.InnerException;
                if (sqlException != null && sqlException is SqlException && sqlException.ToString().Contains(DuplicateKeyError))
                {
                    throw new WfmEmployeeManagementException("Employee with same id already exists", "WfmEmployeeManagementException");
                }
                throw;
            }
        }
        #endregion

        #region Updating the Employee data
        public void Update(BusinessComponents.WfmEmployeeManagementType employee)
        {
            UpdateEmployee(employee);
        }
        public void UpdateEmployee(BusinessComponents.WfmEmployeeManagementType employee)
        {
            var id = employee.Id;

            var item = GetById(id);
            if (item == null)
            {
                throw new WfmEmployeeManagementException("Employee data was not found", "WfmEmployeeManagementException");
            }
            item.Name = string.IsNullOrEmpty(employee.Name)?item.Name: employee.Name;
            item.ProjectName = string.IsNullOrEmpty(employee.ProjectName) ? item.ProjectName: employee.ProjectName;
            item.Email = string.IsNullOrEmpty(employee.Email)? item.Email :employee.Email;
            item.MobileNumber = string.IsNullOrEmpty(employee.MobileNumber)? item.MobileNumber: employee.MobileNumber;

            _sessionProvider.Session.SaveOrUpdate(item);
        }
        #endregion

        #region Getting the employees data

        public IList<IWfmEmployeeManagement> GetAllEmployees()
        {
            var query = _sessionProvider.Session.GetNamedQuery("EmployeeData");
            return query.List<IWfmEmployeeManagement>();
        }

        public IList<IWfmEmployeeManagement> FindEmployees(SearchCriteriaType search)
        {
            var query = _sessionProvider.Session.GetNamedQuery("WfmEmployeeManagementLookUpByCriteria5");
            if (search.Id != 0 && search.Name != null && search.ProjectName != null)
            {
                query =_sessionProvider.Session.GetNamedQuery("WfmEmployeeManagementLookUpByCriteria1");
                query.SetParameter("Id", search.Id);
                query.SetParameter("Name", search.Name);
                query.SetParameter("ProjectName", search.ProjectName);
            }
            else if (search.Id != 0 && search.Name != null)
            {
                query = _sessionProvider.Session.GetNamedQuery("WfmEmployeeManagementLookUpByCriteria2");
                query.SetParameter("Id", search.Id);
                query.SetParameter("Name", search.Name);
                query.SetParameter("ProjectName", search.ProjectName);
            }
            else if (search.Id != 0 && search.ProjectName != null)
            {
                query = _sessionProvider.Session.GetNamedQuery("WfmEmployeeManagementLookUpByCriteria3");
                query.SetParameter("Id", search.Id);
                query.SetParameter("ProjectName", search.ProjectName);
            }
            else if (search.Name != null && search.ProjectName != null)
            {
                query = _sessionProvider.Session.GetNamedQuery("WfmEmployeeManagementLookUpByCriteria4");
                query.SetParameter("Name", search.Name);
                query.SetParameter("ProjectName", search.ProjectName);
            }
            else
            {
                query = _sessionProvider.Session.GetNamedQuery("WfmEmployeeManagementLookUpByCriteria5");
                query.SetParameter("Id", search.Id);
                query.SetParameter("Name", search.Name);
                query.SetParameter("ProjectName", search.ProjectName);
            }
            var employeeList = query.List<IWfmEmployeeManagement>();
            if (employeeList.Any())
            {
                return employeeList;
            }
            else
            {
               throw new WfmEmployeeManagementException(" Employee Data not found", "WfmEmployeeManagementException");
            }
        }
        #endregion

        #region Deleting the Employees data
        public void Delete(BusinessComponents.WfmEmployeeManagementType employee)
        {
            DeleteEmployee(employee);
        }
        
        public void DeleteEmployee(BusinessComponents.WfmEmployeeManagementType employee)
        {
            var employeeData = GetById(employee.Id);
            if (employeeData != null)
            {
                _sessionProvider.Session.Delete(employeeData);
                _sessionProvider.Session.Flush();
            }
        }
        public WfmEmployeeManagementType GetById(int id)
        {
            var criteria = _sessionProvider.Session.CreateCriteria<WfmEmployeeManagementType>();
            if (id == 0) return null;
            criteria.Add(Restrictions.Eq("Id", id));
            var result = criteria.List<WfmEmployeeManagementType>();
            return result.FirstOrDefault();
        }
        #endregion

        #region DMS

        public void Add(IEnumerable<IMovable> movables)
        {
            foreach (var movable in movables)
            {
                _sessionProvider.Session.Save(movable);
            }
        }
        public void Update(IEnumerable<IMovable> movables)
        {
            movables.ToList().ForEach(_sessionProvider.Session.Update);
        }
        public void Delete(IEnumerable<IMovable> movables)
        {
            movables.ToList().ForEach(_sessionProvider.Session.Delete);
        }
        #endregion DMS
    }
}



