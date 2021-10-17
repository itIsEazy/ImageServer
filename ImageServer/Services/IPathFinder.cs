namespace ImageServer.Services
{
    using System.Threading.Tasks;

    using ImageServer.Services.Models;

    public interface IPathFinder
    {
        Task<bool> PathExistsRecursive(string partsUnsplitted, Child child);

        Task<bool> PathExistsWhileLoop(string partsUnsplitted, Child child);
    }
}
