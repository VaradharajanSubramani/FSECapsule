using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TaskManagerAPI.Repository
{
    public class TaskRepository
    {
        private TaskManagerEntities TME = new TaskManagerEntities();

         public List<Task> GetAllTasks()
        {
            List<Task> tasklist = TME.Tasks.ToList();

            return tasklist;
        }

        public int SaveTask( Task taskdetails)
        {
            try
            {
                if (taskdetails != null)
                {
                    TME.Tasks.Add(taskdetails);
                    return TME.SaveChanges();
                }               
            }
            catch (Exception e)
            {
                throw e;               
            }

            return 0;
        }

        public int UpdateTask(int taskid, Task taskdetails)
        {
            try
            {
                if (taskdetails != null)
                {
                    if (taskdetails.Task_ID != 0)
                    {
                        Task t = TME.Tasks.Where(x => x.Task_ID == taskid).FirstOrDefault();
                        TME.Tasks.Add(t);
                        TME.Entry(t).State = System.Data.Entity.EntityState.Modified;
                        return TME.SaveChanges();

                    }
                    return TME.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return 0;
        }

        public void DeleteTask(int taskid)
        {
            try
            {
                if(taskid!=0)
                {
                    Task t = TME.Tasks.Where(x => x.Task_ID == taskid).FirstOrDefault();
                    TME.Tasks.Remove(t);
                    TME.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw e;
            }           
        }

        public int EndTask(int taskid)
        {
            try
            {
                if(taskid != 0)
                {
                    Task t = TME.Tasks.Where(x => x.Task_ID == taskid).FirstOrDefault();
                    t.IsCompleted = true;
                    return TME.SaveChanges();
                }
            }
            catch (Exception)
            {

                throw;
            }
            return 0;
        }

        public Task GetTaskDetail(int taskid)
        {
            try
            {
                if (taskid != 0)
                {
                    Task t = TME.Tasks.Where(x => x.Task_ID == taskid).FirstOrDefault();
                    return t;
                }
            }
            catch (Exception)
            {

                throw;
            }
            return null;
        }
    }
}