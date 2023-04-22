using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B
{
    struct Schedule
    {
        public DateTime From;
        public DateTime To;
    }

    class Program
    {
        static void Main(string[] args)
        {
            StreamReader reader = File.OpenText("input.txt");
            var lines = reader.ReadToEnd().Split("\r\n");
            var countNumbers = 0;
            var countMeetings = 0;
            var mySchedule = new Schedule();
            List<Schedule> teamSchedules = new List<Schedule>();
            for (var i = 0; i < lines.Length; i++)
            {
                switch (i)
                {
                    case 0:
                        var data = lines[i].Split(" ").Select(t => Convert.ToInt32(t)).ToArray();
                        countNumbers = data[0];
                        countMeetings = data[1];
                        break;
                    case 1:
                        var range = lines[i].Split("-");
                        mySchedule.From = DateTime.ParseExact(range[0], "HH:mm", null);
                        mySchedule.To = DateTime.ParseExact(range[1], "HH:mm", null);
                        break;
                    default:
                        var range2 = lines[i].Split(" ");
                        var dateRange = range2[1].Split("-");
                        var schedule = new Schedule()
                        {
                            From = DateTime.ParseExact(dateRange[0], "HH:mm", null),
                            To = DateTime.ParseExact(dateRange[1], "HH:mm", null)
                        };
                        teamSchedules.Add(schedule);
                        break;
                }

                teamSchedules = teamSchedules.OrderBy(t => t.To).ToList();
                foreach (var schedule in teamSchedules)
                {
                    if (schedule.To >= mySchedule.To && schedule.To <= schedule.From)
                    {
                        Console.WriteLine("ALARM");
                        continue;
                    }

                    var meetTime = new Schedule()
                    {
                        From = mySchedule.From.Add(schedule.To.TimeOfDay.Subtract(mySchedule.From.TimeOfDay)),
                        To = mySchedule.To
                    };
                    Console.WriteLine(meetTime.From.TimeOfDay);
                }
            }
        }
    }
}
