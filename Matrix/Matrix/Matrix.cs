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
    private decimal[][] mData;

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
        // Check parameters
        if (pM <= 0 || pN <= 0)
            throw new ArgumentException("The number of row and column of the matrix must be non-negative integers.");
        
        // Initialize the matrix data
        this.mData = new decimal[pM][];
        for (int row = 0; row < pM; row++)
        {
            this.mData[row] = new decimal[pN];
        }

        // Information
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
                this.mData[row][col] = pInitializeValue;
            }
        }
    }

    /// <summary>
    /// Initializes a new instance of the Matrix with the provided array.
    /// </summary>
    /// <param name="pInitializingValue">The initializing value for the matrix.</param>
    public Matrix(decimal[][] pInitializingValue)
    {
        // Check parameters
        if (pInitializingValue == null)
            throw new ArgumentNullException("The initializing value is null.");
        if (pInitializingValue.Length == 0)
            throw new ArgumentException("The number of rows must be a non-negative integer.");
        int colCount = pInitializingValue[0].Length;
        if (colCount == 0)
            throw new ArgumentException("The number of columns must be a non-negative integer.");
        for (int col = 1; col < pInitializingValue.Length; col++)
        {
            if (pInitializingValue[col].Length != colCount)
                throw new ArgumentException("The initializing array is jagged.");
        }

        // Set data
        this.mData = (decimal[][])pInitializingValue.Clone();
        this.mRowCount = this.mData.Length;
        this.mColCount = this.mData[0].Length;
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
                result.Append(Math.Round(this.mData[row][col], 3));
                if (col < this.mColCount - 1) result.Append("\t\t");
            }
            if (row < this.mRowCount - 1) result.AppendLine();
        }

        return result.ToString();
    }

    /// <summary>
    /// Get a copy of this matrix.
    /// </summary>
    /// <returns>Reference to a copy of this matrix.</returns>
    public Matrix Clone()
    {
        return new Matrix(this);
    }

    //===============================================================================//
    // Basic Checkers
    //===============================================================================//
    
    /// <summary>
    /// Validate if the row index is valid. Throw an exception if it is not.
    /// </summary>
    /// <param name="pColumn"></param>
    protected void validateRow(int pRow)
    {
        if (pRow < 0)
            throw new ArgumentException("The row index must be a non-negative integer.");
        if (pRow >= this.mRowCount)
            throw new ArgumentException("The row index must be smaller than the number of rows.");
    }

    /// <summary>
    /// Validate if the row index is valid. Throw an exception if it is not.
    /// </summary>
    /// <param name="pColumn"></param>
    protected void validateColumn(int pColumn)
    {
        if (pColumn < 0)
            throw new ArgumentException("The column index must be a non-negative integer.");
        if (pColumn >= this.mColCount)
            throw new ArgumentException("The column index must be smaller than the number of numbers.");
    }

    /// <summary>
    /// Validate if this matrix is a square matrix. Throw an exception if it is not.
    /// </summary>
    protected void validateSquareMatrix()
    {
        if (!this.isSquareMatrix())
            throw new InvalidOperationException("This matrix is not a square matrix.");
    }

    /// <summary>
    /// Validate if this matrix and the other matrix have the same sizes.
    /// Throw an exception if they are not.
    /// </summary>
    /// <param name="pOtherMatrix">The matrix to be performed validation.</param>
    protected void validateSameSizeMatrix(Matrix pOtherMatrix)
    {
        if (this.mRowCount != pOtherMatrix.mRowCount || this.mColCount != pOtherMatrix.mColCount)
            throw new InvalidOperationException("The two matrices don't have the same sizes.");
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
        // Validate
        this.validateRow(pRow);
        this.validateColumn(pColumn);

        // Return
        return this.mData[pRow][pColumn];
    }

    /// <summary>
    /// Set the value of an element (entry).
    /// </summary>
    /// <param name="pRow">The row of the element.</param>
    /// <param name="pColumn">The column of the element.</param>
    /// <param name="pValue">The value needed to be set.</param>
    public void setElementValue(int pRow, int pColumn, decimal pValue)
    {
        // Validate
        this.validateRow(pRow);
        this.validateColumn(pColumn);

        // Set value
        this.mData[pRow][pColumn] = pValue;
    }

    /// <summary>
    /// Get a row of this matrix.
    /// </summary>
    /// <param name="pRow">The index of the row.</param>
    /// <returns>The decimal array contains the value of the row.</returns>
    public decimal[] getRow(int pRow)
    {
        // Validate
        this.validateRow(pRow);

        // Return
        return this.mData[pRow];
    }

    /// <summary>
    /// Get a column of this matrix.
    /// </summary>
    /// <param name="pColumn">The index of the column.</param>
    /// <returns>The decimal array contains the value of the column.</returns>
    public decimal[] getColumn(int pColumn)
    {
        // Validate
        this.validateColumn(pColumn);

        // Initialize
        decimal[] result = new decimal[this.mRowCount];

        // Set value
        for (int row = 0; row < this.mRowCount; row++)
        {
            result[row] = this.mData[row][pColumn];
        }

        // Return
        return result;
    }

}
