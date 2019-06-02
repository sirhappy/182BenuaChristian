using System;

namespace dbTask
{
    public interface IEntity : IEquatable<IEntity>
    {
        long Id { get; }
    }

    public interface IConsolePrompt
    {
        string ConsolePrompt { get; }
    }
}