using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConwaysGameOfLife
{
    public partial class Form1 : Form
    {
        Button pressedGridButton;
        Button pressedLifeButton;
        int gridSize = 26; //Default = 14
        Button[,] lifeButtons = new Button[28, 28]; // gridSize + 2, gridSize + 2
        int scaleValue = 30; // Default = 60
        int[,] lifeLocations = new int[28, 28]; // gridSize + 2, gridSize + 2
        int[,] prevLifeLocations = new int[28, 28]; // gridSize + 2, gridSize + 2
        public Form1()
        {
            InitializeComponent();
        }

        public void startButton_Click(object sender, EventArgs e)
        {
            startButton.Visible = false;

            for (int x = 1; x <= gridSize; x++)
            {
                Refresh();
                for (int y = 1; y <= gridSize; y++)
                {
                    Button gridButton = new Button();
                    this.Controls.Add(gridButton);
                    gridButton.Location = new Point(x * scaleValue, y * scaleValue);
                    gridButton.Size = new Size(scaleValue,scaleValue);
                    gridButton.Click += new EventHandler(gridButton_Click);
                    lifeLocations[x, y] = 0;
                    prevLifeLocations[x, y] = 0;
                }
            }
        }
        public void gridButton_Click (object sender, EventArgs e)
        {
            pressedGridButton = (Button)sender;
            debugLabel.Text = pressedGridButton.Location.X / scaleValue + "\n" + pressedGridButton.Location.Y / scaleValue;
            lifeButtons[pressedGridButton.Location.X / scaleValue, pressedGridButton.Location.Y / scaleValue] = new Button();
            this.Controls.Add(lifeButtons[pressedGridButton.Location.X / scaleValue, pressedGridButton.Location.Y / scaleValue]);
            lifeButtons[pressedGridButton.Location.X / scaleValue, pressedGridButton.Location.Y / scaleValue].Size = pressedGridButton.Size;
            lifeButtons[pressedGridButton.Location.X / scaleValue, pressedGridButton.Location.Y / scaleValue].Location = pressedGridButton.Location;
            lifeButtons[pressedGridButton.Location.X / scaleValue, pressedGridButton.Location.Y / scaleValue].BringToFront();
            lifeButtons[pressedGridButton.Location.X / scaleValue, pressedGridButton.Location.Y / scaleValue].BackColor = Color.Red;
            lifeButtons[pressedGridButton.Location.X / scaleValue, pressedGridButton.Location.Y / scaleValue].Click += new EventHandler(lifeButton_Click);

            for (int x = 1; x <= gridSize; x++)
            {
                for (int y = 1; y <= gridSize; y++)
                {
                    if (x * scaleValue == lifeButtons[pressedGridButton.Location.X / scaleValue, pressedGridButton.Location.Y / scaleValue].Location.X && y * scaleValue == lifeButtons[pressedGridButton.Location.X / scaleValue, pressedGridButton.Location.Y / scaleValue].Location.Y)
                    {
                        lifeLocations[x, y] = 1;
                        prevLifeLocations[x, y] = 1;
                    }
                }
            }
        }

        public void lifeButton_Click (object sender, EventArgs e)
        {
            pressedLifeButton = (Button)sender;
            for (int x = 1; x <= gridSize; x++)
            {
                for (int y = 1; y <= gridSize; y++)
                {
                    if (x * scaleValue == pressedLifeButton.Location.X && y * scaleValue == pressedLifeButton.Location.Y)
                    {
                        lifeLocations[x, y] = 0;
                        prevLifeLocations[x, y] = 0;
                    }
                }
            }
            pressedLifeButton.Visible = false;

        }

        private void runButton_Click(object sender, EventArgs e)
        {
            for (int x = 1; x <= gridSize; x++)
            {
                for (int y = 1; y <= gridSize; y++)
                {
                    if (prevLifeLocations[x, y] == 1)
                    {
                        int localLife = 0;
                        if (prevLifeLocations[x - 1, y] == 1)
                        {
                            localLife++;
                        }
                        if (prevLifeLocations[x + 1, y] == 1)
                        {
                            localLife++;
                        }
                        if (prevLifeLocations[x, y + 1] == 1)
                        {
                            localLife++;
                        }
                        if (prevLifeLocations[x, y - 1] == 1)
                        {
                            localLife++;
                        }
                        if (prevLifeLocations[x + 1, y + 1] == 1)
                        {
                            localLife++;
                        }
                        if (prevLifeLocations[x - 1, y - 1] == 1)
                        {
                            localLife++;
                        }
                        if (prevLifeLocations[x - 1, y + 1] == 1)
                        {
                            localLife++;
                        }
                        if (prevLifeLocations[x + 1, y - 1] == 1)
                        {
                            localLife++;
                        }

                        if (localLife != 2 && localLife != 3)
                        {
                            lifeLocations[x, y] = 0;
                            lifeButtons[x, y].Visible = false;
                        }
                    }
                    else
                    {
                        int localLife = 0;
                        if (prevLifeLocations[x - 1, y] == 1)
                        {
                            localLife++;
                        }
                        if (prevLifeLocations[x + 1, y] == 1)
                        {
                            localLife++;
                        }
                        if (prevLifeLocations[x, y + 1] == 1)
                        {
                            localLife++;
                        }
                        if (prevLifeLocations[x, y - 1] == 1)
                        {
                            localLife++;
                        }
                        if (prevLifeLocations[x + 1, y + 1] == 1)
                        {
                            localLife++;
                        }
                        if (prevLifeLocations[x - 1, y - 1] == 1)
                        {
                            localLife++;
                        }
                        if (prevLifeLocations[x - 1, y + 1] == 1)
                        {
                            localLife++;
                        }
                        if (prevLifeLocations[x + 1, y - 1] == 1)
                        {
                            localLife++;
                        }

                        if (localLife == 3)
                        {
                            lifeLocations[x, y] = 1;
                            lifeButtons[x, y] = new Button();
                            this.Controls.Add(lifeButtons[x, y]);
                            lifeButtons[x, y].Visible = true;
                            lifeButtons[x, y].Size = new Size(scaleValue, scaleValue);
                            lifeButtons[x, y].BackColor = Color.Red;
                            lifeButtons[x, y].Location = new Point(x * scaleValue, y * scaleValue);
                            lifeButtons[x, y].Click += new EventHandler(lifeButton_Click);
                            lifeButtons[x, y].BringToFront();
                        }
                        else
                        {
                            lifeLocations[x, y] = 0;
                        }
                    }
                }
            }

            for (int x = 1; x <= gridSize; x++)
            {
                for (int y = 1; y <= gridSize; y++)
                {
                    if (lifeLocations[x, y] != prevLifeLocations[x, y])
                    {
                        prevLifeLocations[x, y] = lifeLocations[x, y];
                    }
                }
            }
        }

        private void randomizeButton_Click(object sender, EventArgs e)
        {
            int lifeLikelyhood = 25; //Out of 100
            Random rand = new Random();
            for (int x = 1; x <= gridSize; x++)
            {
                for (int y = 1; y <= gridSize; y++)
                {
                    int isLife = rand.Next(1, 100);
                    if (isLife <= lifeLikelyhood && prevLifeLocations[x, y] == 0)
                    {
                        lifeButtons[x, y] = new Button();
                        this.Controls.Add(lifeButtons[x, y]);
                        lifeButtons[x, y].Visible = true;
                        lifeButtons[x, y].Size = new Size(scaleValue, scaleValue);
                        lifeButtons[x, y].BackColor = Color.Red;
                        lifeButtons[x, y].Location = new Point(x * scaleValue, y * scaleValue);
                        lifeButtons[x, y].Click += new EventHandler(lifeButton_Click);
                        lifeButtons[x, y].BringToFront();
                        lifeLocations[x, y] = 1;
                        prevLifeLocations[x, y] = 1;
                        if (x % 5 == 0 && y % 5 == 0)
                        {
                            Refresh();
                        }

                    }
                    else if (isLife <= lifeLikelyhood && prevLifeLocations[x, y] == 1)
                    {
                        lifeLocations[x, y] = 0;
                        prevLifeLocations[x, y] = 0;
                        lifeButtons[x, y].Visible = false;
                        if (x % 5 == 0 && y % 5 == 0)
                        {
                            Refresh();
                        }
                    }

                }
            }

        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            for (int x = 1; x <= gridSize; x++)
            {
                for (int y = 1; y <= gridSize; y++)
                {
                    if (lifeLocations[x, y] == 1)
                    {
                        lifeLocations[x, y] = 0;
                        prevLifeLocations[x, y] = 0;
                        lifeButtons[x, y].Visible = false;
                        if (x % 5 == 0 && y % 5 == 0)
                        {
                            Refresh();
                        }
                    }


                }
            }
        }
    }
}
