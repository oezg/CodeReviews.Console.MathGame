namespace oezg.MathGame
{
    public enum ArithmeticOperation
    {
        ADDITION,
        SUBTRACTION,
        MULTIPLICATION,
        DIVISION,

    }

    public static class ArithmeticOperationExtensions
    {
        public static Func<int, int, int> ToFunction(this ArithmeticOperation arithmeticOperation) =>
            arithmeticOperation switch
            {
                ArithmeticOperation.ADDITION => (a, b) => a + b,
                ArithmeticOperation.SUBTRACTION => (a, b) => a - b,
                ArithmeticOperation.MULTIPLICATION => (a, b) => a * b,
                ArithmeticOperation.DIVISION => (a, b) => a / b,
                _ => throw new ArgumentException($"Unsupported operation: {arithmeticOperation}"),
            };

        public static string ToSymbol(this ArithmeticOperation arithmeticOperation) =>
            arithmeticOperation switch
            {
                ArithmeticOperation.ADDITION => "+",
                ArithmeticOperation.SUBTRACTION => "-",
                ArithmeticOperation.MULTIPLICATION => "*",
                ArithmeticOperation.DIVISION => "/",
                _ => throw new ArgumentException($"Unsupported operation: {arithmeticOperation}"),
            };

    }
}