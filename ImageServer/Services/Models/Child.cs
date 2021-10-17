namespace ImageServer.Services.Models
{
    using System.Collections.Generic;

    public class Child
    {
        public Child()
        {
            this.Children = new List<Child>();
        }
        public string Name { get; set; }

        public List<Child> Children { get; set; }
    }
}
