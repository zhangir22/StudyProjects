using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TicTacToeGame.Models
{
    public class TicTacToe
    {
        public readonly int crosses;
        public readonly int circlce;
        public int[,] Data { get; set; }  = { { 0, 0, 0 }, { 0, 0, 0 }, {0, 0, 0 } };
        public int rows ;
        public int column;
        public TicTacToe() 
        {
            crosses = 1;
            circlce = 0;
            rows = Data.GetUpperBound(0) + 1;
            column = Data.Length / rows;

        }
        public void InnerResult(int[] obj) 
        {
            for (int i = 0; i < rows; i++)
            {
                int temp = 0;
                Data[temp, i] = obj[i];
                if (i == 2)
                    temp++;
             
            }
        }
        /*
         * 5|5|5
         * 5|5|5
         * 5|5|5
         */
        public bool CheckWins(int typeUser) 
        {
            if (Data[0, 0] == typeUser && Data[0, 1] == typeUser && Data[0, 2] == typeUser)
            {
                return true;
            }
            else if (Data[1, 0] == typeUser && Data[1, 1] == typeUser && Data[1, 2] == typeUser)
                return true;
            else if (Data[2, 0] == typeUser && Data[2, 1] == typeUser && Data[2, 2] == typeUser)
                return true;

            if (Data[0, 0] == typeUser && Data[1, 1] == typeUser && Data[2, 2] == typeUser)
                return true;
            else if (Data[0, 2] == typeUser && Data[1, 1] == typeUser && Data[2, 0] == typeUser)
                return true;

            if (Data[0, 0] == typeUser && Data[1, 0] == typeUser && Data[2, 0] == typeUser)
                 return true;
            else if (Data[1, 1] == typeUser && Data[1, 1] == typeUser && Data[2, 1] == typeUser)
                 return true;
            else if (Data[1, 2] == typeUser && Data[1, 2] == typeUser && Data[2, 2] == typeUser)
                 return true;
            return false;
        }
    }
}