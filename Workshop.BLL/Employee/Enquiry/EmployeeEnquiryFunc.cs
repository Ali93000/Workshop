using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workshop.DAL.Domain;
using Workshop.DAL.Mapping.Response;
using Workshop.DAL.Repository.UnitOfWork;
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
        public IEnumerable<EmployeeDTO> GetAllEmployee()
        {
            // Get Data From DB
            var employees = _unitOfWork.EmployeeRepository.GetAll();
            // Map Result to DTO
            var employeeDTO = _employeeMappingResponse.MapEmployeeDBModelToEmployeeDTO(employees);
            return employeeDTO;
        }

        public EmployeeDTO GetEmployeeById(int id)
        {
            // Get Data From DB
            var employee = _unitOfWork.EmployeeRepository.GetById(id);
            // Map Result
            var employeeDTO = _employeeMappingResponse.MapEmployeeDBModelToEmployeeDTO(employee);
            return employeeDTO;
        }
    }
}
