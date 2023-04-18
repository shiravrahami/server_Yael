﻿using SignIn;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplication1.DTO;
using Newtonsoft.Json.Linq;

namespace WebApplication1.Controllers
{
    public class TaskDeatailsController : ApiController
    {
        igroup195_DB_Prod db = new igroup195_DB_Prod();
        
        //פרטי משימה
        [HttpGet]
        [Route("api/TaskDeatails/{id}")]
        public IHttpActionResult GetTask(int id)
        {
            try
            {
                var task = db.Tasks
                    .Where(x => x.TaskID == id) 
                    .Select(x => new TasksDTO 
                    {
                        TaskID = x.TaskID,
                        TaskName = x.TaskName,
                        ProjectID = x.ProjectID,
                        TaskType = x.TaskType,
                        TaskDescription = x.TaskDescription,
                        InsertTaskDate = x.InsertTaskDate,
                        Deadline = (DateTime)(x.Deadline),
                        isDone = x.isDone,
                        isDeleted = x.isDeleted
                    })
                    .FirstOrDefault();

                return Ok(task);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //עדכון משימה 
        [HttpPut]
        [Route("api/TaskUpdate")]
        public IHttpActionResult UpdateTask([FromBody] TasksDTO updatedTask)
        {

            try
            {
                var task = db.Tasks.Find(updatedTask.TaskID);
                if (task == null)
                {
                    return NotFound();
                }

                task.TaskID = updatedTask.TaskID;
                task.TaskName = updatedTask.TaskName;
                task.ProjectID = updatedTask.ProjectID;
                task.TaskType = updatedTask.TaskType;
                task.TaskDescription = updatedTask.TaskDescription;
                task.InsertTaskDate = updatedTask.InsertTaskDate;
                task.Deadline = updatedTask.Deadline;
                task.isDone = updatedTask.isDone;
                task.isDeleted = updatedTask.isDeleted;

                db.SaveChanges();

                return Ok("good");
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        //סוגי משימה
        [HttpGet]
        [Route("api/TaskTypes")]
        public IHttpActionResult GetAllTaskTypes()
        {
            try
            {
                var taskTypes = db.TaskType
                    .Select(t => new TaskTypeDTO
                    {
                        TaskTypeID = t.TaskTypeID,
                        TaskKind = t.TaskKind
                    })
                    .ToList();

                return Ok(taskTypes);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //InsertTask
        [HttpPost]
        [Route("api/InsertTask")]
        public IHttpActionResult InsertTask([FromBody] TasksDTO task)
        {
            try
            {
                if (string.IsNullOrEmpty(task.TaskName?.ToString()) ||
                    string.IsNullOrEmpty(task.TaskDescription?.ToString()) ||
                    task.ProjectID == 0)
                {
                    return BadRequest("One or more parameters are missing");
                }

                Tasks Task = new Tasks()
                {
                    TaskName = task.TaskName,
                    ProjectID = task.ProjectID,
                    TaskType = task.TaskType,
                    TaskDescription = task.TaskDescription,
                    InsertTaskDate = task.InsertTaskDate,
                    Deadline = task.Deadline,
                };


                db.Tasks.Add(Task);
                db.SaveChanges();

                return Ok("Task details saved successfully");
            }
            catch (Exception ex)
            {
                return BadRequest($"Error saving Task details: {ex.Message}");
            }
        }

        //ListTasks/{employeeID}
        [HttpGet]
        [Route("api/ListTasks/{employeeID}")]
        public IHttpActionResult GetListTasks (int employeeID)
        {
            try
            {

                if (employeeID == 6)
                {

                    var MangerTasksList = db.Tasks.Where(x => !x.isDeleted).Select(x => new TasksDTO
                    {
                        TaskID = x.TaskID,
                        TaskName = x.TaskName,
                        ProjectID = x.ProjectID,
                        TaskType = x.TaskType,
                        TaskDescription = x.TaskDescription,
                        InsertTaskDate = x.InsertTaskDate,
                        Deadline = (DateTime)(x.Deadline),
                        isDone = x.isDone,
                        isDeleted = x.isDeleted

                    }).ToList();
                    return Ok(MangerTasksList);

                }
                else
                {

                    var tasks = (from t in db.Tasks
                                 join tea in db.Task_Employee_Activity on t.TaskID equals tea.TaskID
                                 where tea.EmployeePK == employeeID
                                 && !t.isDeleted
                                 select new
                                 {
                                     t.TaskID,
                                     t.TaskName,
                                     t.ProjectID,
                                     t.TaskType,
                                     t.TaskDescription,
                                     t.InsertTaskDate,
                                     t.Deadline,
                                     t.isDone,
                                     t.isDeleted
                                 }).ToList();


                    if (tasks == null || tasks.Count == 0)
                    {
                        return NotFound();
                    }

                    var TasksList = tasks.Select(x => new TasksDTO
                    {
                        TaskID = x.TaskID,
                        TaskName = x.TaskName,
                        ProjectID = x.ProjectID,
                        TaskType = x.TaskType,
                        TaskDescription = x.TaskDescription,
                        InsertTaskDate = x.InsertTaskDate,
                        Deadline = (DateTime)(x.Deadline),
                        isDone = x.isDone,
                        isDeleted = x.isDeleted

                    }).ToList();
                    return Ok(TasksList);
                }
            }
            catch (Exception)
            {
                return BadRequest("Error");
            }
        }

        //ListTasks/{id}
        [System.Web.Http.HttpPut]
        [System.Web.Http.Route("api/ListTasks/{id}")]
        public IHttpActionResult DeleteTask (int id)
        {
            var tasks = db.Tasks.FirstOrDefault(c => c.TaskID == id);
            if (tasks == null)
            {
                return NotFound();
            }
            tasks.isDeleted = true;
            db.SaveChanges();
            return Ok("The task has been deleted!");
        }

      
    }
}




