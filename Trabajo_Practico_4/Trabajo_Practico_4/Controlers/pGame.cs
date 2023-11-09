using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Trabajo_Practico_4.Controlers
{
    internal class pGame
    {
        //public static void getGame(TextBox[,] MatrixGame)
        //{
            
        //    SQLiteCommand cmd = new SQLiteCommand("SELECT\r\nTL.[00], TL.[01], TL.[02], TL.[10], TL.[11], TL.[12], TL.[20], TL.[21], TL.[22],\r\nTM.[00], TM.[01], TM.[02], TM.[10], TM.[11], TM.[12], TM.[20], TM.[21], TM.[22],\r\nTR.[00], TR.[01], TR.[02], TR.[10], TR.[11], TR.[12], TR.[20], TR.[21], TR.[22],\r\nML.[00], ML.[01], ML.[02], ML.[10], ML.[11], ML.[12], ML.[20], ML.[21], ML.[22],\r\nMM.[00], MM.[01], MM.[02], MM.[10], MM.[11], MM.[12], MM.[20], MM.[21], MM.[22],\r\nMR.[00], MR.[01], MR.[02], MR.[10], MR.[11], MR.[12], MR.[20], MR.[21], MR.[22],\r\nBL.[00], BL.[01], BL.[02], BL.[10], BL.[11], BL.[12], BL.[20], BL.[21], BL.[22],\r\nBM.[00], BM.[01], BM.[02], BM.[10], BM.[11], BM.[12], BM.[20], BM.[21], BM.[22],\r\nBR.[00], BR.[01], BR.[02], BR.[10], BR.[11], BR.[12], BR.[20], BR.[21], BR.[22]\r\nFROM GameGeneral GG\r\nJOIN MiddleLeft ML ON GG.GG_id = ML.ML_id\r\nJOIN MiddleMiddle MM ON GG.GG_Id = MM.MM_Id\r\nJOIN MiddleRight MR ON GG.GG_Id = MR.MR_Id\r\nJOIN BottomLeft BL ON GG.GG_Id = BL.BL_Id\r\nJOIN BottoMiddle BM ON GG.GG_Id = BM.BM_Id\r\nJOIN BottomRight BR ON GG.GG_Id = BR.BR_Id\r\nJOIN TopLeft TL ON GG.GG_Id = TL.TL_Id\r\nJOIN TopMiddle TM ON GG.GG_Id = TM.TM_Id\r\nJOIN TopRight TR ON GG.GG_Id = TR.TR_Id\r\nWHERE GG.GG_Id = 1");
        //    cmd.Connection = Conection.Connection;
        //    SQLiteDataReader obdr = cmd.ExecuteReader();

            
        //    int ob = 0;
        //    while (obdr.Read())
        //    {
        //        for (int i = 0; i < 9; i++)
        //        {
        //            for (int j = 0; j < 9; j++)
        //            {
        //                if (obdr.IsDBNull(ob))
        //                {
        //                    MatrixGame[i, j].Text = null;
        //                }
        //                else
        //                {
        //                    MatrixGame[i, j].Text = obdr.GetInt32(ob).ToString();
        //                }
        //                ob++;
        //            }
        //            ob++;
        //        }          

        //    }

        //}
        public static bool CheckGame()
        {
            bool GameExist = false;
            SQLiteCommand cmd = new SQLiteCommand("SELECT Status FROM GameGeneral");
            //cmd.Parameters.Add(new SQLiteParameter("@id", id));
            cmd.Connection = Conection.Connection;
            SQLiteDataReader obdr = cmd.ExecuteReader();
            while (obdr.Read())
            {
                if (obdr.GetInt16(0) == 1)
                {
                    GameExist = true; 
                }
            }
            return GameExist;
        }





        public static void GetGame(TextBox[,] MatrixGame, int id)
        {

            SQLiteCommand cmd = new SQLiteCommand("SELECT GS.[0], GS.[1], GS.[2], GS.[3], GS.[4], GS.[5], GS.[6], GS.[7], GS.[8] FROM GameSave GS\r\nJOIN GameGeneral GG\r\nON GS.GameSave_Id = GG.GG_Id\r\nWHERE GS.GameSave_Id = @id;\r\n");
            cmd.Parameters.Add(new SQLiteParameter("@id", id));
            cmd.Connection = Conection.Connection;
            SQLiteDataReader obdr = cmd.ExecuteReader();


            int ob = 0;
            while (obdr.Read())
            {
                for(int i = 0;i < 9;i++)
                {
                    if (obdr.IsDBNull(i))
                    {
                        MatrixGame[ob, i].Text = null;
                    }
                    else
                    {
                        MatrixGame[ob, i].Text = obdr.GetInt32(i).ToString();
                    }
                    
                }
                ob++;
            }
        }

        public static void UpdateGame(TextBox[,] MatrixGame)
        {
            SQLiteCommand cmd;
            for (int i = 0; i < MatrixGame.GetLength(0); i++)
            {
                for (int j = 0; j < MatrixGame.GetLength(1); j++)
                {
                    cmd = new SQLiteCommand($"UPDATE GameSave SET [{j.ToString()}] = @Variable1 WHERE GameSave_id = 1 AND Row = {i.ToString()}");
                    cmd.Parameters.Add(new SQLiteParameter("@Variable1", NullParseTB(MatrixGame[i, j].Text)));
                    //cmd.Parameters.Add(new SQLiteParameter("@id", c.Id));
                    cmd.Connection = Conection.Connection;
                    cmd.ExecuteNonQuery();
                }
            }
            cmd = new SQLiteCommand($"UPDATE GameGeneral SET Status = True WHERE GG_id = 1");                      
            cmd.Connection = Conection.Connection;
            cmd.ExecuteNonQuery();
        }

        public static int parseTB(string TB)
        {
            try
            {
                return int.Parse(TB);
            }
            catch (FormatException)
            {
                return 0;
            }
            catch (ArgumentNullException)
            {
                return 0;
            }
        }

        public static int? NullParseTB(string TB)
        {
            try
            {
                return int.Parse(TB);
            }
            catch (FormatException)
            {
                return null;
            }
            catch (ArgumentNullException)
            {
                return null;
            }
        }
    }
}
