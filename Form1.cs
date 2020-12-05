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
        Button[] lifeButtons = new Button[112];
        int scaleValue = 60;
        int[] lifeLocations = new int[112];
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
            lifeButtons[pressedGridButton.Location.Y / scaleValue * 10 + pressedGridButton.Location.X / scaleValue - 1] = new Button();
            //this.Controls.Add(lifeButton);
            this.Controls.Add(lifeButtons[pressedGridButton.Location.Y / scaleValue * 10 + pressedGridButton.Location.X / scaleValue - 1]);
            //lifeButton.Size = pressedGridButton.Size;
            lifeButtons[pressedGridButton.Location.Y / scaleValue * 10 + pressedGridButton.Location.X / scaleValue - 1].Size = pressedGridButton.Size;
            //lifeButton.Location = pressedGridButton.Location;
            lifeButtons[pressedGridButton.Location.Y / scaleValue * 10 + pressedGridButton.Location.X / scaleValue - 1].Location = pressedGridButton.Location;
            //lifeButton.BringToFront();
            lifeButtons[pressedGridButton.Location.Y / scaleValue * 10 + pressedGridButton.Location.X / scaleValue - 1].BringToFront();
            //lifeButton.BackColor = Color.White;
            lifeButtons[pressedGridButton.Location.Y / scaleValue * 10 + pressedGridButton.Location.X / scaleValue - 1].BackColor = Color.White;
            //lifeButton.Click += new EventHandler(lifeButton_Click);
            lifeButtons[pressedGridButton.Location.Y / scaleValue * 10 + pressedGridButton.Location.X / scaleValue - 1].Click += new EventHandler(lifeButton_Click);

            for (int x = 1; x <= 10; x++)
            {
                for (int y = 1; y <= 10; y++)
                {
                    if (x * scaleValue == lifeButtons[pressedGridButton.Location.Y / scaleValue * 10 + pressedGridButton.Location.X / scaleValue - 1].Location.X && y * scaleValue == lifeButtons[pressedGridButton.Location.Y / scaleValue * 10 + pressedGridButton.Location.X / scaleValue - 1].Location.Y)
                    {
                        lifeLocations[y * 10 + x - 1] = 1;
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
                        lifeLocations[y * 10 + x - 1] = 0;
                    }
                }
            }
            pressedLifeButton.Visible = false;

        }

        private void runButton_Click(object sender, EventArgs e)
        {
            for (int x = 1; x <= 99; x++)
            {
                if (lifeLocations[x] == 1)
                {
                    int localLife = 0;
                    if (lifeLocations[x - 1] == 1)
                    {
                        localLife++;
                    }
                    if (lifeLocations[x + 1] == 1)
                    {
                        localLife++;
                    }
                    if (lifeLocations[x + 10] == 1)
                    {
                        localLife++;
                    }
                    if (lifeLocations[x - 10] == 1)
                    {
                        localLife++;
                    }
                    if (lifeLocations[x + 11] == 1)
                    {
                        localLife++;
                    }
                    if (lifeLocations[x - 11] == 1)
                    {
                        localLife++;
                    }
                    if (lifeLocations[x + 9] == 1)
                    {
                        localLife++;
                    }
                    if (lifeLocations[x - 9] == 1)
                    {
                        localLife++;
                    }

                    if (localLife < 2 || localLife > 3)
                    {
                        lifeLocations[x] = 0;
                        lifeButtons[x].Visible = false;
                    }
                }
                else if (lifeLocations[x] == 0)
                {
                    int localLife = 0;
                    if (lifeLocations[x - 1] == 1)
                    {
                        localLife++;
                    }
                    if (lifeLocations[x + 1] == 1)
                    {
                        localLife++;
                    }
                    if (lifeLocations[x + 10] == 1)
                    {
                        localLife++;
                    }
                    if (lifeLocations[x - 10] == 1)
                    {
                        localLife++;
                    }
                    if (lifeLocations[x + 11] == 1)
                    {
                        localLife++;
                    }
                    if (lifeLocations[x - 11] == 1)
                    {
                        localLife++;
                    }
                    if (lifeLocations[x + 9] == 1)
                    {
                        localLife++;
                    }
                    if (lifeLocations[x - 9] == 1)
                    {
                        localLife++;
                    }

                    if (localLife == 3)
                    {
                        lifeLocations[x] = 1;
                        lifeButtons[x] = new Button();
                        this.Controls.Add(lifeButtons[x]);
                        lifeButtons[x].Visible = true;
                        lifeButtons[x].Size = new Size (scaleValue, scaleValue);
                        lifeButtons[x].Location = new Point(x * scaleValue / 10, x / scaleValue + 1);
                        lifeButtons[x].BringToFront();
                    }
                }
            }
        }
    }
}
