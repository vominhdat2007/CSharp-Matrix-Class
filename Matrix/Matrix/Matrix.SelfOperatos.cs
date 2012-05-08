using System;
using System.Collections.Generic;
using System.Text;

public partial class Matrix
{

    //===============================================================================//
    // Basic Operators
    //===============================================================================//

    /// <summary>
    /// Add this matrix with another matrix. This instance will hold the result.
    /// </summary>
    /// <param name="pSecondMatrix">The matrix to perform addition.</param>
    public void addSelf(Matrix pSecondMatrix)
    {
        // Check if the second matrix is valid for addition
        if (this.mColCount != pSecondMatrix.mColCount || this.mRowCount != pSecondMatrix.mRowCount)
            throw new ArgumentException("The second matrix doesn't have the same number of rows and columns.");
        
        // Add every element of this matrix with the other matrix
        for (int row = 0; row < this.mRowCount; row++)
        {
            for (int col = 0; col < this.mColCount; col++)
            {
                this.mData[row][col] += pSecondMatrix.mData[row][col];
            }
        }
    }

    /// <summary>
    /// Scalar multiply this matrix with another matrix. This instance will hold the result.
    /// </summary>
    /// <param name="pSecondMatrix">The matrix to perform addition.</param>
    public void scalarMultiplySelf(decimal pConstant)
    {
        // Mutiply every element with the constant.
        for (int row = 0; row < this.mRowCount; row++)
        {
            for (int col = 0; col < this.mColCount; col++)
            {
                this.mData[row][col] *= pConstant;
            }
        }
    }

    /// <summary>
    /// Transpose this matrix.
    /// </summary>
    public void transposeSelf()
    {
        // The new data for the matrix
        decimal[][] newData = new decimal[this.mColCount][];
        for (int col = 0; col < this.mColCount; col++)
        {
            newData[col] = new decimal[this.mRowCount];
        }

        // Switch column and row
        for (int oldRow = 0; oldRow < this.mRowCount; oldRow++)
        {
            for (int oldCol = 0; oldCol < this.mColCount; oldCol++)
            {
                newData[oldCol][oldRow] = this.mData[oldRow][oldCol];
            }
        }

        // Assign new data
        this.mData = newData;
        this.mRowCount = newData.Length;
        this.mColCount = newData[0].Length;

    }



}
