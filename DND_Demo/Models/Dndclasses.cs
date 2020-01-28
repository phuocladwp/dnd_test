using System;
using System.Collections.Generic;

namespace DND_Demo.Models
{
    public partial class Dndclasses
    {
        public Dndclasses()
        {
            Dndmembers = new HashSet<Dndmembers>();
        }

        public int Id { get; set; }
        public string DndclassName { get; set; }
        public string DndclassDescription { get; set; }

        public virtual ICollection<Dndmembers> Dndmembers { get; set; }
    }
}
