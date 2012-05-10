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

        private Matrix matrix1, matrix2;

        //===============================================================================//
        // Constructor
        //===============================================================================//

        public MainForm()
        {
            InitializeComponent();

            this.matrix1 = new Matrix(new decimal[][] {


                new decimal[] {1, 2, 3, 4},
                new decimal[] {5, 6, 7, 8},
                new decimal[] {8, 10, 11, 12},

            });

            this.matrix2 = new Matrix(new decimal[][] {


                new decimal[] {3, 5, 6},
                new decimal[] {7, 8, 9},
                //new decimal[] {0, 0, 0},

            });

            Matrix result = matrix1.getRowEchelonFormMatrix();
            Matrix result2 = matrix1.getReducedRowEchelonFormatMatrix();
            
            this.mTextResult.Text = 
                result.ToString() + "\n\n" +
                result2.ToString();
        }

        //===============================================================================//
        // Methods
        //===============================================================================//

        private void MainForm_Load(object sender, EventArgs e)
        {
            
        }

    }
}
