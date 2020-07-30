using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workshop.DAL.Domain;
using Workshop.DAL.Mapping.Response;
using Workshop.DAL.Repository.UnitOfWork;
using Workshop.Entities.ApiModels.Employee;
using Workshop.Entities.DTO.Employee;

namespace Workshop.BLL.Employee.Operational
{
    public class EmployeeOperationaFunc : IEmployeeOperationaFunc
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IEmployeeMappingResponse _employeeMappingResponse;
        public EmployeeOperationaFunc(IUnitOfWork unitOfWork, IEmployeeMappingResponse employeeMappingResponse)
        {
            this._unitOfWork = unitOfWork;
            this._employeeMappingResponse = employeeMappingResponse;
        }
        public int CreateEmployee(EmployeeReq employeeReq)
        {
            // Map Model
            var empDBModel = _employeeMappingResponse.MapEmployeeReqToDBModel(employeeReq);
            // Add Object To Database
            _unitOfWork.EmployeeRepository.Add(empDBModel);
            _unitOfWork.SaveChanges();
            return empDBModel.Id;
        }

        public void DeleteEmployee(int id)
        {
            _unitOfWork.EmployeeRepository.RemoveById(id);
            _unitOfWork.SaveChanges();
        }

        public void UpdateEmployee(EmployeeReq employeeReq)
        {
            // Map Model
            var emoDbModel = _employeeMappingResponse.MapEmployeeReqToDBModel(employeeReq);
            // Update Employee Info
            _unitOfWork.EmployeeRepository.Update(emoDbModel);
            _unitOfWork.SaveChanges();

        }
    }
}
