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

            matrix = new Matrix(3, 3, 2);

            matrix.setElementValue(2, 2, 10);

            this.mTextResult.Text = matrix.ToString();
        }

        //===============================================================================//
        // Methods
        //===============================================================================//

        private void MainForm_Load(object sender, EventArgs e)
        {
            
        }

    }
}
