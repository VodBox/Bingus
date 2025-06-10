namespace BingusCommon
{
    public record struct BingoGameSettings(int BoardSizeX, int BoardSizeY, bool Lockout, bool RandomClasses, ISet<EldenRingClasses> ValidClasses, int NumberOfClasses, int CategoryLimit, int RandomSeed, int PreparationTime, int PointsPerBingoLine);
}