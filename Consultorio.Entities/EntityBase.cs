﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consultorio.Entities
{
    public class EntityBase
    {
        public Guid Id { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public bool Active { get; set; }


        public EntityBase()
        {
            Active = true;
            CreationDate= DateTime.UtcNow;

        }

    }
}
