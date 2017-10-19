using EfCore2Issue.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace EfCore2Issue
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            using (var context = new ApplicationDbContext())
            {
                // First time round add some data
                if (context.Holders.Count() == 0)
                {
                    context.Holders.Add(new Model.DateHolder
                    {
                        Layer = new Model.Layer
                        {
                            Schedule = new Model.SpecificSchedule
                        {
                            From = TimeSpan.FromHours(16),
                                Dates = new System.Collections.Generic.List<Model.SpecificDate>
                        {
                            new Model.SpecificDate { Date = DateTimeOffset.Now },
                            new Model.SpecificDate { Date = DateTimeOffset.Now.AddDays(1) },
                            new Model.SpecificDate { Date = DateTimeOffset.Now.AddDays(2) },
                        }
                            }
                        }
                    });

                    context.Holders.Add(new Model.DateHolder
                    {
                        Layer = new Model.Layer
                        {
                            WeeklySchedule = new Model.WeeklySchedule
                            {
                                Days = "All the days!",
                                From = TimeSpan.FromHours(12)
                            }
                        }
                    });

                    context.SaveChanges();
                }
                else
                {
                    // Second time round - retrieve the data

                    /////////////////// Doesn't work (throws Exception) - Start
                    var task = context.Holders
                        .Where(x => x.Id > 0)
                        .Include(x => x.Layer).ThenInclude(y => y.Schedule).ThenInclude(z => z.Dates)
                        .Include(x => x.Layer).ThenInclude(y => y.WeeklySchedule)
                        .FirstOrDefaultAsync();
                    task.Wait();
                    // Never gets this far
                    var result = task.Result;
                    /////////////////// Doesn't work (throws Exception) - End

                    /////////////////// Works - Start
                    //var gotten = context.Holders
                    //    .Where(x => x.Id > 0)
                    //    .Include(x => x.Layer).ThenInclude(y => y.Schedule).ThenInclude(z => z.Dates)
                    //    .Include(x => x.Layer).ThenInclude(y => y.WeeklySchedule)
                    //    .FirstOrDefault();
                    /////////////////// Works - End
                }
            }

            Console.ReadLine();
        }
    }
}
