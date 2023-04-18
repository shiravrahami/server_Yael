using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.DTO
{
    public class CustomerTasksDTO
    {
        public CustomerDetailsDTO CustomerDetails { get; set; }
        public List<TasksDTO> OpenTasks { get; set; }
        public int TotalTasks { get; set; }
    }

}