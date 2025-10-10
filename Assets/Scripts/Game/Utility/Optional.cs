using System;

public class Optional<T>
{
    private readonly T value;
    private readonly bool isPresent;

    private Optional(T value, bool isPresent)
    {
        this.value = value;
        this.isPresent = isPresent;
    }

    public static Optional<T> Of(T value)
    {
        if (value == null)
        {
            throw new InvalidOperationException("The value should be initialised");
        }
        return new Optional<T>(value, true);
    }

    public static Optional<T> Empty() => new(default, false);

    public T Get() => IsPresent ? value : throw new InvalidOperationException("The value should be initialised");

    public bool IsPresent
    {
        get => isPresent;
    }

}
