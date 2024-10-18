using System.Collections.Immutable;
using oezg.MathGame;

static void Loop(ImmutableList<GameStep> history) =>
    Loop(MenuFirst.Read()(history));

Loop([]);
