namespace SA.RPS.WebUI.ViewModels
{
    public class GamePlayViewModel
    {
        public string Result { get; set; }
        public int PlayerScore { get; set; }
        public int OpponentScore { get; set; }
        public string OpponentGame { get; set; }
        public string PlayerGame { get; set; }
        public bool CanPlayAgain { get; set; }
    }
}