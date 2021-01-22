using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace AsynchonniProgramovani
{
    public delegate bool Condition(string input);
    class ThreadPool
    {
        
        public Condition[] CondArr;
        Condition condition;

        public ThreadPool()
        {
            CondArr = new Condition[]
            {
                ContainsNumbersFiveTwoOne, ContainsTwoSameNumbers
            };
        }

        public bool IsPrime(int input)
        {
            int a = 0;
            for (int i = 1; i <= input; i++)
            {
                if (input % i == 0)
                {
                    a++;
                }
            }
            if (a == 2)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool ContainsTwoSameNumbers(string input)
        {
            char firstNumber = ' ';
            for (int i = 0; i < input.Length; i++)
            {
                if (input.Length < 2) return false;
                else
                {
                    if(i == 0)
                    {
                        firstNumber = input[i];
                    }
                    else
                    {
                        if (input[i] != firstNumber) return false;
                        else
                        {
                            if ((input.Length - 1) == i) return true;
                        }
                    }
                }
            }
            return false;
        }

        public bool ContainsNumbersFiveTwoOne(string input)
        {
            bool five = false;
            bool two = false;
            bool one = false;
            foreach (char item in input)
            {
                if (item == '5') five = true;
                else if (item == '2') two = true;
                else if (item == '1') one = true;
            }
            if (five == true && two == true && one == true) return true;
            else return false;
        }

        public async Task<string> SearchAsync(int c)
        {
            condition = CondArr[c];
            int result = 0;
            await Task.Run(() =>
            {
                for (int i = 0; i <= int.MaxValue; i++)
                {
                    try
                    {
                        if (IsPrime(i) && condition(i.ToString()))
                        {
                            result = i;
                            break;
                        }
                    }
                    catch (Exception err)
                    {
                        MessageBox.Show(err.Message);
                        return;
                    }
                }
            });

            return result.ToString();

        }



    }
}
