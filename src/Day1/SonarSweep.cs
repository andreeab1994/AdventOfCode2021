using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day1
{
    public class SonarSweep
    {
        public int DepthIncreases { get; private set; }

        private SonarSweep()
        {
            DepthIncreases = 0;

        }

        public static SonarSweep Create() => new();

        public void CompareDepths(int currentValue, int previousValue)
        {
            if (currentValue > previousValue)
            {
                DepthIncreases++;
            }
        }

    }
}
