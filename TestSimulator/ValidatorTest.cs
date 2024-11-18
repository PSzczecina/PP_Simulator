using Simulator;


namespace TestSimulator;

public class ValidatorTest
{
    [Theory]
    [InlineData(5,1,7,5)]
    [InlineData(3, 5, 20, 5)]
    [InlineData(12, 1, 10, 10)]
    [InlineData(8, 1, 12, 8)]
    public void Limiter_TestIf_BehavesProperly(int value, int min, int max, int expected)
    {
        //arrange
        //act
        var result = Validator.Limiter(value, min, max);
        //assert
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData("    pierwszyTekst     ", 4, 30, "PierwszyTekst")]
    [InlineData("         cze  ko  la  da  ", 4, 10, "Cze  ko  l")]
    [InlineData("  ok", 6, 10, "Ok####")]
    [InlineData("        ",4,12,"Unknown")]
    public void Shortener_TestIf_BehavesProperly(string text, int min, int max, string expected)
    {
        //arrange
        //act
        var result = Validator.Shortener(text, min, max, '#');
        //assert
        Assert.Equal(expected, result);
    }
}
