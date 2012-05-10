using System;
using System.Collections.Generic;
using System.Text;

public partial class Matrix
{

    //===============================================================================//
    // Other Methods
    //===============================================================================//

    /// <summary>
    /// Get the rank of this matrix.
    /// </summary>
    /// <returns>The number of leading of this matrix's row-echelon form.</returns>
    public int getRank()
    {
        // Get the row-echelon matrix
        Matrix rowEchelonForm = this.getRowEchelonFormMatrix();

        // Initialize variables
        int result = 0;
        int firstNonZeroElement = 0;

        // Count number of leading 1
        for (int row = 0; row < rowEchelonForm.mRowCount; row++)
        {
            firstNonZeroElement = rowEchelonForm.getFirstNonZeroElementInRow(row);
            if (firstNonZeroElement > -1)
                result++;
            else
                return result;
        }

        // Return result
        return result;
    }

}

