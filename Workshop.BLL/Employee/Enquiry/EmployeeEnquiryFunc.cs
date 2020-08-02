using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workshop.DAL.Domain;
using Workshop.DAL.Mapping.Response;
using Workshop.DAL.Repository.UnitOfWork;
using Workshop.Entities.ApiModels.Employee.Response;
using Workshop.Entities.DTO.Employee;

namespace Workshop.BLL.Employee.Enquiry
{
    public class EmployeeEnquiryFunc : IEmployeeEnquiryFunc
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IEmployeeMappingResponse _employeeMappingResponse;


        public EmployeeEnquiryFunc(IUnitOfWork unitOfWork, IEmployeeMappingResponse employeeMappingResponse)
        {
            this._unitOfWork = unitOfWork;
            this._employeeMappingResponse = employeeMappingResponse;
        }
        public EmployeesResponse GetAllEmployee()
        {
            // Get Data From DB
            var employees = _unitOfWork.EmployeeRepository.GetAll();
            if (employees == null)
            {
                return new EmployeesResponse { IsSuccessful = false, EmployeesList = null, ResponseCode = System.Net.HttpStatusCode.NotFound, ResponseMessages = new List<string> { "No data found" } };
            }
            // Map Result to DTO
            var employeeDTO = _employeeMappingResponse.MapEmployeeDBModelToEmployeeDTO(employees);
            employeeDTO.IsSuccessful = true;
            employeeDTO.ResponseCode = System.Net.HttpStatusCode.OK;
            return employeeDTO;
        }

        public EmployeeResponse GetEmployeeById(int id)
        {
            // Get Data From DB
            var employee = _unitOfWork.EmployeeRepository.GetById(id);
            if (employee == null)
            {
                return new EmployeeResponse { IsSuccessful = false, Employee = null, ResponseCode = System.Net.HttpStatusCode.NotFound, ResponseMessages = new List<string> { "No data found" } };
            }
            // Map Result
            var employeeDTO = _employeeMappingResponse.MapEmployeeDBModelToEmployeeDTO(employee);
            employeeDTO.IsSuccessful = true;
            employeeDTO.ResponseCode = System.Net.HttpStatusCode.OK;
            return employeeDTO;
        }
    }
}
