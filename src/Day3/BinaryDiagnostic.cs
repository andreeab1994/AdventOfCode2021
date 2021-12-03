using System;
using System.Collections.Generic;
using System.Linq;
using static System.Int32;

namespace Day3
{
    public class BinaryDiagnostic
    {
        private readonly IEnumerable<string> _logs;
        public Dictionary<int, Incidence> IncidenceLog = new();
        private int? _gammaRate;

        public int GammaRate => _gammaRate ?? Convert.ToInt32(ReturnGammaRate(), 2);
        private int? _epsilonRate;

        public BinaryDiagnostic(IEnumerable<string> logs)
        {
            _logs = logs;
        }

        public int EpsilonRate => _epsilonRate ?? Convert.ToInt32(ReturnEpsilonRate(), 2);

        public void Process()
        {
            foreach (var t in _logs)
            {
                ProcessNumber(t);
            }

            _gammaRate = Convert.ToInt32(ReturnGammaRate(), 2);
            _epsilonRate = Convert.ToInt32(ReturnEpsilonRate(), 2);
        }

        private void ProcessNumber(string number)
        {
            var intList = number.Select(digit => Parse(digit.ToString())).ToList();

            for (var i = 0; i < intList.Count(); i++)
            {
                var incidence = new Incidence();

                if (IncidenceLog.TryGetValue(i, out var value))
                {
                    incidence = value;

                    IncreaseIncidence(intList[i], incidence);
                    IncidenceLog[i] = incidence;
                }
                else
                {
                    IncreaseIncidence(intList[i], incidence);
                    IncidenceLog.Add(i, incidence);
                }

            }

        }

        private static void IncreaseIncidence(int value, Incidence incidence)
        {
            switch (value)
            {
                case 0:
                    incidence.Zero++;
                    break;
                case 1:
                    incidence.One++;
                    break;
            }
        }

        private string ReturnGammaRate()
        {
            var rate = string.Empty;
            foreach (var item in IncidenceLog)
            {
                rate += item.Value.ReturnGreatest();
            }

            return rate;
        }

        private string ReturnEpsilonRate()
        {
            var rate = string.Empty;
            foreach (var item in IncidenceLog)
            {
                rate += item.Value.ReturnSmallest();
            }

            return rate;
        }

        public decimal GetPowerConsumption()
        {
            return GammaRate * EpsilonRate;
        }

        public int ReturnIncidenceForGivenIndex(int index)
        {
            if (IncidenceLog.TryGetValue(index, out var value))
            {
                var biggest =  value.ReturnGreatest();

                return Parse(biggest);
            }

            throw new InvalidOperationException("Can't get the log");
        }
    }
}
