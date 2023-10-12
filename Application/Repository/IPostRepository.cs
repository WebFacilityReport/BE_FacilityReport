﻿using Application.IGenericRepository;
using Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Repository
{
    public interface IPostRepository : IGenericRepository<Post>
    {
    }
}
