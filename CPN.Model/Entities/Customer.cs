using System;
using System.Collections.Generic;
using System.Text;

namespace CPN.Model.Entities
{
    public class Customer : AuditableEntity<int>
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
