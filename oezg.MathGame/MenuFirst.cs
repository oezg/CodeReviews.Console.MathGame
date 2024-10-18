using System.Collections.Immutable;

namespace oezg.MathGame
{
    public enum MenuFirstOption
    {
        PLAY,
        EXIT,
        SCORE,
        HISTORY
    }

    public static class MenuFirst
    {
        public static Func<ImmutableList<GameStep>, ImmutableList<GameStep>> Read()
        {
            Print();
            return ReadMenuFirst() switch
            {
                MenuFirstOption.EXIT => Exit,
                MenuFirstOption.SCORE => Score,
                MenuFirstOption.HISTORY => History,
                _ => Play,
            };
        }
        public static void Print()
        {
            Console.WriteLine("--------------------------");
            Console.WriteLine("First Menu, please enter one of the options. Default: Play");
            Console.WriteLine(string.Join(", ", Enum.GetValues<MenuFirstOption>()));
        }

        public static MenuFirstOption ReadMenuFirst() =>
            Enum.TryParse(Console.ReadLine(), true, out MenuFirstOption menuFirstOption)
                ? menuFirstOption
                : MenuFirstOption.PLAY;

        public static ImmutableList<GameStep> Exit(ImmutableList<GameStep> history)
        {
            Console.WriteLine("Bye!");
            Environment.Exit(0);
            return history;
        }

        public static ImmutableList<GameStep> History(ImmutableList<GameStep> history)
        {
            Console.WriteLine(history.IsEmpty ? "Your history is empty" : string.Join(Environment.NewLine, history));
            return history;
        }

        public static ImmutableList<GameStep> Score(ImmutableList<GameStep> history)
        {
            Console.WriteLine($"Score: {history.Count(step => step.Correct)} correct answers. Total questions: {history.Count}");
            return history;
        }

        public static ImmutableList<GameStep> Play(ImmutableList<GameStep> history)
        {
            GameStep? gameStep = MenuSecond.Read();
            if (gameStep == null)
            {
                Console.WriteLine("Your answer has to be a number. This step is discarded.");
                return history;
            }
            return history.Add(gameStep);
        }
    }
}