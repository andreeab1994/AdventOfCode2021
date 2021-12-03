namespace Day3;

public class Incidence
{
    public Incidence()
    {
        Zero = 0;
        One = 0;
    }
    public int Zero { get; set; }
    public int One { get; set; }

    public string ReturnGreatest() => Zero > One ? "0" : "1";

    public string ReturnSmallest() => Zero < One ? "0" : "1";
}