using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using TaskManagerAPI.Repository;

namespace TaskManagerAPI.Controllers
{    
    public class TaskController : ApiController
    {
        private TaskRepository TaskRep = new TaskRepository();
        // GET: api/Task
        [HttpGet]
        public IList<Task> GetTasks()
        {
            return TaskRep.GetAllTasks();
        }

        // GET: api/Task/5
        [HttpGet]
        public Task GetTaskDetails(int id)
        {
            return TaskRep.GetTaskDetail(id);
        }

        // POST: api/Task
        [HttpPost]
        public void SaveTask([FromBody]Task value)
        {
            TaskRep.SaveTask(value);
        }

        // PUT: api/Task/5
        [HttpPut]
        public void UpdateTask(int id, [FromBody]Task value)
        {
            TaskRep.UpdateTask(id, value);
        }

        // DELETE: api/Task/5
        [HttpDelete]
        public void DeleteTask(int id)
        {
            TaskRep.DeleteTask(id);

        }

        [HttpPut]        
        public void EndTask(int id)
        {
            TaskRep.EndTask(id);
           // return  StatusCode(HttpStatusCode.NoContent);
        }
    }
}
