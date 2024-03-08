using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using AutoRecon.Domain.Common;

namespace AutoRecon.Domain.Entities
{
    public class Scan : BaseAuditableEntity
    {
        public long Duration { get; set; }
        public int Priority { get; set; }
    }
}
