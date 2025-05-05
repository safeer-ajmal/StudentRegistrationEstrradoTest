﻿using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

public class AppDbContext : DbContext
{
    public DbSet<Student> Students { get; set; }
    public DbSet<Qualification> Qualifications { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
}
