namespace oezg.MathGame
{
    public record GameStep(ArithmeticOperation Operation, int Operand1, int Operand2, int UserAnswer)
    {
        int Answer => Operation.ToFunction()(Operand1, Operand2);
        public bool Correct =>
            UserAnswer == Answer;

        public override string ToString()
        {
            return $"{Operand1} {Operation.ToSymbol()} {Operand2} = {Answer}. Your answer was {(Correct ? "correct" : UserAnswer)}.";
        }
    }
}