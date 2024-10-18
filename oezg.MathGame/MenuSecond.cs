namespace oezg.MathGame
{
    public static class MenuSecond
    {
        const int MIN_OPERAND = 1;
        const int MAX_OPERAND = 123;
        static readonly Random random = new();

        public static GameStep? Read()
        {
            int operand1;
            int operand2;

            Print();
            ArithmeticOperation operation = ReadMenuSecond();
            do
            {
                operand1 = random.Next(MIN_OPERAND, MAX_OPERAND);
                operand2 = random.Next(MIN_OPERAND, MAX_OPERAND);

            } while (operation == ArithmeticOperation.DIVISION && operand1 % operand2 != 0);
            Console.WriteLine($"{operand1} {operation.ToSymbol()} {operand2} = ?");
            return int.TryParse(Console.ReadLine(), out int userNumber)
                        ? new GameStep(operation, operand1, operand2, userNumber)
                        : null;

        }

        public static void Print()
        {
            Console.WriteLine("Second Menu, please enter one of the options. Default: Addition");
            Console.WriteLine(string.Join(", ", Enum.GetValues<ArithmeticOperation>()));
        }

        public static ArithmeticOperation ReadMenuSecond() =>
            Enum.TryParse(Console.ReadLine(), true, out ArithmeticOperation SupportedOperations)
                ? SupportedOperations
                : ArithmeticOperation.ADDITION;
    }
}