Given is a labyrinth. Write a program that finds shortest distance between two empty cells.

<b>Input</b>
The map of the labyrinth will be represented as a two-dimensional NxN matrix of symbols.
On the first line of input will be integers N and M. Where:
- N- the number of rows of the matrix
- M-is the number of columns

Following N lines with M symbols separated by spaces.
 Every element of this two-dimensional matrix is ​​a separate field, such as:
'#' - Means that you have a wall and there is no way to be stepped on this field
'.' - The field is free and safe to step on it
The next line will have two numbers separated by a space, which will indicate the row and column at the entrance
 of the maze (where start is).
The next line will have two numbers separated by a space, which will indicate the row and column of the exit of the maze.

<b>Output</b>

Write a number that represents the minimum number of moves needed to get out of the maze.
 For one stroke count transition from one field to another. If it turns out that 
 can not get out of the maze print -1.
 
 <b>Example Input</b>
 <pre>
4 6
# # # . # #
. . # . . #
# . . . . #
# # # # # #
0 3
1 0
 </pre>
 
 <b>Example Output</b>
 <pre>
 6
 </pre>
 