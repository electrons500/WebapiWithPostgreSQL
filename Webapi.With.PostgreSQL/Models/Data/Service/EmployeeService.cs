using Microsoft.EntityFrameworkCore;
using Webapi.With.PostgreSQL.Models.Data.ApiModel;
using Webapi.With.PostgreSQL.Models.Data.EmployeeDBContext;

namespace Webapi.With.PostgreSQL.Models.Data.Service
{
    public class EmployeeService
    {
        private EmployeeDBContext.EmployeeDbContext _Ctx;
        public EmployeeService(EmployeeDBContext.EmployeeDbContext ctx)
        {
            _Ctx = ctx;
        }

        //Get all employees
        public async Task<List<EmployeeModel>> GetEmployees()
        {
            List<Employee> employees = await _Ctx.Employees.OrderBy(x => x.Employeeid).ToListAsync();
                                                           
            List<EmployeeModel> model = employees.Select(x => new EmployeeModel
            {
                Employeeid = x.Employeeid,
                Employeename = x.Employeename,
                Age = x.Age,
                City = x.City
            }).ToList();

            return model;

        }

        //Get employee
        public async Task<EmployeeModel> GetEmployee(int employeeId)
        {
            Employee employee = await _Ctx.Employees.Where(x => x.Employeeid == employeeId).FirstOrDefaultAsync();
            EmployeeModel model = new()
            {
                Employeeid = employee.Employeeid,
                Employeename = employee.Employeename,
                Age = employee.Age,
                City = employee.City
            };

            return model;
        }

        //Add employee
        public async Task<bool> AddEmployee(AddEmployeeModel model)
        {
            Employee employee = new() 
            {
                Employeename = model.Employeename,
                Age = model.Age,
                City = model.City
            };

           await _Ctx.Employees.AddAsync(employee);
            await _Ctx.SaveChangesAsync();

            return true;

        }

        //update employee
        public async Task<bool> UpdateEmployee(EmployeeModel model)
        {
            Employee employee = await _Ctx.Employees.Where(x => x.Employeeid == model.Employeeid).FirstOrDefaultAsync();
            employee.Employeename = model.Employeename;
            employee.Age = model.Age;
            employee.City = model.City;
          
            _Ctx.Employees.Update(employee);
            await _Ctx.SaveChangesAsync();

            return true;
        }

        //Delete employee
        public async Task<bool> DeletEmployee(int Id) 
        {
            Employee employee = await _Ctx.Employees.Where(x => x.Employeeid == Id).FirstOrDefaultAsync();
            _Ctx.Employees.Remove(employee);
            await _Ctx.SaveChangesAsync();

            return true;
        }
    }
}
