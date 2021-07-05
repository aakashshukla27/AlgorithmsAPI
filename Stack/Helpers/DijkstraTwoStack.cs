using System;
using System.Collections.Generic;
using System.Text;

namespace Stack.Helpers
{
    class DijkstraTwoStack
    {
        Stack<string> ops = new Stack<string>();
        Stack<double> values = new Stack<double>();
        public DijkstraTwoStack(string expression)
        {
            var temp = TokenizeString(expression);
            double value = Evaluate(temp);
        }

        public List<string> TokenizeString(String s)
        {
            List<string> returnList = new List<string>();
            foreach(char c in s)
            {
                returnList.Add(c.ToString());
            }
            return returnList;
        }

        public double Evaluate(List<string> ch)
        {
            for (int i = 0; i < ch.Count; i++)
            {
                string c = ch[i];
                switch (c)
                {
                    case "(":
                        break;
                    case "+":
                    case "-":
                    case "*":
                    case "/":
                        ops.Push(c);
                        break;
                    case ")":
                        String op = ops.Pop();
                        double v = values.Pop();
                        if (op == "+") 
                            v = values.Pop() + v;
                        else if (op == "-") 
                            v = values.Pop() - v;
                        else if (op == "*") 
                            v = values.Pop() * v;
                        else if (op == "/") 
                            v = values.Pop() / v;
                        values.Push(v);
                        break;
                    default:
                        values.Push(Double.Parse(c));
                        break;
                }
            }

            return values.Peek();
        }

        public double returnValue()
        {
            return values.Peek();
        }


    }
}
