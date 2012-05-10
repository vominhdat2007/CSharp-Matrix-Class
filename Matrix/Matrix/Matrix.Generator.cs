using System;
using System.Collections.Generic;
using System.Text;

public partial class Matrix
{

    //===============================================================================//
    // Generators
    //===============================================================================//

    /// <summary>
    /// Generate an identity matrix with determined size.
    /// </summary>
    /// <param name="pSize">The size (number of columns and rows) of the result matrix.</param>
    /// <returns>pSize x pSize identity matrix.</returns>
    public static Matrix createIdentityMatrix(int pSize)
    {
        // Initialize
        Matrix result = new Matrix(pSize, pSize);

        // Set all elements on the main diagonal to 1
        for (int diagonal = 0; diagonal < pSize; diagonal++)
        {
            result.mData[diagonal][diagonal] = 1;
        }

        // Return result;
        return result;
    }

    /// <summary>
    /// Create a zero matrix with determined size.
    /// </summary>
    /// <param name="pNumberOfRows">Number of the rows of the matrix.</param>
    /// <param name="pNumberOfColumns">Number of the columns of the matrix.</param>
    /// <returns>The zero matrix with given size.</returns>
    public static Matrix createZeroMatrix(int pNumberOfRows, int pNumberOfColumns)
    {
        // Actually it is the constructor
        return new Matrix(pNumberOfRows, pNumberOfColumns);
    }

}

