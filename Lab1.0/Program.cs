using System.Text;

namespace Lab1
{
    internal class Program
    {
        static List<string> valid = new List<string>();

        static void Main(string[] args)
        {
            Console.Write("Enter a text string: ");
            string input = Console.ReadLine();

            HighLight(input);
            Total();
        }

        private static void HighLight(string input)
        {
            var sb = new StringBuilder();
            var prefix = new StringBuilder();
            var suffix = string.Empty;

            for (var i = 0; i < input.Length; i++)
            {
                var current = input[i];
                sb.Append(current);

                for (var j = i + 1; j < input.Length; j++)
                {
                    if (char.IsLetter(input[j]))
                        break;

                    if (current != input[j])
                        sb.Append(input[j]);
                    else
                    {
                        sb.Append(input[j]);
                        suffix = input.Substring(j + 1);
                        break;
                    }
                }

                if (sb.Length > 1 && sb[0] == sb[sb.Length - 1])
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write(prefix);
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write(sb);
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write(suffix);
                    Console.WriteLine();
                    valid.Add(sb.ToString());
                }

                sb.Length = 0;
                prefix.Append(current);
            }
        }

        private static void Total()
        {
            ulong total = 0;
            foreach (var number in valid)
            {
                total += Convert.ToUInt64(number);
            }
            Console.WriteLine();
            Console.WriteLine("the total is: " + total);
        }
    }
}
