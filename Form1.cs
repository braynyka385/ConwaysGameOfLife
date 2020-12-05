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
        int scaleValue = 60;
        int[] lifeLocations = new int[200];
        public Form1()
        {
            InitializeComponent();
        }

        public void startButton_Click(object sender, EventArgs e)
        {
            startButton.Visible = false;

            for (int x = 3; x <= 11; x++)
            {
                for (int y = 3; y <= 11; y++)
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
            Button lifeButton = new Button();
            this.Controls.Add(lifeButton);
            lifeButton.Size = pressedGridButton.Size;
            lifeButton.Location = pressedGridButton.Location;
            lifeButton.BringToFront();
            lifeButton.BackColor = Color.White;
            lifeButton.Click += new EventHandler(lifeButton_Click);

            for (int x = 1; x <= 10; x++)
            {
                for (int y = 1; y <= 10; y++)
                {
                    if (x * scaleValue == lifeButton.Location.X && y * scaleValue == lifeButton.Location.Y)
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
                    }
                }
            }
        }
    }
}
