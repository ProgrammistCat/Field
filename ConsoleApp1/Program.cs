using System;
using System.Collections.Generic;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
        
            Console.Write("Длина поля: ");
            string one = Console.ReadLine();
            int length = Int32.Parse(one);
                
            Console.Write("Высота поля: ");
            string two = Console.ReadLine();
            int height = Int32.Parse(two);
                
            List<int> line = new List<int> {};
                
            string row = "";

            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < length; j++)
                {
                    if (length > 2 & height > 2)
                    {
                        if ((j == 0 | j == length - 1) | (i == 0 | i == height - 1))
                        {
                            line.Add(1);
                        }
                        else
                        {
                            line.Add(0);
                        }
                    }
                    else
                    {
                        line.Add(1);
                    }
                }
                
                for (int j = 0; j < line.Count; j++)
                {
                    row += line[j] + "  ";
                }
                
                Console.WriteLine(row);
                
                row = "";
                line.Clear();
            }
        }
    }
}