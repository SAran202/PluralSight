using System;
using System.Collections.Generic;
using System.Linq;
using TaskManage.Repository.Interface;
using TaskManage.Models;
using Dapper;
using System.Data.SqlClient;
using System.Data;
using System.Data.Common;
using Microsoft.Extensions.Configuration;
using System.Configuration;

namespace TaskManage.Repository
{
	public class TaskRepository : ITaskRepository
	{
		private IDbConnection _db = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
		public List<TaskModel> GetCustomers(int amount, string sort)
		{
			return this._db.Query<TaskModel>("SELECT TOP " + amount + " [CustomerID],[CustomerFirstName],[CustomerLastName],[IsActive] FROM [Employees] ORDER BY CustomerID " + sort).ToList();
		}

		public TaskModel GetSingleCustomer(int customerId)
		{
			return _db.Query<TaskModel>("SELECT[CustomerID],[CustomerFirstName],[CustomerLastName],[IsActive] FROM [Employees] WHERE CustomerID =@CustomerID", new { CustomerID = customerId }).SingleOrDefault();
		}

		public bool InsertCustomer(TaskModel ourCustomer)
		{
			int rowsAffected = this._db.Execute(@"INSERT [Employees]([CustomerFirstName],[CustomerLastName],[IsActive]) values (@CustomerFirstName, @CustomerLastName, @IsActive)", new { CustomerFirstName = ourCustomer.CustomerFirstName, CustomerLastName = ourCustomer.CustomerLastName, IsActive = true });

			if (rowsAffected > 0)
			{
				return true;
			}
			return false;
		}

		public bool DeleteCustomer(int customerId)
		{
			int rowsAffected = this._db.Execute(@"DELETE FROM [Employees] WHERE CustomerID = @CustomerID", new { CustomerID = customerId });

			if (rowsAffected > 0)
			{
				return true;
			}
			return false;
		}

		public bool UpdateCustomer(TaskModel ourCustomer)
		{
			int rowsAffected = this._db.Execute("UPDATE [Employees] SET [CustomerFirstName] = @CustomerFirstName ,[CustomerLastName] = @CustomerLastName, [IsActive] = @IsActive WHERE CustomerID = " + ourCustomer.CustomerID, ourCustomer);

			if (rowsAffected > 0)
			{
				return true;
			}
			return false;
		}
	}
}
