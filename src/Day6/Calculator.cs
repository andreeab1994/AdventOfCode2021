using System.Collections.Generic;
using System.Linq;

namespace Day6
{
    public sealed class Calculator
    {
        private Dictionary<int, long> _current = new();

        public Calculator(List<int> origin)
        {
            AppendToDictionary(origin);
        }

        private void AppendToDictionary(List<int> origin)
        {
            foreach (var fish in origin)
            {
                if (_current.ContainsKey(fish))
                {
                    _current[fish] += 1;
                }
                else
                {
                    _current[fish] = 1;
                }
            }
        }

        public long Calculate(int days)
        {
            for (var i = 1; i <= days; i++)
            {
                var keys = _current.Keys.ToList().OrderByDescending(e => e).ToList();
                var updated = new Dictionary<int, long>();

                foreach (var key in keys)
                {
                    if (key == 0)
                    {
                        updated[8] = _current[0];

                        if (updated.ContainsKey(6))
                        {
                            updated[6] += _current[0];
                        }
                        else
                        {
                            updated[6] = _current[0];
                        }
                    }
                    else
                    {
                        updated[key - 1] = _current[key];
                    }
                }

                _current = updated;
            }

            return _current.Sum(e => e.Value); 
        }
    }

}
