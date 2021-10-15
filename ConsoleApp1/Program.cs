using System;
using System.Collections.Generic;

namespace ConsoleApp1
{
    class Program
    {

        public static int GetRandom(int min, int max)
        {
            Random rnd = new Random();
            
            int rndInteger = rnd.Next(min, max + 1);

            return rndInteger;
        }

        public class FoodCount
        {
            public int Food { get; set; }
            public int Soda { get; set; }
        }
        public static FoodCount FoodAndSodaCount(int foodMin, int foodMax)
        {
            FoodCount result = new FoodCount()
            {
                Food = 0,
                Soda = 0
            };

            int soda = GetRandom(foodMin, foodMax);
            int food = GetRandom(foodMin, foodMax);

            if (food + soda > foodMax)
            {
                // if (food + soda < foodMax)
                // {
                //     int choice = GetRandom(0, 1);
                //
                //     if (choice == 0)
                //     {
                //         food += foodMax - soda;
                //     }
                //     else
                //     {
                //         soda += foodMax - food;
                //     }
                // }
                //
                for (; food + soda > foodMax;)
                {
                    int choice = GetRandom(0, 1);

                    if (choice == 0)
                    {
                        if (food > 1)
                        {
                            food -= 1;
                        }
                        else
                        {
                            soda -= 1;
                        }
                    }
                    else
                    {
                        if (soda > 1)
                        {
                            soda -= 1;
                        }
                        else
                        {
                            food -= 1;
                        }
                    }
                }
            }
            

            result.Food = food;
            result.Soda = soda;

            return result;
        }
        
        static void Main(string[] args)
        {


            // Console.Write("Длина поля: ");
            // string one = Console.ReadLine();
            // int length = Int32.Parse(2);
            int length = 10;
                
            // Console.Write("Высота поля: ");
            // string two = Console.ReadLine();
            // int height = Int32.Parse(2);
            int height = 10;
                
            List<int> line = new List<int> {};

            int field = 0;
            int outerWall = 1;
            int exit = 2;
            int wall = 3;
            int food = 4;
            int soda = 5;

            int foodMin = 1;
            int foodMax = 5;

            FoodCount foodAndSodaCount = FoodAndSodaCount(foodMin, foodMax);
            int foodCount = foodAndSodaCount.Food;
            int sodaCount = foodAndSodaCount.Soda;

            int wallMin = 5;
            int wallMax = 9;

            int[] counter = {0, 0, 0};

            int wallCount = GetRandom(wallMin, wallMax);

            string row = "";
            
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < length; j++)
                {
                    if (length > 2 && height > 2)
                    {
                        if ((j == 0 || j == length - 1) || (i == 0 || i == height - 1))
                        {
                            line.Add(outerWall);
                        }
                        else if(j == 8 && i == 1)
                        {
                            line.Add(exit);
                        }
                        else
                        {
                            int choise = GetRandom(0, 1);
                            // Console.WriteLine(choise);
                            
                            if (choise == 0)
                            {
                                line.Add(field);
                            }
                            else
                            {
                                if ((i >= 2 && i <= (height - 3)) && (j >= 2 && j <= (length - 3)))
                                {
                                    choise = GetRandom(0, 2);
                                    
                                    if (choise == 0)
                                    {
                                        if (counter[0] < wallMax)
                                        {
                                            line.Add(wall);
                                        }
                                        else
                                        {
                                            line.Add(field);
                                        }

                                        counter[0]++;
                                    }
                                    else if (choise == 1)
                                    {
                                        if (counter[1] < foodCount)
                                        {
                                            line.Add(food);
                                            
                                            counter[1]++;
                                        }
                                        else
                                        {
                                            line.Add(field);
                                        }
                                    }
                                    else
                                    {
                                        if (counter[2] < sodaCount)
                                        {
                                            line.Add(soda);
                                            
                                            counter[2]++;
                                        }
                                        else
                                        {
                                            line.Add(field);
                                        }
                                    }
                                }
                                else
                                {
                                    line.Add(field);
                                }
                            }
                        }
                    }
                    else
                    {
                        line.Add(outerWall);
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
            
            // Console.WriteLine(" ");
            // Console.WriteLine(foodCount + " - столько должно быть еды");
            // Console.WriteLine(sodaCount + " - столько должно быть воды");
            // Console.WriteLine(counter[1] + " - еды");
            // Console.WriteLine(counter[2] + " - воды");
        }
    }
}

/*
1111111111
1000000001
1000000001
1000000001
1000000001
1000000001
1000000001
1000000001
1000000001
1000000001
1111111111
 */