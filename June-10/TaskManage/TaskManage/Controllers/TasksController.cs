using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskManage.Models;
using TaskManage.Services.Interface;

namespace TaskManage.Controllers
{
    public class TasksController : Controller
    {
        private readonly ITaskServices _taskServices;
        public TasksController(ITaskServices taskServices)
        {
            _taskServices = taskServices;
        }

        [Route("Customers")]
        [HttpGet]
        public List<TaskModel> Get()
        {
            return _taskServices.GetCustomers(10, "ASC");
        }
        [Route("Customers/{id}")]
        [HttpGet]
        public TaskModel Get(int id)
        {
            return _taskServices.GetSingleCustomer(id);
        }
        [Route("Customers")]
        [HttpPost]
        public bool Post([FromBody] TaskModel ourCustomer)
        {
            //return true;
            return _taskServices.InsertCustomer(ourCustomer);
        }
        [Route("Customers")]
        [HttpPut]
        public bool Put([FromBody] TaskModel ourCustomer)
        {
            return _taskServices.UpdateCustomer(ourCustomer);
        }
        [Route("Customers/{id}")]
        [HttpDelete]
        public bool Delete(int id)
        {
            return _taskServices.DeleteCustomer(id);
        }
        [Route("Customers/{amount}/{sort}")]
        [HttpGet]
        public List<TaskModel> Get(int amount, string sort)
        {
            return _taskServices.GetCustomers(amount, sort);
        }
    }
}
