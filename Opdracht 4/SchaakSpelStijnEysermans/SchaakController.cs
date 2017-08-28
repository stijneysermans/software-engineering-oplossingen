using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchaakSpelStijn
{
    public class SchaakController
    {
        Schaken mChess = new Schaken();
        SchaakBord bord;
        ScoreBord hetScorebord;
        public void GameStart (SchaakBord T)
        {
            //nieuw bord starten en controller meegeven
            mChess.NieuwBord(T, this);
            bord = T;
        }
        public void TileClick(Bord B)
        {
            //tile meegeven
            mChess.TileActivate(B);
        }
        public void UpdateUi(bool turn)
        {
            //text omzetten naar persoons beurt
            if (turn)
            {
                bord.UpdateTurn("Wit is aan de beurt");
            }
            else
            {
                bord.UpdateTurn("Zwart is aan de beurt");
            }
        }       
        public void UpdateScore(string doodStuk, ScoreBord scoreBordje)
        {
            hetScorebord = scoreBordje;
            hetScorebord.addScore(doodStuk); 
        }
    }
}
