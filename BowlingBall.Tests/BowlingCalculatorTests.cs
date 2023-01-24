namespace BowlingBall.Tests;

public class BowlingCalculatorTests
{
    [Theory]
    [InlineData(new string[] {"45", "23", "71"}, 22)]
    [InlineData(new string[] {"45", "2-", "71"}, 19)]
    [InlineData(new string[] {"4/", "2-", "71"}, 22)]
    [InlineData(new string[] {"4/", "X", "71"}, 46)]
    [InlineData(new string[] {"4/", "X", "71", "XXX"}, 76)]
    [InlineData(new string[] {"3/", "X", "XXX"}, 80)]

    public void Result_should_give_correct_result(string[] scoringArray, int result)
    {
        // arrange
        var frameArray = scoringArray.Select(stringScore => new Frame(stringScore)).ToArray();
        var bowlingCalculator = new BowlingCalculator();

        // act
        var score = bowlingCalculator.Calculate(frameArray);

        // assert
        score.Should().Be(result);
    }
}