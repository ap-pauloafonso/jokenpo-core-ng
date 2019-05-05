namespace Business.Modelos
{
    public class PartidaWinLossDraw
    {
        public int winCount { get; set; }
        public int lossCount { get; set; }
        public int drawCount { get; set; }

        public string resultFinal
        {
            get
            {
                return winCount == lossCount ? "draw" : winCount > lossCount ? "win" : "loss";
            }
        }

    }
}