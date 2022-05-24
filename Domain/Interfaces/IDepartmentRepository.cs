using BestBuyBestPractices;
using System.Collections.Generic;

namespace Domain.Interfaces
{
    public interface IDepartmentRepository
    {
        public IEnumerable<Department> GetAllDepartments();
        public void CreateDepartment(string Name);
    }
}
