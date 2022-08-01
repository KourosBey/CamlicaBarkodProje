﻿using DataAccesLayer.Abstract;
using DataAccesLayer.Concrete;
using DataAccesLayer.Repositories;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccesLayer.EntityFramework
{
    public class EFWorkerRepository: GenericRepository<Worker>, IWorkerDal
    {
        public List<Worker> IncludeAll()
        {
            using var c = new Context();
            return c.Set<Worker>().Include(c=>c.Authority).ToList();
        }
    }
}
