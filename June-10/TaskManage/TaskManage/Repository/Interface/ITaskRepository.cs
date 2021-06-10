using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using TaskManage.Models;

namespace TaskManage.Repository.Interface
{
    public interface ITaskRepository
    {
		List<TaskModel> GetCustomers(int amount, string sort);
		TaskModel GetSingleCustomer(int customerId);
		bool InsertCustomer(TaskModel ourCustomer);
		bool DeleteCustomer(int customerId);
		bool UpdateCustomer(TaskModel ourCustomer);
	}
}
