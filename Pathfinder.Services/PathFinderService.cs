using Pathfinder.Interfaces;
using Pathfinder.Services.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Pathfinder.Services
{
    public class PathFinderService : IPathFinderService
    {
        public int[] FindPath(int[] input)
        {
            if (input == null || input.Length == 0)
            {
                throw new ArgumentNullException();
            }

            var tree = new Tree
            {
                FinalNodes = new List<Node>()
            };

            var rootNode = new Node(0, input, null, tree);

            if (!tree.FinalNodes.Any())
            {
                return null;
            }

            var winner = tree.FinalNodes
                .Select(s => GetPath(s).ToArray())
                .OrderBy(o => o.Length)
                .First()
                .Reverse()
                .ToArray();

            return winner;
        }

        private IEnumerable<int> GetPath(Node node)
        {
            yield return node.Value;

            if (node.Parent == null)
            {
                yield break;
            }

            foreach (var x in GetPath(node.Parent))
            {
                yield return x;
            }
        }
    }
}
