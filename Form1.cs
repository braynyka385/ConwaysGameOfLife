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
        Button[,] lifeButtons = new Button[12, 12];
        int scaleValue = 60;
        int[,] lifeLocations = new int[12, 12];
        public Form1()
        {
            InitializeComponent();
        }

        public void startButton_Click(object sender, EventArgs e)
        {
            startButton.Visible = false;

            for (int x = 2; x <= 11; x++)
            {
                for (int y = 1; y <= 10; y++)
                {
                    Button gridButton = new Button();
                    this.Controls.Add(gridButton);
                    gridButton.Location = new Point(x * scaleValue, y * scaleValue);
                    gridButton.Size = new Size(scaleValue,scaleValue);
                    gridButton.Click += new EventHandler(gridButton_Click);
                }
            }
        }
        public void gridButton_Click (object sender, EventArgs e)
        {
            pressedGridButton = (Button)sender;
            debugLabel.Text = pressedGridButton.Location.X / scaleValue + "\n" + pressedGridButton.Location.Y / scaleValue;
            //Button lifeButton = new Button();
            lifeButtons[pressedGridButton.Location.X / scaleValue, pressedGridButton.Location.Y / scaleValue] = new Button();
            //this.Controls.Add(lifeButton);
            this.Controls.Add(lifeButtons[pressedGridButton.Location.X / scaleValue, pressedGridButton.Location.Y / scaleValue]);
            //lifeButton.Size = pressedGridButton.Size;
            lifeButtons[pressedGridButton.Location.X / scaleValue, pressedGridButton.Location.Y / scaleValue].Size = pressedGridButton.Size;
            //lifeButton.Location = pressedGridButton.Location;
            lifeButtons[pressedGridButton.Location.X / scaleValue, pressedGridButton.Location.Y / scaleValue].Location = pressedGridButton.Location;
            //lifeButton.BringToFront();
            lifeButtons[pressedGridButton.Location.X / scaleValue, pressedGridButton.Location.Y / scaleValue].BringToFront();
            //lifeButton.BackColor = Color.White;
            lifeButtons[pressedGridButton.Location.X / scaleValue, pressedGridButton.Location.Y / scaleValue].BackColor = Color.White;
            //lifeButton.Click += new EventHandler(lifeButton_Click);
            lifeButtons[pressedGridButton.Location.X / scaleValue, pressedGridButton.Location.Y / scaleValue].Click += new EventHandler(lifeButton_Click);

            for (int x = 1; x <= 10; x++)
            {
                for (int y = 1; y <= 10; y++)
                {
                    if (x * scaleValue == lifeButtons[pressedGridButton.Location.X / scaleValue, pressedGridButton.Location.Y / scaleValue].Location.X && y * scaleValue == lifeButtons[pressedGridButton.Location.X / scaleValue, pressedGridButton.Location.Y / scaleValue].Location.Y)
                    {
                        lifeLocations[x, y] = 1;
                    }
                }
            }
        }

        public void lifeButton_Click (object sender, EventArgs e)
        {
            pressedLifeButton = (Button)sender;
            for (int x = 1; x <= 10; x++)
            {
                for (int y = 1; y <= 10; y++)
                {
                    if (x * scaleValue == pressedLifeButton.Location.X && y * scaleValue == pressedLifeButton.Location.Y)
                    {
                        lifeLocations[x, y] = 0;
                    }
                }
            }
            pressedLifeButton.Visible = false;

        }

        private void runButton_Click(object sender, EventArgs e)
        {
            for (int x = 1; x <= 10; x++)
            {
                for (int y = 1; y <= 10; y++)
                {
                    if (lifeLocations[x, y] == 1)
                    {
                        int localLife = 0;
                        if (lifeLocations[x - 1, y] == 1)
                        {
                            localLife++;
                        }
                        if (lifeLocations[x + 1, y] == 1)
                        {
                            localLife++;
                        }
                        if (lifeLocations[x, y + 1] == 1)
                        {
                            localLife++;
                        }
                        if (lifeLocations[x, y - 1] == 1)
                        {
                            localLife++;
                        }
                        if (lifeLocations[x + 1, y + 1] == 1)
                        {
                            localLife++;
                        }
                        if (lifeLocations[x - 1, y - 1] == 1)
                        {
                            localLife++;
                        }
                        if (lifeLocations[x - 1, y + 1] == 1)
                        {
                            localLife++;
                        }
                        if (lifeLocations[x + 1, y - 1] == 1)
                        {
                            localLife++;
                        }

                        if (localLife < 2 || localLife > 3)
                        {
                            lifeLocations[x, y] = 0;
                            lifeButtons[x, y].Visible = false;
                        }
                    }
                    else if (lifeLocations[x, y] == 0)
                    {
                        int localLife = 0;
                        if (lifeLocations[x - 1, y] == 1)
                        {
                            localLife++;
                        }
                        if (lifeLocations[x + 1, y] == 1)
                        {
                            localLife++;
                        }
                        if (lifeLocations[x, y + 1] == 1)
                        {
                            localLife++;
                        }
                        if (lifeLocations[x, y - 1] == 1)
                        {
                            localLife++;
                        }
                        if (lifeLocations[x + 1, y + 1] == 1)
                        {
                            localLife++;
                        }
                        if (lifeLocations[x - 1, y - 1] == 1)
                        {
                            localLife++;
                        }
                        if (lifeLocations[x - 1, y + 1] == 1)
                        {
                            localLife++;
                        }
                        if (lifeLocations[x + 1, y - 1] == 1)
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
                            lifeButtons[x, y].BackColor = Color.White;
                            lifeButtons[x, y].Location = new Point(x * scaleValue, y * scaleValue);

                            lifeButtons[x, y].BringToFront();
                        }
                    }
                }
            }
        }
    }
}
