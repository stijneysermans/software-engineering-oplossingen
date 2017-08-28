using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace SchaakSpelStijn
{
    class Schaken
    {
        //klassenvariabelen
     int I, J;      
     public   string[,] chessBoardIntel;
     public Bord[,] chessBoardUI;
     public ScoreBord scoreBord;
     public int[,] locations;
     public bool whiteTurn = true;    
     public  bool isTileActivated = false;
     SchaakController controller;
        //methode nieuw bord aanmaken
            public void NieuwBord(SchaakBord T, SchaakController deController)
            {
                controller = deController;
            //Aanmaken bord intel
            chessBoardIntel = new string[8, 8]{
            {"bT","bP","bP","bP","bP","bP","bP","bT" },
            {"bP","bP","bP","bP","bP","bP","bP","bP" },
            {"E","E","E","E","E","E","E","E" },
            {"E","E","E","E","E","E","E","E" },
            {"E","E","E","E","E","E","E","E" },
            {"E","E","E","E","E","E","E","E" },
            {"wP","wP","wP","wP","wP","wP","wP","wP" },
            {"wT","wP","wP","wP","wP","wP","wP","wT" }};
            //Aanmaken boardsquares array
            chessBoardUI = new Bord[8, 8];
            //aanmaken mogelijke zetten array
            locations = new int[8, 8];
            //aanmaken boardsquares
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    chessBoardUI[i, j] = new Bord(deController);
                    chessBoardUI[i, j].Parent = T;
                    chessBoardUI[i, j].Location = new Point(j * 75 + 75, i * 75 + 75);
                    chessBoardUI[i, j].posX = j;
                    chessBoardUI[i, j].posY = i;
                    chessBoardUI[i, j].Size = new Size(75, 75);
                    //black/white                 
                    DrawCheckers(i, j);
                }
            }
                //SCorebord aanmaken om te tonen op het formulier
            scoreBord = new ScoreBord(deController);
            scoreBord.Parent = T;
            scoreBord.Location = new Point(675,75);

            validate();
            drawing();
        }
        //tekent images van speelstukken en kent kleuren toe aan vakken
            public void drawing()
            {
                //Plaatjes toekennen aan elk stuk
                for (int i = 0; i < 8; i++)
                {
                    for (int j = 0; j < 8; j++)
                    {
                        switch (chessBoardIntel[i, j])
                        {
                            case "E": chessBoardUI[i, j].BackgroundImage = null; break;
                            case "wP": chessBoardUI[i, j].BackgroundImage = Image.FromFile("../../Pics/pawnWhite.png"); break;
                            case "bP": chessBoardUI[i, j].BackgroundImage = Image.FromFile("../../Pics/pawnBlack.png"); break;
                            case "bT": chessBoardUI[i, j].BackgroundImage = Image.FromFile("../../Pics/rookBlack.png"); break;
                            case "wT": chessBoardUI[i, j].BackgroundImage = Image.FromFile("../../Pics/rookWhite.png"); break;
                        }
                    }
                }
                //Achtergrondkleuk van mogelijke zetten activeren
                for (int i = 0; i < 8; i++)
                {
                    for (int j = 0; j < 8; j++)
                    {
                        if (locations[i, j] == 2)
                        {
                            chessBoardUI[i, j].BackColor = Color.GreenYellow;
                        }
                        else
                        {
                            DrawCheckers(i, j);
                        }
                        if (locations[i, j] == 3)
                        {
                            chessBoardUI[i, j].BackColor = Color.Beige;
                        }
                    }
                }
            }
        public void TileActivate(Bord Tile)
        {        
            //Opvragen locations voor aangeklikte stuk
            int i, j;
            i = Tile.posY;
            j = Tile.posX;
            switch (locations[i, j])
            {
                    //nieuw speelstuk activeren
                case 1:
                    if (!isTileActivated)
                    {
                        SpeelStuk(chessBoardIntel[i, j], i, j);
                        Activate();
                        I = i;
                        J = j; 
                    }
                    break;
                    //geactiveerde speelstuk naar mogelijke locatie brengen
                case 2: change(i, j);
                    Activate();
                    break;                   
                //geactiveerde speelstuk deactiveren
                case 3:
                    if (isTileActivated)
                    {
                        validate();
                        Activate();
                    }
                    break;
            }            
        }
        //methode om te zien welk speelstuk is geactiveerd en mogelijke zetten van dat speelstuk
        public void SpeelStuk(string stuk, int x, int y)
        {
            int i;
                    switch (stuk)
                    {
                            //WITTE SPEELSTUKKEN
                            //witte pion
                        case "wP":
                            if (whiteTurn)
                            {
                                if (y - 1 >= 0)
                                    if (chessBoardIntel[x - 1, y - 1].Substring(0, 1) == "b")
                                        locations[x - 1, y - 1] = 2;
                                if (chessBoardIntel[x - 1, y] == "E")
                                    locations[x - 1, y] = 2;
                                if (y + 1 < 8)
                                    if (chessBoardIntel[x - 1, y + 1].Substring(0, 1) == "b")
                                        locations[x - 1, y + 1] = 2;
                                if (x == 6)
                                    if (chessBoardIntel[x - 2, y] == "E")
                                        locations[x - 2, y] = 2;
                            }
                    break;
                            //witte toren
                        case "wT":
                    if (whiteTurn)
                    {
                        for (i = x - 1; i > -1; i--)
                            if (chessBoardIntel[i, y] == "E")
                            { 
                                locations[i, y] = 2; 
                            }
                            else
                                if (chessBoardIntel[i, y].Substring(0, 1) == "w")
                                    break;
                                else
                                { 
                                    locations[i, y] = 2; 
                                    break; 
                                }
                        for (i = x + 1; i < 8; i++)
                            if (chessBoardIntel[i, y] == "E")
                            { 
                                locations[i, y] = 2; 
                            }
                            else
                                if (chessBoardIntel[i, y].Substring(0, 1) == "w")
                                    break;
                                else
                                { 
                                    locations[i, y] = 2;
                                    break; 
                                }
                        for (i = y - 1; i > -1; i--)
                            if (chessBoardIntel[x, i] == "E")
                            {
                                locations[x, i] = 2; 
                            }
                            else
                                if (chessBoardIntel[x, i].Substring(0, 1) == "w")
                                    break;
                                else
                                { 
                                    locations[x, i] = 2; 
                                    break; 
                                }
                        for (i = y + 1; i < 8; i++)
                            if (chessBoardIntel[x, i] == "E")
                            { 
                                locations[x, i] = 2; 
                            }
                            else
                                if (chessBoardIntel[x, i].Substring(0, 1) == "w")
                                    break;
                                else
                                { 
                                    locations[x, i] = 2; 
                                    break;
                                }
                    }
                    break;
                            //ZWARTE SPEELSTUKKEN
                            //zwarte pion                  
                        case "bP":
                    if (!whiteTurn)
                    {
                        if (y - 1 >= 0)
                            if (chessBoardIntel[x + 1, y - 1].Substring(0, 1) == "w")
                                locations[x + 1, y - 1] = 2;
                        if (chessBoardIntel[x + 1, y] == "E")
                            locations[x + 1, y] = 2;
                        if (y + 1 < 8)
                            if (chessBoardIntel[x + 1, y + 1].Substring(0, 1) == "w")
                                locations[x + 1, y + 1] = 2;
                        if (x == 1)
                            if (chessBoardIntel[x + 2, y] == "E")
                                locations[x + 2, y] = 2;
                    }
                        break;
                            //zwarte toren
                        case "bT":
                        if (!whiteTurn)
                        {
                            for (i = x - 1; i > -1; i--)
                                if (chessBoardIntel[i, y] == "E")
                                { locations[i, y] = 2; }
                                else
                                    if (chessBoardIntel[i, y].Substring(0, 1) == "b")
                                        break;
                                    else
                                    {
                                        locations[i, y] = 2;
                                        break;
                                    }
                            for (i = x + 1; i < 8; i++)
                                if (chessBoardIntel[i, y] == "E")
                                {
                                    locations[i, y] = 2;
                                }
                                else
                                    if (chessBoardIntel[i, y].Substring(0, 1) == "b")
                                        break;
                                    else
                                    {
                                        locations[i, y] = 2;
                                        break;
                                    }
                            for (i = y - 1; i > -1; i--)
                                if (chessBoardIntel[x, i] == "E")
                                {
                                    locations[x, i] = 2;
                                }
                                else
                                    if (chessBoardIntel[x, i].Substring(0, 1) == "b")
                                        break;
                                    else
                                    {
                                        locations[x, i] = 2;
                                        break;
                                    }
                            for (i = y + 1; i < 8; i++)
                                if (chessBoardIntel[x, i] == "E")
                                { locations[x, i] = 2; }
                                else
                                    if (chessBoardIntel[x, i].Substring(0, 1) == "b")
                                        break;
                                    else
                                    {
                                        locations[x, i] = 2;
                                        break;
                                    }
                        }
                        break;
                    }
            //zorgt dat aangeklikte speelstuk wordt geactiveerd
                    locations[x, y] = 3;
                    drawing();            
        }
        //valideert het bord
        public void validate()
        {
            int i, j;
            //Kijken welke vakjes toegankelijk zijn
            for (i = 0; i < 8; i++)
                for (j = 0; j < 8; j++)
                {
                    if (chessBoardIntel[i, j] != "E")
                        locations[i, j] = 1;
                    else
                        locations[i, j] = 0;
                }
            //tekent voor elke vak zijn juiste bord kleur
            for (i = 0; i < 8; i++)
            {
                for (j = 0; j < 8; j++)
                {
                    DrawCheckers(i, j);   
                }             
            }
        }
        //tekent de zwarte en witte vakken
        public void DrawCheckers(int i, int j)
        {
            if (i % 2 == 0)
                if (j % 2 == 1)
                    chessBoardUI[i, j].BackColor = Color.Black;
                else
                    chessBoardUI[i, j].BackColor = Color.White;
            else
                if (j % 2 == 1)
                    chessBoardUI[i, j].BackColor = Color.White;
                else
                    chessBoardUI[i, j].BackColor = Color.Black;
        }
        //verschuift het speelstuk naar de toegankelijke locatie
        public void change(int i, int j)
        {
            //kijkt of het aangeduide tile een vijandelijke speler bevat en roept dan de addscore methode op
            if (locations[i, j] == 2 && chessBoardIntel[i, j].Substring(0, 1) == "w" || chessBoardIntel[i, j].Substring(0, 1) == "b")
            {
                addScore(chessBoardIntel[i, j]); 
            }
            chessBoardIntel[i, j] = chessBoardIntel[I, J];
            chessBoardIntel[I, J] = "E";
            ChangeTurn();
            validate();
            drawing();
        }
        //zet de beurtwisseling variabele om
        public void ChangeTurn()
        { 
        if (whiteTurn)
        {
            whiteTurn = false;
            controller.UpdateUi(whiteTurn);
        }
        else
        {
            whiteTurn = true;
            controller.UpdateUi(whiteTurn);
        }
        }
        //houd bij of een tile geactiveerd is of niet
        public void Activate()
        {
            if (isTileActivated)
            {
                isTileActivated = false;
            }
            else
            {
                isTileActivated = true;
            }
        }
        //zorgt dat het dode stuk wordt doorgegeven aan de controller
        public void addScore(string doodStuk)
        {
            controller.UpdateScore(doodStuk,scoreBord );
        }
    }
}
