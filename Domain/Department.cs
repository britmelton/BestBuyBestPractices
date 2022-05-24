using Domain.Repositories;
using System;


namespace BestBuyBestPractices
{
    public class Department
    {
        public int DepartmentID { get; set; }
        public string Name { get; set; }


        public static void DepartmentUpdate()
        {
            var configuration = new ConnectionStringProvider();
            using var conn = configuration.GetConnectionString();

            var repo = new DapperDepartmentRepository(conn);

            Console.WriteLine($"Would you like to update a department name? yes or no");

            if (Console.ReadLine().ToUpper() == "YES")
            {
                Console.WriteLine($"What is the ID of the Department you would like to update?");

                var id = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine($"What would you like to change the name of the department to?");

                var newName = Console.ReadLine();

                repo.UpdateDepartment(id, newName);

                var depts = repo.GetAllDepartments();

                foreach (var item in depts)
                {
                    Console.WriteLine($"{item.DepartmentID} {item.Name}");
                }
            }
        }

        public static void ListDepartments()
        {
            var configuration = new ConnectionStringProvider();
            using var conn = configuration.GetConnectionString();

            var repo = new DapperDepartmentRepository(conn);

            var departments = repo.GetAllDepartments();

            Console.WriteLine("Departments:");
            foreach (var item in departments)
            {
                Console.WriteLine($"{item.DepartmentID} {item.Name}");
            }
        }
    }
}
