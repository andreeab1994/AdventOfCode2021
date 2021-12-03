using System;
using System.Collections.Generic;
using System.Linq;

namespace Day3
{
    public class LifeSupportRating
    {
        private readonly IEnumerable<string> _logs;

        private int? _oxygen;
        public int OxygenGeneratorRating =>_oxygen ?? GetOxygenGeneratorRating();

        private int? _co2Scrubber;
        public int Co2ScrubberRating => _co2Scrubber ?? GetCo2ScrubberRating();

        public int Rating => OxygenGeneratorRating * Co2ScrubberRating;

        public LifeSupportRating(IEnumerable<string> logs)
        {
            _logs = logs;
        }

        public void Process()
        {
            GetOxygenGeneratorRating();
            GetCo2ScrubberRating();
        }

        private int GetOxygenGeneratorRating()
        {
            var list = _logs.ToList();
            var finishedProcessing = false;
            var count = 0;
            while (!finishedProcessing)
            {
                if (list.Count > 1)
                {
                    list = ReturnOxygenCollection(list, count);
                    count++;
                }
                else
                {
                    finishedProcessing = true;

                }

            }
            var oxygen = Convert.ToInt32(list.First(), 2);
            _oxygen = oxygen;
            return oxygen;
        }

        private List<string> ReturnOxygenCollection(List<string> list, int count)
        {
            var binaryDiagnostic = new BinaryDiagnostic(list);
            binaryDiagnostic.Process();

            var incidence = binaryDiagnostic.ReturnIncidenceForGivenIndex(count);

            var newList = new List<string>();

            foreach (var item in list)
            {
                var substring = item.Substring(count, 1);
                if (substring.Equals(incidence.ToString()))
                {
                    newList.Add(item);
                }
            }

            return newList;

        }

        private int GetCo2ScrubberRating()
        {
            var list = _logs.ToList();
            var finishedProcessing = false;
            var count = 0;
            while (!finishedProcessing)
            {
                if (list.Count > 1)
                {
                    list = ReturnCo2Collection(list, count);
                    count++;
                }
                else
                {
                    finishedProcessing = true;

                }

            }
            var co2 = Convert.ToInt32(list.First(), 2);
            _co2Scrubber = co2;
            return co2;
        }

        private List<string> ReturnCo2Collection(List<string> list, int count)
        {
            var binaryDiagnostic = new BinaryDiagnostic(list);
            binaryDiagnostic.Process();

            var incidence = binaryDiagnostic.ReturnIncidenceForGivenIndex(count);

            var newList = new List<string>();

            foreach (var item in list)
            {
                var substring = item.Substring(count, 1);
                if (!substring.Equals(incidence.ToString()))
                {
                    newList.Add(item);
                }
            }

            return newList;

        }
    }
}
