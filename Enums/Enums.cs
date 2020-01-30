using System;

namespace Enums
{
    public class Enums
    {
        public enum RoleGroup
        {
            Employee = 1,
            Customer = 2
        }
        public enum CustomerRoles
        {
            GetCustomer = 1,
            GetCustomerById = 2,
            GetCustomerList = 4
        }
        public enum EmployeeRoles
        {
            GetEmployees = 1,
            GetEmployeeWithTerritories = 2,
            UpdateEmployee = 4
        }
    }
}
