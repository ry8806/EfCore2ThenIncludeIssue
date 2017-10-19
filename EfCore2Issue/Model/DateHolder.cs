using System;
using System.Collections.Generic;
using System.Text;

namespace EfCore2Issue.Model
{
    public class DateHolder
    {
        public int Id { get; set; }

        public Layer Layer { get; set; }
    }

    public class WeeklySchedule
    {
        public int Id { get; set; }
        public string Days { get; set; }
        public TimeSpan From { get; set; }
    }

    public class SpecificSchedule
    {
        public int Id { get; set; }
        public TimeSpan From { get; set; }
        public List<SpecificDate> Dates { get; set; }
    }

    public class Layer
    {
        public SpecificSchedule Schedule { get; set; }
        public WeeklySchedule WeeklySchedule { get; set; }
        public int Id { get; set; }
        
    }

    public class SpecificDate
    {
        public int SpecificScheduleId { get; set; }
        public DateTimeOffset Date { get; set; }
    }         
}