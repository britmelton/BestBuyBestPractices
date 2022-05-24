namespace BestBuyBestPractices
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region notes
            /*The Dapper Framework extends the IDbConnection interface available under the System.Data namespace (using directive). It has many extension
             methods defined under the SqlMapper class found under the using Dapper namespace (using directive).*/

            /*In order to use Dapper you need to declare an IDbConnection object and intitialize it to a SqlConnection to connect the database.*/
            #endregion

            Department.ListDepartments();

            Department.DepartmentUpdate();
        }

    }
}
