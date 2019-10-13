using EscapeMines.Common.Interfaces.Operations;
using EscapeMines.Common.MinesGameModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace EscapeMines.Common.Operations
{
    public class Print : IPrint
    {
        public Print()
        {

        }
        public void PrintResult(State currentState)
        {
            try
            {
                switch (currentState)
                {
                    case State.IsDead:
                        Console.WriteLine("Result: Mine Hit");
                        break;
                    case State.Normal:
                        Console.WriteLine("Result: Still In Danger");
                        break;
                    case State.IsOutOfBounds:
                        Console.WriteLine("Result: Out Of Boundaries");
                        break;
                    case State.IsExit:
                        Console.WriteLine("Result: Success");
                        break;
                    case State.IsDanger:
                        Console.WriteLine("Result: Still In Danger");
                        break;
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error was found while writing the results \n {ex.Message}");
                throw new Exception(ex.Message);
            }
            
        }
    }
}
