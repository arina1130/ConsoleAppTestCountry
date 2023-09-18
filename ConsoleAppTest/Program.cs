internal class Program
{
    private static void Main(string[] args)
    {
        while(true)
        {
            Console.WriteLine("Введите последовательность скобок");
            string s = Console.ReadLine();
            Console.WriteLine(IsCorrectSequence(s));
        }
        
    }

    public static bool IsCorrectSequence(string s)
    {
        Stack<char> stack = new Stack<char>();  
        foreach (char c in s)
        {
            if("{[(".Contains(c)) stack.Push(c);
            else if ("}])".Contains(c))
            {
                if(stack.Count==0) return false;
                char open = stack.Pop();
                if (open == '{' & c == '}' || open == '[' & c == ']' || open == '(' & c == ')') continue;
                else return false;
            }
        }
        if (stack.Count != 0) return false;
        return true;
    }
}