using System;
using System.Collections.Generic;
using System.Text;

/*
 * @author Vo Minh Dat
 * @version 1.0
 * @since 2012-May-08
 */ 

/// <summary>
/// A instance of a matrix and perform operators on matrices.
/// </summary>
public partial class Matrix
{

    //===============================================================================//
    // Variables
    //===============================================================================//

    // Data
    private int mRowCount, mColCount;
    private decimal[,] mData;

    //===============================================================================//
    // Constructors
    //===============================================================================//

    /// <summary>
    /// Initializes a new instance of the Matrix with the provided rows and columns with all value are 0.
    /// </summary>
    /// <param name="pM">Number of row of the matrix.</param>
    /// <param name="pN">Number of column of the matrix.</param>
    public Matrix(int pM, int pN)
    {
        // Initialize the matrix data
        this.mData = new decimal[pM, pN];
        this.mRowCount = pM;
        this.mColCount = pN;
    }

    /// <summary>
    /// Initializes a new instance of the Matrix with the provided rows and columns, all elements have the given value.
    /// </summary>
    /// <param name="pM">Number of row of the matrix.</param>
    /// <param name="pN">Number of column of the matrix.</param>
    /// <param name="pInitializeValue">The value for each element of initializing matrix.</param>
    public Matrix(int pM, int pN, decimal pInitializeValue)
        : this(pM, pN)
    {
        for (int row = 0; row < pM; row++)
        {
            for (int col = 0; col < pN; col++)
            {
                this.mData[row, col] = pInitializeValue;
            }
        }
    }

    /// <summary>
    /// Initializes a new instance of the Matrix with the provided array.
    /// </summary>
    /// <param name="pInitializeValue">The initialize value for the matrix.</param>
    public Matrix(decimal[,] pInitializeValue)
    {
        this.mData = (decimal[,])pInitializeValue.Clone();
        this.mRowCount = pInitializeValue.GetUpperBound(0);
        this.mColCount = pInitializeValue.GetUpperBound(1);
    }

    /// <summary>
    /// Initializes a new instance of the Matrix with the data copy exactly from the given Matrix.
    /// </summary>
    /// <param name="pSourceMatrix"></param>
    public Matrix(Matrix pSourceMatrix)
        : this(pSourceMatrix.mData)
    { }

    //===============================================================================//
    // Shadows Methods
    //===============================================================================//

    /// <summary>
    /// Convert the value of the matrix into a String.
    /// </summary>
    /// <returns>The representation of the matrix</returns>
    public override string ToString()
    {
        StringBuilder result = new StringBuilder();

        for (int row = 0; row < this.mRowCount; row++)
        {
            for (int col = 0; col < this.mColCount; col++)
            {
                result.Append(this.mData[row, col]);
                if (col < this.mColCount - 1) result.Append(" ");
            }
            if (row < this.mRowCount - 1) result.AppendLine();
        }

        return result.ToString();
    }

    //===============================================================================//
    // Setters & Getters
    //===============================================================================//

    /// <summary>
    /// Get the number of the rows of the matrix.
    /// </summary>
    /// <returns>the number of the rows of the matrix.</returns>
    public int getRowCount()
    {
        return this.mRowCount;
    }

    /// <summary>
    /// Get the number of the columns of the matrix.
    /// </summary>
    /// <returns>The number of the columns of the matrix.</returns>
    public int getColumnCount()
    {
        return this.mColCount;
    }

    /// <summary>
    /// Get the value of an element (entry).
    /// </summary>
    /// <param name="pRow">The row of the element.</param>
    /// <param name="pColumn">The column of the element.</param>
    /// <returns>The value of the element at the given column and row in the matrix.</returns>
    public decimal getElementValue(int pRow, int pColumn)
    {
        if (pRow >= this.mRowCount || pColumn >= this.mColCount)
            throw new IndexOutOfRangeException("The row or column index is not smaller the matrix bound.");
        return this.mData[pRow, pColumn];
    }

    /// <summary>
    /// Set the value of an element (entry).
    /// </summary>
    /// <param name="pRow">The row of the element.</param>
    /// <param name="pColumn">The column of the element.</param>
    /// <param name="pValue">The value needed to be set.</param>
    public void setElementValue(int pRow, int pColumn, decimal pValue)
    {
        if (pRow >= this.mRowCount || pColumn >= this.mColCount)
            throw new IndexOutOfRangeException("The row or column index is not smaller the matrix bound.");
        this.mData[pRow, pColumn] = pValue;
    }

}
