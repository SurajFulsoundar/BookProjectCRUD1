﻿using BookProjectCRUD1.Models;
using Microsoft.EntityFrameworkCore;

namespace BookProjectCRUD1.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        public DbSet<Book> Books { get; set; }
       
    }
}
