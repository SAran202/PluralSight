using System;
using System.Collections.Generic;
using System.Linq;
using TaskManage.Services.Interface;
using Microsoft.Extensions.Configuration;
using Dapper;
using System.Data;
using System.Data.SqlClient;
using System.Data.Common;
using TaskManage.Repository.Interface;
using TaskManage.Models;

namespace TaskManage.Services
{
    public class TaskServices : ITaskServices
    {
        private readonly ITaskRepository _taskRepository;
        public TaskServices(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        public List<TaskModel> GetCustomers(int amount, string sort) => _taskRepository.GetCustomers(int amount, string sort);
        public TaskModel GetSingleCustomer(int customerId) => _taskRepository.GetSingleCustomer(int customerId);
        public bool InsertCustomer(TaskModel ourCustomer) => _taskRepository.InsertCustomer(TaskModel ourCustomer);
        public bool DeleteCustomer(int customerId) => _taskRepository.DeleteCustomer(int customerId);
        public bool UpdateCustomer(TaskModel ourCustomer) => _taskRepository.UpdateCustomer(TaskModel ourCustomer);
    }
}