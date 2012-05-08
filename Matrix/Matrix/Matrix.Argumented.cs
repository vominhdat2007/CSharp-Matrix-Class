using System;
using System.Collections.Generic;
using System.Text;

public partial class Matrix
{

    //===============================================================================//
    // Elementary Operators
    //===============================================================================//

    /// <summary>
    /// Switch value of 2 rows (interchange) of this matrix.
    /// </summary>
    /// <param name="pRow1">The index of the first row to be switched.</param>
    /// <param name="pRow2">The index of the second row to be switched.</param>
    public void argumentedInterchange(int pRow1, int pRow2)
    {
        // Validate
        this.validateRow(pRow1);
        this.validateRow(pRow2);

        // If two index is the same, no need to switch
        if (pRow1 == pRow2) return;

        // Switch
        decimal[] temp = this.mData[pRow1];
        this.mData[pRow1] = this.mData[pRow2];
        this.mData[pRow2] = temp;
    }

    /// <summary>
    /// Multiply a matrix row by a non-zero number.
    /// </summary>
    /// <param name="pRow">The row index to by multiplied.</param>
    /// <param name="pConstant">The number to multiply the row.</param>
    public void argumentedMultiply(int pRow, decimal pConstant)
    {
        // Validate
        this.validateRow(pRow);
        
        // If constant is 1: no need to operate
        if (pConstant == 1) return;

        // Multiply
        for (int col = 0; col < this.mColCount; col++)
        {
            this.mData[pRow][col] = this.round(this.mData[pRow][col] * pConstant);
        }
    }

    /// <summary>
    /// Add the source row with value of another row. The result is stored in the soure row.
    /// </summary>
    /// <param name="pSourceRow">The index of the source row.</param>
    /// <param name="pAdditionRow">The index of the value row to add.</param>
    public void argumentedAddRow(int pSourceRow, int pAdditionRow)
    {
        // Validate
        this.validateRow(pSourceRow);
        this.validateRow(pAdditionRow);

        // Add
        for (int col = 0; col < this.mColCount; col++)
        {
            this.mData[pSourceRow][col] = this.round(this.mData[pSourceRow][col] + this.mData[pAdditionRow][col]);
        }
    }

    /// <summary>
    /// Add the source row with value of another row multiply by a constant. The result is stored in the soure row.
    /// </summary>
    /// <param name="pSourceRow">The index of the source row.</param>
    /// <param name="pAdditionRow">The index of the value row to add.</param>
    /// <param name="pConstant">The constant that multiply with the addition row. (The result is just temporary)</param>
    public void argumentedAddRow(int pSourceRow, int pAdditionRow, decimal pConstant)
    {
        // Validate
        this.validateRow(pSourceRow);
        this.validateRow(pAdditionRow);
        
        // Add
        for (int col = 0; col < this.mColCount; col++)
        {
            this.mData[pSourceRow][col] = this.round(this.mData[pSourceRow][col] + this.mData[pAdditionRow][col] * pConstant);
        }
    }

    //===============================================================================//
    // Special Forms Checkers
    //===============================================================================//

    /// <summary>
    /// Check if this matrix is in row-echelon form.
    /// </summary>
    /// <returns>Return True if this matrix is in row-echelon form, False otherwise.</returns>
    public bool isInRowEchelonFormMatrix()
    {
        // Initialize
        int lastLeadingOne = -1;
        int firstNonZeroElement = 0;

        // Check each row
        for (int row = 0; row < this.mRowCount; row++)
        {
            // Get the first non-zero element
            firstNonZeroElement = this.getFirstNonZeroElementInRow(row);


            if (firstNonZeroElement == -1)
            { // If the row is all zeros: All others must be zero.
                lastLeadingOne = Int32.MaxValue;
            }
            else
            { // If not
                // If not a leading one: can't be in row-echolon form
                if (this.mData[row][firstNonZeroElement] != 1) return false;

                // If the leading one is not right of the previous leading one: can't be in row-echolon form
                if (firstNonZeroElement <= lastLeadingOne) return false;

                // If above conditions is not met, update the new condition
                lastLeadingOne = firstNonZeroElement;
            }
        }

        // Is Row-Echelon Form Matrix
        return true;
    }

    /// <summary>
    /// Check if this matrix is in reduced row-echelon form.
    /// </summary>
    /// <returns>Return True if this matrix is in reduced row-echelon form, False otherwise.</returns>
    public bool isInReducedRowEchelonFormMatrix()
    {
        // If the matrix is not row-echelon form: can't be reduced row-echelon form
        if (!this.isInRowEchelonFormMatrix()) return false;

        // Initialize
        int leadingOneIndex = 0;

        // Check every leading one
        for (int row = 0; row < this.mRowCount; row++)
        {
            // Get the leading one (also the first non-zero)
            leadingOneIndex = this.getFirstNonZeroElementInRow(row);

            // The no leading one found: progress completed
            if (leadingOneIndex == -1) return true;

            // Check the entire column (just need to check the upper part)
            for (int checkRow = row - 1; checkRow >= 0; checkRow--)
            {
                // If there is a non-zero value: not in reduced row-echelon form
                if (this.mData[checkRow][leadingOneIndex] != 0) return false;
            }

        }

        // Is Reduced Row-Echelon Form Matrix
        return true;
    }

    //===============================================================================//
    // Special Forms Generators
    //===============================================================================//

    /// <summary>
    /// Get the row-echelon form of this matrix.
    /// </summary>
    /// <returns>The row-echolon matrix generated from this matrix.</returns>
    public Matrix getRowEchelonFormMatrix()
    {
        // Initialize result
        Matrix result = this.Clone();

        // Initialize variables
        int firstNonZeroElementIndex = 0;
        int currentColumn = 0;
        int nextTopRow = 0;

        while (currentColumn < result.mColCount)
        { // Using Gaussian Algorithm

            { // Step 1 And 2
                firstNonZeroElementIndex = result.getFirstNonZeroElementInColumn(currentColumn, nextTopRow);

                // Step 1: if the entire columns is 0: go to next step
                if (firstNonZeroElementIndex == -1)
                {
                    currentColumn++;
                    continue;
                }

                // Step 2: Move the row to the top position
                result.argumentedInterchange(nextTopRow, firstNonZeroElementIndex);
                nextTopRow++;
            }

            { // Step 3: Divide the row by that number (multiply by 1/a)
                // Only divide if the number is not 1
                if (result.mData[nextTopRow - 1][currentColumn] != 1)
                    result.argumentedMultiply(nextTopRow - 1, 1 / result.mData[nextTopRow - 1][currentColumn]);
            }

            { // Step 4: Subtract so all elements under the leading 1 is zero
                for (int row = nextTopRow; row < result.mRowCount; row++)
                {
                    // Only subtract if the number under leading 1 is not 0 yet
                    if (this.mData[row][currentColumn] != 0)
                        result.argumentedAddRow(row, nextTopRow - 1, -result.mData[row][currentColumn]);
                }
            }

            // Next step
            currentColumn++;
        }

        // Return result
        return result;
    }

    public Matrix getReducedRowEchelonFormatMatrix()
    {
        // Get Row Echelon Form Matrix first
        Matrix result = this.getRowEchelonFormMatrix();

        // Initialize variables
        int firstNonAllZeroRow = this.mRowCount - 1;

        // Find first non-all-zero row
        while (firstNonAllZeroRow >= 0 && this.getFirstNonZeroElementInRow(firstNonAllZeroRow) == -1) 
            firstNonAllZeroRow--;

        // If the matrix is all 0: already reduced row echelon
        if (firstNonAllZeroRow == -1)
            return result;

        // Process with every upper row
        for (int row = firstNonAllZeroRow - 1; row >= 0; row--)
        {
            
        }

        // Return result
        return result;
    }

}