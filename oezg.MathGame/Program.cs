using System.Collections.Immutable;
using oezg.MathGame;

loop(history: []);

static void loop(ImmutableList<GameStep> history) =>
    loop(MenuFirst.Read()(history));
