using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecommenderSystem.Algorithms
{
    public static class AlgoritmExecutor
    {
        public static void ExecuteAlgorithms(List<IAlgorithm> algorithms)
        {
            foreach (IAlgorithm algorithm in algorithms)
            {
                algorithm.ExecuteAlgorithm();
            }
        }
    }
}
