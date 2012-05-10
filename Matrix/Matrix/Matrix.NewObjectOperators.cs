using System;
using System.Collections.Generic;
using System.Text;

public partial class Matrix
{

    //===============================================================================//
    // New-Self Operators
    //===============================================================================//


    /// <summary>
    /// Return a matrix resulted by an addition of this matrix with another matrix.
    /// </summary>
    /// <param name="pSecondMatrix">The matrix to perform addition.</param>
    public Matrix add(Matrix pSecondMatrix)
    {
        // Check if the second matrix is valid for addition
        this.validateSameSizeMatrix(pSecondMatrix);

        // Initialize result
        Matrix result = this.Clone();
        
        // Perform addtion
        result.addSelf(pSecondMatrix);

        // Return result
        return result;
    }

    /// <summary>
    /// Return a matrix resulted by a subtraction of this matrix with another matrix.
    /// </summary>
    /// <param name="pSecondMatrix">The matrix to perform subtraction.</param>
    public Matrix subtract(Matrix pSecondMatrix)
    {
        // Check if the second matrix is valid for subtraction
        this.validateSameSizeMatrix(pSecondMatrix);

        // Initialize result
        Matrix result = this.Clone();

        // Perform subtraction
        result.subtractSelf(pSecondMatrix);

        // Return result
        return result;
    }

    /// <summary>
    /// Return a matrix resulted by an scalar multiplication of this matrix with a constant.
    /// </summary>
    /// <param name="pConstant">The constant to perform scalar multiplication.</param>
    public Matrix scalarMultiply(decimal pConstant)
    {
        // Initialize result
        Matrix result = this.Clone();

        // Perform scalar multiplication
        result.scalarMultiplySelf(pConstant);

        // Return result
        return result;
    }

    /// <summary>
    /// Return the transposed matrix of this matrix.
    /// </summary>
    public Matrix transpose()
    {
        // Initialize result
        Matrix result = this.Clone();

        // Perfome transposation
        result.transposeSelf();

        // Return result
        return result;
    }


    //===============================================================================//
    // Completely New Operators
    //===============================================================================//

    /// <summary>
    /// Return the matrix resulted by a multiplication of this matrix with another matrix.
    /// </summary>
    /// <param name="pSecondMatrix">The matrix to multiply</param>
    public Matrix multiply(Matrix pSecondMatrix)
    {
        // Validate size
        if (this.mColCount != pSecondMatrix.mRowCount)
            throw new ArgumentException("The number of rows of the second matrix must be equal to this matrix's number of columns.");

        // Initialize result
        Matrix result = new Matrix(this.mRowCount, pSecondMatrix.mColCount);

        // Multiply each row of this matrix with columns of another matrix
        for (int row = 0; row < this.mRowCount; row++)
        {
            for (int col = 0; col < pSecondMatrix.mColCount; col++)
            {
                result.mData[row][col] = this.dotProduct(this.getRow(row), pSecondMatrix.getColumn(col));
            }
        }

        // Return result
        return result;
    }

}
