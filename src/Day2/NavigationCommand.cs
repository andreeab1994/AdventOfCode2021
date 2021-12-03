using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Day2
{
    public sealed class NavigationCommand
    {
        public NavigationCommandType CommandType { get; }

        public int Value { get; set; }

        public NavigationCommand(NavigationCommandType commandType, int value)
        {
            CommandType = commandType;
            Value = value;
        }

        public static NavigationCommandType GetCommandType(string command)
        {
            return command.ToLower() switch
            {
                "forward" => NavigationCommandType.Forward,
                "up" => NavigationCommandType.Up,
                "down" => NavigationCommandType.Down,
                _ => throw new InvalidOperationException()
            };
        }

        public void Execute(Navigation navigation)
        {
            switch (CommandType)
            {
                case NavigationCommandType.Forward:
                    navigation.Forward(Value);
                    break;
                case NavigationCommandType.Down:
                    navigation.Down(Value);
                    break;
                case NavigationCommandType.Up:
                    navigation.Up(Value);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            //return navigation;
        }


    }
}
