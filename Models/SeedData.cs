using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using TODOWebApplication.Data;
using TODOHelperLibrary;

namespace TODOWebApplication.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new TODOWebApplicationContext(
                serviceProvider.GetRequiredService<DbContextOptions<TODOWebApplicationContext>>()
                ))
            {
                if (context.Tasks.Any())
                {
                    return;
                }

                context.Tasks.AddRange(
                    new TodoItem
                    {
                        Title = "Wash",
                        Description = "Wash your clothes",
                        AddedDate = DateTime.Now,
                        ExpirationDate = DateTime.Now.AddDays(7),
                        Status = (ItemStatus)0
                    },

                    new TodoItem
                    {
                        Title = "Clean",
                        Description = "Clean your room",
                        AddedDate = DateTime.Now,
                        ExpirationDate = DateTime.Now.AddDays(14),
                        Status = (ItemStatus)1
                    },

                    new TodoItem
                    {
                        Title = "Take",
                        Description = "Take the Hobbits to Isengard",
                        AddedDate = DateTime.Now,
                        ExpirationDate = DateTime.Now.AddDays(100),
                        Status = (ItemStatus)2
                    },

                    new TodoItem
                    {
                        Title = "Watch",
                        Description = "Watch a movie",
                        AddedDate = DateTime.Now,
                        ExpirationDate = DateTime.Now.AddDays(5),
                        Status = (ItemStatus)0
                    },

                    new TodoItem
                    {
                        Title = "Learn",
                        Description = "Learn to play the guitar",
                        AddedDate = DateTime.Now,
                        ExpirationDate = DateTime.Now.AddDays(365),
                        Status = (ItemStatus)0
                    },

                    new TodoItem
                    {
                        Title = "Date",
                        Description = "Take Frankie on a date",
                        AddedDate = DateTime.Now,
                        ExpirationDate = DateTime.Now.AddDays(2),
                        Status = (ItemStatus)0
                    },

                    new TodoItem
                    {
                        Title = "Offer",
                        Description = "Make him an offer he can't refuse",
                        AddedDate = DateTime.Now,
                        ExpirationDate = DateTime.Now.AddDays(3),
                        Status = (ItemStatus)0
                    },

                    new TodoItem
                    {
                        Title = "Keep",
                        Description = "Keep your friends close, but your enemier closer",
                        AddedDate = DateTime.Now,
                        ExpirationDate = DateTime.Now.AddDays(1000),
                        Status = (ItemStatus)0
                    },

                    new TodoItem
                    {
                        Title = "Be Back",
                        Description = "Hasta la Vista",
                        AddedDate = DateTime.Now,
                        ExpirationDate = DateTime.Now.AddDays(1),
                        Status = (ItemStatus)0
                    },

                    new TodoItem
                    {
                        Title = "Don't Stop",
                        Description = "Believing, hold on to that feeling",
                        AddedDate = DateTime.Now,
                        ExpirationDate = DateTime.Now.AddDays(100),
                        Status = (ItemStatus)0
                    },

                    new TodoItem
                    {
                        Title = "Feel Lucky",
                        Description = "Punk",
                        AddedDate = DateTime.Now,
                        ExpirationDate = DateTime.Now.AddDays(26),
                        Status = (ItemStatus)0
                    },

                    new TodoItem
                    {
                        Title = "Mall",
                        Description = "Go to the mall",
                        AddedDate = DateTime.Now,
                        ExpirationDate = DateTime.Now.AddDays(12),
                        Status = (ItemStatus)0
                    },

                    new TodoItem
                    {
                        Title = "Frankly",
                        Description = "Don't give a damn",
                        AddedDate = DateTime.Now,
                        ExpirationDate = DateTime.Now.AddDays(456),
                        Status = (ItemStatus)0
                    },

                    new TodoItem
                    {
                        Title = "ET",
                        Description = "Phone home",
                        AddedDate = DateTime.Now,
                        ExpirationDate = DateTime.Now.AddDays(1),
                        Status = (ItemStatus)0
                    },

                    new TodoItem
                    {
                        Title = "Bond",
                        Description = "James Bond",
                        AddedDate = DateTime.Now,
                        ExpirationDate = DateTime.Now.AddDays(100),
                        Status = (ItemStatus)1
                    }
                    );

                context.SaveChanges();
            }
        }
    }
}
