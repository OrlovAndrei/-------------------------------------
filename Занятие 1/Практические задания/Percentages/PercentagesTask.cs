using System.Globalization;

namespace DepositCalculator
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("������� �������� ������ (�����, ���������� ������, ���� � �������) ����� ������:");
            string input = Console.ReadLine();
            double result = Calculate(input);
            Console.WriteLine(Math.Round(result));
        }

        public static double Calculate(string input)
        {
            string[] parts = input.Split(' ');

            double principal = double.Parse(parts[0], CultureInfo.InvariantCulture);
            double annualRate = double.Parse(parts[1], CultureInfo.InvariantCulture) / 100;
            int months = int.Parse(parts[2], CultureInfo.InvariantCulture);

            return principal * Math.Pow(1 + (annualRate / 12), months);
        }
    }
}