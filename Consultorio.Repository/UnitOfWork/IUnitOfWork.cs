﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consultorio.Repository.UnitOfWork
{
    public interface IUnitOfWork
    {
        Task CommitAsync();
        void RollBack();
    }
}