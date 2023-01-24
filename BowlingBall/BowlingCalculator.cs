namespace BowlingBall;

public class BowlingCalculator
{
    int TotalScore { get; set; } = 0;
    int OneThrowLater { get; set; } = 0;
    int TwoThrowsLater { get; set; } = 0;

    public int Calculate(Frame[] scoringArray)
    {
        var highestIndex = scoringArray.Length -1;

        for (var frameIndex = highestIndex; frameIndex >= 0; frameIndex--)
        {   
            var isNotFinalFrame = frameIndex != highestIndex;
            var currentFrame = scoringArray[frameIndex];
            
            TotalScore += currentFrame.GetValue();

            if (isNotFinalFrame && currentFrame.IsStrikeFrame)
            {
                TotalScore += OneThrowLater + TwoThrowsLater;
                TwoThrowsLater = OneThrowLater;
                OneThrowLater = 10;
                continue;
            }

            if (isNotFinalFrame && currentFrame.IsSpareFrame)
            {
                TotalScore += OneThrowLater;
            }

            OneThrowLater = currentFrame.Throw1;
            TwoThrowsLater = currentFrame.Throw2;
        }
        return TotalScore;
    }
}