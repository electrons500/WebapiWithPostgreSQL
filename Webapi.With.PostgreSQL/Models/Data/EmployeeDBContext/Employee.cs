using System;
using System.Collections.Generic;

namespace Webapi.With.PostgreSQL.Models.Data.EmployeeDBContext;

public partial class Employee
{
    public int Employeeid { get; set; }

    public string Employeename { get; set; }

    public int Age { get; set; }

    public string City { get; set; }
}
