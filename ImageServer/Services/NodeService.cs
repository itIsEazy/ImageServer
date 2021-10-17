namespace ImageServer.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using ImageServer.Services.Models;

    public class NodeService : INodeService
    {
        public NodeService()
        {
            this.Nodes = new List<Child>();

            // get the nodes from DB
            // set root node child

            this.GetAvailableNodes();
            this.SetRootNode();
        }

        public Child Root { get; set; }

        public List<Child> Nodes { get; set; }

        private void GetAvailableNodes()
        {
            // QUERY DB AND DO THE ALGO FOR CHAINGN ALL THE KIDS

            var rootChild = new Child()
            {
                Name = "root",
            };

            // Construct (add) ( CRUD -> create ) add new image file and add it in informational tree
            var hotWheelsChild = new Child()
            {
                Name = "hotwheels"
            };
            rootChild.Children.Add(hotWheelsChild);

            var premiumChild = new Child()
            {
                Name = "premium",
            };
            hotWheelsChild.Children.Add(premiumChild);

            var id24Child = new Child()
            {
                Name = "24",
            };
            premiumChild.Children.Add(id24Child);

            this.Nodes.Add(rootChild);
        }

        public Child GetRootNode()
        {
            return Root;
        }

        private void SetRootNode()
        {
            foreach (var node in Nodes)
            {
                if (node.Name == "root")
                {
                    Root = node;
                    break;
                }
            }
        }
    }
}
