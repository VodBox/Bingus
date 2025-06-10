using BingusCommon;

namespace Bingus.UI
{
    public partial class GameSettingsControl : UserControl
    {
        public GameSettingsControl()
        {
            InitializeComponent();
            _randomSeedUpDown.ValueChanged += (o, e) => SeedChanged?.Invoke();
        }

        public int CurrentSeed => Convert.ToInt32(_randomSeedUpDown.Value);

        public Action? SeedChanged;

        public BingoGameSettings Settings
        {
            get
            {
                return new BingoGameSettings(
                    Convert.ToInt32(_boardXUpDown.Value),
                    Convert.ToInt32(_boardYUpDown.Value),
                    _lockoutCheckBox.Checked,
                    false,
                    new HashSet<EldenRingClasses>(),
                    0,//Number of classes to pick
                    Convert.ToInt32(_maxCategoryUpDown.Value),//Max number of squares in the same category
                    Convert.ToInt32(_randomSeedUpDown.Value), //Random seed
                    Convert.ToInt32(_preparationTimeUpDown.Value), //Preparation time in seconds
                    Convert.ToInt32(_bonusPointsUpDown.Value) //Bonus points for a bingo line
                );
            }
            set
            {
                _boardXUpDown.Value = value.BoardSizeX;
                _boardYUpDown.Value = value.BoardSizeY;
                _boardYUpDown.Enabled = value.BoardSizeX != value.BoardSizeY;
                _lockoutCheckBox.Checked = value.Lockout;
                _maxCategoryUpDown.Value = value.CategoryLimit;
                _randomSeedUpDown.Value = value.RandomSeed;
                _preparationTimeUpDown.Value = value.PreparationTime;
                _bonusPointsUpDown.Value = value.PointsPerBingoLine;
                _squareCheckBox.Checked = value.BoardSizeX == value.BoardSizeY;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _randomSeedUpDown.Value = 0;
        }

        private void squareCheckBox_Changed(object sender, EventArgs e)
        {
            _boardYUpDown.Enabled = !_squareCheckBox.Checked;
            _boardYUpDown.Value = _boardXUpDown.Value;
        }

        private void boardXUpDownChanged(object sender, EventArgs e)
        {
            if (_squareCheckBox.Checked)
            {
                _boardYUpDown.Value = _boardXUpDown.Value;
            }
        }
    }
}