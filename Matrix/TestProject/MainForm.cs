using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace TestProject
{
    public partial class MainForm : Form
    {

        //===============================================================================//
        // Variables
        //===============================================================================//

        private Matrix matrix;

        //===============================================================================//
        // Constructor
        //===============================================================================//

        public MainForm()
        {
            InitializeComponent();

            matrix = new Matrix(new decimal[][] {

                //new decimal[] {1, 2, 3},
                //new decimal[] {1, 2, 3},
                //new decimal[] {1, 2, 3},

                //new decimal[] {1, 2, 3},
                //new decimal[] {4, 5, 6},
                //new decimal[] {7, 8, 9},

                //new decimal[] {1, 0, 10, 5},
                //new decimal[] {3, 1, -4, -1},
                //new decimal[] {4, 1, 6, 1},

                //new decimal[] {1, -2, -1, 3, 1},
                //new decimal[] {2, -4, 1, 0, 5},
                //new decimal[] {1, -2, 2, -3, 4},

                new decimal[] {1, 1, -1, 4},
                new decimal[] {2, 1, 3, 0},
                new decimal[] {0, 1, -5, 8},

            });

            Matrix rowechelon = matrix.getRowEchelonFormMatrix();

            this.mTextResult.Text = rowechelon.ToString();
        }

        //===============================================================================//
        // Methods
        //===============================================================================//

        private void MainForm_Load(object sender, EventArgs e)
        {
            
        }

    }
}
