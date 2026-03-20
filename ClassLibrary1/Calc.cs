using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace CalcLib
{
    public class Calc
    {
        //
        public static string RPN(string str)
        {
            string MainStr = str.Replace(" ", "");

            string[] rpn = SortStancia(MainStr, out int Count);

            double[] stek = new double[Count];
            int calcIdx = 0;
            
            for (int i = 0; i < Count; i++)
            {
                string token = rpn[i];

                if (double.TryParse(token, NumberStyles.Any, CultureInfo.InvariantCulture, out double num))
                {
                    stek[calcIdx++] = num;
                }

                else
                {
                    double secod = stek[--calcIdx];
                    double first = stek[--calcIdx];

                    switch (token)
                    {
                        case "+": { stek[calcIdx++] = first + secod; break; }
                        case "-": { stek[calcIdx++] = first - secod; break; }
                        case "*": { stek[calcIdx++] = first * secod; break; }
                        case "/":
                            {
                                if (secod == 0)
                                {
                                    string res = "На ноль делить незя!";
                                    return res;
                                }
                                stek[calcIdx++] = first / secod;
                                break;
                            }
                        case "^": { stek[calcIdx++] = Math.Pow(first, secod); break; }
                    }
                }
            }

            double result = stek[0];
            return result.ToString();
        }
        //

        //
        public static string[] SortStancia(string str, out int MainStekIdx)
        {
            string[] OpStek = new string[str.Length];
            string[] MainStek = new string[str.Length];
            MainStekIdx = 0;
            int OpStekIdx = 0;

            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] == '-' && (i == 0 || str[i - 1] == '('))
                {
                    string num = "-";
                    i++;

                    while (i < str.Length && (char.IsDigit(str[i]) || str[i] == '.'))
                    {
                        num += str[i++];
                    }
                    i--;

                    MainStek[MainStekIdx++] = num;
                    continue;
                }

                if (char.IsDigit(str[i]))
                {
                    string num = "";
                    while (i < str.Length && (char.IsDigit(str[i]) || str[i] == '.'))
                    {
                        num += str[i++];
                    }
                    i--;

                    MainStek[MainStekIdx++] = num;
                }

                else if (str[i] == '(')
                {
                    OpStek[OpStekIdx++] = "(";
                }

                else if (str[i] == ')')
                {
                    while (OpStekIdx > 0 && OpStek[OpStekIdx - 1] != "(")
                    {
                        MainStek[MainStekIdx++] = OpStek[--OpStekIdx];
                    }
                    OpStekIdx--;
                }

                else if ("+-*/^".Contains(str[i]))
                {
                    while (OpStekIdx > 0 && OpStek[OpStekIdx - 1] != "(" && priorityty(OpStek[OpStekIdx - 1][0]) >= priorityty(str[i]))
                    {
                        MainStek[MainStekIdx++] = OpStek[--OpStekIdx];
                    }
                    OpStek[OpStekIdx++] = str[i].ToString();

                }
            }
            while (OpStekIdx > 0)
            {
                MainStek[MainStekIdx++] = OpStek[--OpStekIdx];
            } 

            return MainStek;
        }
        //

        //
        public static int priorityty(char op)
        {
            switch (op)
            {
                case '+': return 1;
                case '-': return 1;
                case '*': return 2;
                case '/': return 2;
                case '^': return 3;
                default: return 0;
            }
        }
        //
        
    }
}