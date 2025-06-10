using Newtonsoft.Json;

namespace BingusCommon
{
    public class BingoBoard
    {
        public BingoBoard(int sizeX, int sizeY, bool lockout, BingoBoardSquare[] squares, EldenRingClasses[] availableClasses)
        {
            SizeX = sizeX;
            SizeY = sizeY;
            Lockout = lockout;
            if (squares.Length != sizeX * sizeY)
                throw new ArgumentException($"Needs exactly {sizeX * sizeY} squares");
            Squares = squares;
            AvailableClasses = availableClasses;

        }

        public int SizeX { get; init; }
        public int SizeY { get; init; }
        public int SquareCount => SizeX * SizeY;
        public BingoBoardSquare[] Squares { get; init; }
        public EldenRingClasses[] AvailableClasses { get; init; }
        public bool Lockout { get; init; }

    }

    public record struct BingoBoardSquare(string Text, string Tooltip, int[] Team, bool Marked, SquareCounter[] Counters)
    {
        [JsonProperty]
        public string Text { get; set; } = Text;
        [JsonProperty]
        public string Tooltip { get; set; } = Tooltip;
        [JsonIgnore]
        public int[] Team { get; set; } = Team;
        [JsonIgnore]
        public bool Marked { get; set; } = Marked;
        [JsonIgnore]
        public SquareCounter[] Counters { get; set; } = Counters;

        public bool IsChecked(int team)
        {
            return Team.Contains(team);
        }

        public override string ToString()
        {
            return Text;
        }
    }
}