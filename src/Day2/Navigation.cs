using System;
using System.Collections.Generic;
using System.Text;

namespace Day2
{
    public sealed class Navigation
    {
        private int _aim;
        private int _depth;
        private int _horizontalPosition;

        public (int horizontalPosition, int depth, int aim) Values => (_horizontalPosition, _depth, _aim);

        private bool _useAim;

        public int Result => _horizontalPosition * _depth;

        private Navigation()
        {
            _aim = 0;
            _depth = 0;
            _horizontalPosition = 0;
        }

        public static Navigation Create() => new Navigation();

        public static Navigation CreateWithAim() => new Navigation().WithAim();

        private Navigation WithAim()
        {
            _useAim = true;
            return this;
        }

        public void Forward(int value)
        {
            IncreaseHorizontalPosition(value);

            if (_useAim)
            {
                IncreaseDepth(_aim * value);
            }
        }

        public void Down(int value)
        {
            if (_useAim)
            {
                IncreaseAim(value);
            }
            else
            {
                IncreaseDepth(value);
            }
        }

        public void Up(int value)
        {
            if (_useAim)
            {
                DecreaseAim(value);
            }
            else
            {
                DecreaseDepth(value);
            }
        }

        private void IncreaseAim(int value) => _aim += value;
        private void DecreaseAim(int value) => _aim -= value;
        private void DecreaseDepth(int value) => _depth -= value;
        private void IncreaseDepth(int value) => _depth += value;
        private void IncreaseHorizontalPosition(int value) => _horizontalPosition += value;
    }
}
