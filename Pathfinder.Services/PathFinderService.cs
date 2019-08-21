using Microsoft.Extensions.Caching.Memory;
using Pathfinder.Interfaces;
using Pathfinder.Services.Helpers;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Pathfinder.Services
{
    public class PathFinderService : IPathFinderService
    {
        private readonly IMemoryCache cache;

        public PathFinderService(IMemoryCache cache)
        {
            this.cache = cache;
        }

        public int[] FindPath(int[] input)
        {
            if (input == null || input.Length == 0)
            {
                throw new ArgumentNullException();
            }

            var cacheKey = CalcHash(input);

            if (cache.TryGetValue(cacheKey, out int[] value))
            {
                return value;
            }

            var tree = new Tree
            {
                FinalNodes = new List<Node>()
            };

            var rootNode = new Node(0, input, null, tree);

            int[] result;
            if (tree.FinalNodes.Any())
            {
                result = tree.FinalNodes
                .Select(s => GetPath(s).ToArray())
                .OrderBy(o => o.Length)
                .First()
                .Reverse()
                .ToArray();
            }
            else
            {
                result = new int[0];
            }

            cache.Set(cacheKey, result);

            return result;
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

        private int CalcHash(int[] data)
        {
            int hc = data.Length;
            for (int i = 0; i < data.Length; ++i)
            {
                hc = unchecked(hc * 31 + data[i]);
            }
            return hc;
        }
    }
}
