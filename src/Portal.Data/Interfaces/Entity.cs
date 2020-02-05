using System;
using System.Collections.Generic;
using System.Text;

namespace Portal.Data.Interfaces
{
    public abstract class Entity : IEntity
    {
        public int Id { get; set; }
        public DateTime CreationTime { get; set; }
    }
}
