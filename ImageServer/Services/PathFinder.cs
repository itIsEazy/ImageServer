namespace ImageServer.Services
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    using ImageServer.Services.Models;

    public class PathFinder : IPathFinder
    {
        public PathFinder()
        {

        }

        public bool PathExists { get; set; }

        public async Task<bool> PathExistsRecursive(string partsUnsplitted, Child child)
        {
            var watch = new Stopwatch();
            watch.Start();
            this.FindPath(child, this.SplitPartrs(partsUnsplitted), 0);

            watch.Stop();
            Console.WriteLine(watch.ElapsedMilliseconds);
            return this.PathExists;
        }

        private void FindPath(Child currChild, string[] parts, int index)
        {
            if (index <= parts.Length - 1)
            {
                for (int i = 0; i < currChild.Children.Count; i++)
                {
                    if (currChild.Children[i].Name == parts[index])
                    {
                        FindPath(currChild.Children[i], parts, index + 1);
                    }
                }
            }

            if (index == parts.Length)
            {
                this.PathExists = true;
            }

            return;
        }

        public async Task<bool> PathExistsWhileLoop(string partsUnsplitted, Child child)
        {
            var watch = new Stopwatch();
            watch.Start();

            var parts = this.SplitPartrs(partsUnsplitted);

            int lastIndex = 0;

            for (int i = 0; i < parts.Length; i++)
            {
                for (int j = 0; j < child.Children.Count; j++)
                {
                    if (parts[i] == child.Children[j].Name)
                    {
                        lastIndex++;
                        child = child.Children[j];
                        break;
                    }
                }
            }

            if (lastIndex == parts.Length && child.Children.Count == 0)
            {
                watch.Stop();
                Console.WriteLine(watch.ElapsedMilliseconds);
                return true;
            }
            else
            {
                watch.Stop();
                Console.WriteLine(watch.ElapsedMilliseconds);
                return false;
            }
        }

        private string[] SplitPartrs(string parts)
        {
            return parts.Split("-").ToArray();
        }
    }
}
