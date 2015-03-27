using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hsking.Mobile.Api.Models
{
    public class Habit
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Solution { get; set; }
        public string Feature { get; set; }
        public string ImageUrl { get; set; }
        public string PushText { get; set; }
        public int NumberOfReminder { get; set; }

        public Category Category { get; set; }

        public HabitType HabitType { get; set; }

        public List<DefaultShedule> DefaultShedules { get; set; } 
    }
}
