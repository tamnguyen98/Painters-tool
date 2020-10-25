using DataLibrary.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataLibrary.CustomMethods
{
    public class ReturnData
    {
        public static ClientModel TrimClientModelStringValues(ClientModel c)
        {
            // Remove trailing (and leading) spaces from the element
            c.FirstName = c.FirstName.Trim();
            c.LastName = c.LastName.Trim();
            c.PhoneNumber = c.PhoneNumber.Trim();
            c.HouseNum = c.HouseNum.Trim();
            c.Street = c.Street.Trim();
            c.Status = c.Status.Trim();

            // Nullable string values
            if (c.Email != null)
                c.Email = c.Email.Trim();
            if (c.State != null)
                c.State = c.State.Trim();
            if (c.City != null)
                c.City = c.City.Trim();
            return c;
        }

        public static TaskModel TrimTaskModelStringValues(TaskModel t)
        {
            if (t.Task != null)
                t.Task = TrimStringValue(t.Task);
            if (t.Description != null)
                t.Description = TrimStringValue(t.Description);
            return t;
        }

        public static List<TaskModel> TrimTaskListStringValues(List<TaskModel> t)
        {
            t.ForEach(x =>
            {
                x.Task = TrimStringValue(x.Task);
                x.Description = TrimStringValue(x.Description);
            });
            return t;
        }

        public static string TrimStringValue(string s)
        {
            if (s == null)
                return s;
            return s.Trim();
        }
    }
}
