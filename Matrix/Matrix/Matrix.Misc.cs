using System;
using System.Collections.Generic;
using System.Text;

public partial class Matrix
{

    //===============================================================================//
    // Constants
    //===============================================================================//
    
    private const int ROUND_DECIMAL = 15;

    //===============================================================================//
    // Comparison
    //===============================================================================//
    
    private decimal round(decimal pNumber)
    {
        return Math.Round(pNumber, ROUND_DECIMAL);
    }

    //===============================================================================//
    // Mathematic Operators
    //===============================================================================//

    private decimal dotProduct(decimal[] pVector1, decimal[] pVector2)
    {
        // Validate size
        if (pVector1.Length != pVector2.Length)
            throw new ArgumentException("The length of two vector to perform dot production must be the same.");

        // Initialize
        decimal result = 0;

        // Calculate each element
        for (int element = 0; element < pVector1.Length; element++)
        {
            result += pVector1[element] * pVector2[element];
        }

        // Return result
        return result;
    }

    //===============================================================================//
    // Getters
    //===============================================================================//

    /// <summary>
    /// Return the index of the first non-zero value of the given row.
    /// </summary>
    /// <param name="pRow">The row to be sought.</param>
    /// <returns>The index of the first element (column) of the non-zero element. Return -1 if all elements in the row is zero.</returns>
    public int getFirstNonZeroElementInRow(int pRow)
    {
        // Validate
        this.validateRow(pRow);

        // Initialize
        int result = 0;

        // Find the element
        while (result < this.mColCount && this.mData[pRow][result] == 0)
            result++;

        // Return result
        return result < this.mColCount ? result : -1;
    }

    /// <summary>
    /// Return the index of the first non-zero value of the given row from a given position.
    /// </summary>
    /// <param name="pRow">The row to be sought.</param>
    /// <param name="pStartIndex">The start index to find the non-zero element</param>
    /// <returns>The index of the first element (column) of the non-zero element. Return -1 if all elements in the row is zero.</returns>
    public int getFirstNonZeroElementInRow(int pRow, int pStartIndex)
    {
        // Validate
        this.validateRow(pRow);

        // Initialize
        int result = pStartIndex;

        // Find the element
        while (result < this.mColCount && this.mData[pRow][result] == 0)
            result++;

        // Return result
        return result < this.mColCount ? result : -1;
    }

    /// <summary>
    /// Return the index of the first non-zero value of the given column.
    /// </summary>
    /// <param name="pColumn">The column to be sought.</param>
    /// <returns>The index of the first element (row) of the non-zero element. Return -1 if all elements in the column is zero.</returns>
    public int getFirstNonZeroElementInColumn(int pColumn)
    {
        // Validate
        this.validateColumn(pColumn);

        // Initialize
        int result = 0;

        // Find the element
        while (result < this.mRowCount && this.mData[result][pColumn] == 0)
            result++;

        // Return result
        return result < this.mRowCount ? result : -1;
    }

    /// <summary>
    /// Return the index of the first non-zero value of the given column from a given position.
    /// </summary>
    /// <param name="pColumn">The column to be sought.</param>
    /// <param name="pStartIndex">The start index to find the non-zero element.</param>
    /// <returns>The index of the first element (row) of the non-zero element. Return -1 if all elements in the column is zero.</returns>
    public int getFirstNonZeroElementInColumn(int pColumn, int pStartIndex)
    {
        // Validate
        this.validateColumn(pColumn);

        // Initialize
        int result = pStartIndex;

        // Find the element
        while (result < this.mRowCount && this.mData[result][pColumn] == 0)
            result++;

        // Return result
        return result < this.mRowCount ? result : -1;
    }

}

