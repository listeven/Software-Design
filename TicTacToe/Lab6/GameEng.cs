using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab6
{
    public class GameEng
    {
        public bool User_Turn = true;
        public bool Game_Over = false;
        public bool User_Win = false;
        public bool Comp_Win = false;
        public bool Game_Tie = false;
        public bool Comp_First = false;
        public enum CellSelection { N, O, X };
        public CellSelection[,] grid = new CellSelection[3, 3];

        public bool Check_Tie()
        {
            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                    if (grid[i, j] == CellSelection.N)
                    {
                        return false;
                    }
            return true;
        }

        public bool Check_User_Win()
        {
            int count = 0;
            int count2 = 0;


            for (int i = 0; i < 3; i++)
            {
                count = 0;
                count2 = 0;

                for (int j = 0; j < 3; j++)
                {
                    if (grid[i, j] == CellSelection.X)
                    {
                        count++;
                    }
                    if (grid[j, i] == CellSelection.X)
                    {
                        count2++;
                    }
                    if (count == 3 || count2 == 3)
                    {
                        return true;
                    }
                }
            }

            if (grid[0, 0] == CellSelection.X && grid[1, 1] == CellSelection.X && grid[2, 2] == CellSelection.X)
            {
                return true;
            }
            if (grid[0, 2] == CellSelection.X && grid[1, 1] == CellSelection.X && grid[2, 0] == CellSelection.X)
            {
                return true;
            }
            return false;
        }

        public bool Check_Comp_Win()
        {
            int count = 0;
            int count2 = 0;


            for (int i = 0; i < 3; i++)
            {
                count = 0;
                count2 = 0;

                for (int j = 0; j < 3; j++)
                {
                    if (grid[i, j] == CellSelection.O)
                    {
                        count++;
                    }
                    if (grid[j, i] == CellSelection.O)
                    {
                        count2++;
                    }
                    if (count == 3 || count2 == 3)
                    {
                        return true;
                    }
                }
            }

            if (grid[0, 0] == CellSelection.O && grid[1, 1] == CellSelection.O && grid[2, 2] == CellSelection.O)
            {
                return true;
            }
            if (grid[0, 2] == CellSelection.O && grid[1, 1] == CellSelection.O && grid[2, 0] == CellSelection.O)
            {
                return true;
            }
            return false;
        }



        public void User_Move(int i, int j)
        {
            if (Game_Over)
            {
                MessageBox.Show("Please start a new game!", "Game Over");
                return;
            }
            //only allow setting empty cells
            if (User_Turn == true)
            {
                if (grid[i, j] == CellSelection.N)
                {
                    grid[i, j] = CellSelection.X;
                    User_Turn = false;
                    if (Check_User_Win())
                    {
                        Game_Over = true;
                        User_Win = true;
                        return;
                    }
                    if (Check_Tie())
                    {
                        Game_Over = true;
                        Game_Tie = true;
                        return;
                    }
                    if (User_Turn == false)
                    {
                        Comp_Turn();
                        User_Turn = true;
                    }
                    if (Check_Comp_Win())
                    {
                        Game_Over = true;
                        Comp_Win = true;
                        return;
                    }
                    if (Check_Tie())
                    {
                        Game_Over = true;
                        Game_Tie = true;
                        return;
                    }

                }
                else
                {
                    MessageBox.Show("Bad move! Try again.", "Error");
                }
            }
        }

        public void Comp_Turn()
        {
            if (Comp_First)
            {
                Random random = new Random();
                int num = random.Next(0, 2);
                int num2 = random.Next(0, 2);
                grid[num, num2] = CellSelection.O;
                Comp_First = false;
            }
            else
            {
                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        if (grid[i, j] == CellSelection.N)
                        {
                            grid[i, j] = CellSelection.O;
                            if (Check_Comp_Win() == true)
                            {
                                Game_Over = true;
                                Comp_Win = true;
                                return;
                            }
                            else
                            {
                                grid[i, j] = CellSelection.N;
                            }
                        }
                    }
                }

                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        if (grid[i, j] == CellSelection.N)
                        {
                            grid[i, j] = CellSelection.X;
                            if (Check_User_Win() == true)
                            {
                                grid[i, j] = CellSelection.O;
                                return;
                            }
                            else
                            {
                                grid[i, j] = CellSelection.N;
                            }
                        }
                    }
                }
                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        if (grid[i, j] == CellSelection.N)
                        {
                            grid[i, j] = CellSelection.O;
                            return;
                        }
                    }
                }
            }
        }
    }
}
