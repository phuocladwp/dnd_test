using System;
using System.Collections.Generic;

namespace DND_Demo.Models
{
    public partial class Dndmembers
    {
        public int Id { get; set; }
        public string NetworkId { get; set; }
        public string RealName { get; set; }
        public string Dndname { get; set; }
        public string EmailAddress { get; set; }
        public int? DndclassId { get; set; }
        public string FavoriteTvseries { get; set; }
        public bool? IsDeleted { get; set; }
        public int UpdatedBy { get; set; }
        public DateTime CreatedTimestamp { get; set; }
        public DateTime LastUpdateTimestamp { get; set; }

        public virtual Dndclasses Dndclass { get; set; }
    }
}
