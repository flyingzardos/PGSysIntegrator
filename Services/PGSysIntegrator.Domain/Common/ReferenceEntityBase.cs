﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PGSysIntegrator.Domain.Common
{
    /// <summary>
    /// Provides common fields for entities within Ordering Microservice.
    /// NOTE it is an abstract class and therefore not instantiated.
    /// </summary>
    public abstract class ReferenceEntityBase
    {
        [Key]
        public int Id { get; protected set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? LastModifiedDate { get; set; }
      
    }
}
