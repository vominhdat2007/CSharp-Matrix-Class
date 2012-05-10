using System;
using System.Collections.Generic;
using System.Text;

public partial class Matrix
{

    //===============================================================================//
    // Basic Checkers
    //===============================================================================//

    /// <summary>
    /// Check if this matrix is a square matrix.
    /// </summary>
    /// <returns>True if this matrix's number of rows and columns are the same. False if otherwise.</returns>
    public bool isSquareMatrix()
    {
        return this.mRowCount == this.mColCount;
    }
    
    /// <summary>
    /// Check if this matrix is a zero matrix.
    /// </summary>
    /// <returns>True if all elements of this matrix are 0. False if otherwise.</returns>
    public bool isZeroMatrix()
    {
        // Check every element for non-zero element
        for (int row = 0; row < this.mRowCount; row++)
        {
            for (int col = 0; col < this.mColCount; col++)
            {
                if (this.mData[row][col] != 0) return false;
            }
        }

        // If no non-zero element found, this is a zero matrix
        return true;
    }

    /// <summary>
    /// Check if the input matrix is the negative matrix of this matrix.
    /// No exception is thrown if the size of two matrices are different.
    /// </summary>
    /// <param name="pMatrix">The matrix to be checked.</param>
    /// <returns>True if pMatrix is a negative matrix of this matrix.</returns>
    public bool isNegativeMatrix(Matrix pMatrix)
    {
        // If not the same size: Can't be the negative matrix
        if (this.mRowCount != pMatrix.mRowCount || this.mColCount != pMatrix.mColCount)
            return false;

        // Check every element of the other matrix
        for (int row = 0; row < this.mRowCount; row++)
        {
            for (int col = 0; col < this.mColCount; col++)
            {
                if (this.mData[row][col] != -pMatrix.mData[row][col])
                    return false;
            }
        }

        // If the test is passed, it's the negative matrix
        return true;
    }

    /// <summary>
    /// Check if this matrix is an identity matrix.
    /// No exception is thrown if this matrix is not a square matrix.
    /// </summary>
    /// <returns></returns>
    public bool isIdentityMatrix()
    {
        // If this matrix is not a square matrix: can't be identity matrix
        if (!this.isSquareMatrix()) 
            return false;

        // Check every elements
        for (int row = 0; row < this.mRowCount; row++)
        {
            for (int col = 0; col < this.mColCount; col++)
            {
                if
                    ((row == col && this.mData[row][col] != 1) ||
                    (row != col && this.mData[row][col] != 0))
                    return false;
            }
        }

        // If the test is passed, this is an identity matrix
        return true;
    }

    /// <summary>
    /// Check if this matrix and the other matrix is equal.
    /// </summary>
    /// <param name="pMatrix">The matrix to be checked.</param>
    /// <returns>True if two matrices have the same size, and all their respective elements are equals.</returns>
    /// <remarks>This function is eviqualent with isEqual.</remarks>
    public bool equals(Matrix pMatrix) 
    {
        return this.isEqual(pMatrix);
    }

    /// <summary>
    /// Check if this matrix and the other matrix is equal.
    /// </summary>
    /// <param name="pMatrix">The matrix to be checked.</param>
    /// <returns>True if two matrices have the same size, and all their respective elements are equals.</returns>
    public bool isEqual(Matrix pMatrix)
    {
        // Check size first
        if (this.mRowCount != pMatrix.mRowCount || this.mColCount != pMatrix.mColCount)
            return false;

        // Check every element
        for (int row = 0; row < this.mRowCount; row++)
        {
            for (int col = 0; col < this.mColCount; col++)
            {
                if (this.mData[row][col] != this.mData[row][col])
                    return false;
            }
        }

        // If the test is passed, these matrices are equal.
        return true;
    }

    /// <summary>
    /// Check if this matrix is symmetric.
    /// This operator doesn't generate any other matrix in the memory.
    /// </summary>
    /// <returns>True if the tranpose of this matrix is equal with this matrix. False if otherwise.</returns>
    public bool isSymmetric()
    {
        // If this is not a square matrix: can't be symmetric
        if (!this.isSquareMatrix())
            return false;

        // Check each element by reverse the row
        for (int row = 0; row < this.mRowCount; row++)
        {
            for (int col = 0; col < this.mColCount; col++)
            {
                if (this.mData[row][col] != this.mData[col][row])
                    return false;
            }
        }

        // If the test is passed, this is a symmetric matrix
        return true;
    }

    //===============================================================================//
    // Basic Generators
    //===============================================================================//

    /// <summary>
    /// Get the negative matrix of this matrix.
    /// </summary>
    /// <returns>The negative matrix of this matrix.</returns>
    public Matrix getNegativeMatrix()
    {
        // Initialize
        Matrix result = new Matrix(this.mRowCount, this.mColCount);

        // Set value for the result matrix
        for (int row = 0; row < this.mRowCount; row++)
        {
            for (int col = 0; col < this.mColCount; col++)
            {
                result.mData[row][col] = -this.mData[row][col];
            }
        }

        // Return result
        return result;
    }

    //===============================================================================//
    // Basic Functions
    //===============================================================================//

    /// <summary>
    /// Get the determinant of this (must be square) matrix.
    /// </summary>
    /// <returns>The determinant of this matrix.</returns>
    public decimal getDeterminant()
    {
        // Validate square matrix
        this.validateSquareMatrix();

        // Initialize result
        decimal result = 0;

        // Calculate

        // Return result
        return result;
    }

}

