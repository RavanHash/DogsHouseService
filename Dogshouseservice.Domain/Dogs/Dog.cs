namespace Dogshouseservice.Domain.Dogs;

public class Dog
{
    public string Name { get; set; } = null!;
    public string Color { get; set; } = null!;
    public int TailLength { get; set; }
    public int Weight { get; set; }

    public override string ToString()
    {
        return $"{nameof(Name)}:{Name}, {nameof(Color)}:{Color}, {nameof(TailLength)}:{TailLength}, {nameof(Weight)}:{Weight}";
    }
}