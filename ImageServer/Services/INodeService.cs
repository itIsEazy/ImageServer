namespace ImageServer.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using ImageServer.Services.Models;

    public interface INodeService
    {
        public Child GetRootNode();
    }
}
