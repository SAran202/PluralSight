using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using TaskManage.Models;

namespace TaskManage.Services.Interface
{
    public interface ITaskServices
    {
        List<TaskModel> GetCustomers(int amount, string sort);
        TaskModel GetSingleCustomer(int customerId);
        bool InsertCustomer(TaskModel ourCustomer);
        bool DeleteCustomer(int customerId);
        bool UpdateCustomer(TaskModel ourCustomer);
    }
}
