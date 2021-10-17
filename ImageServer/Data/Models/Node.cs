namespace ImageServer.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class Node
    {
        public Node()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        public string Id { get; set; }

        public string ParentId { get; set; }

        public virtual  Node Parent { get; set; }

        public string Name { get; set; }

        public virtual IEnumerable<Node> Children { get; set; }
    }
}
