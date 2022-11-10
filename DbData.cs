using BooksWebAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BooksWebAPI
{
    public class DbData:DbContext
    {
        public DbData(DbContextOptions<DbData> _dbCon):base(_dbCon)
        {

        }
        public DbSet<Books> Books { get; set; }

    }
}
