﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BangazonTaskTracker.Models;

namespace BangazonTaskTracker.DAL
{
    public class BangazonContext : DbContext
    {
        public BangazonContext(DbContextOptions<BangazonContext> options) : base(options)
        {
        }

        public DbSet<UserTask> UserTasks { get; set; }
    }
}
