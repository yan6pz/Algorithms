Undirected graph G with n vertices and n-1 edges. The graph is connected and lengths
 of the edges are integers. Denote by <code>d(x, y)</code> the length of the shortest path between
 two vertices x and y in G.The Diameter of the graph G was called the greatest of the numbers <code>d(x, y)</code>,
 where x and y are two random vertices from G. Write a program that finds the diameter of the G.
 
<b>Input</b>

 The first line is a number n - the number of vertices
 in the graph. The vertices of G are numbered with integers from 1 to n.
 Each of the next n-1 lines describes a edge of the graph: the first two numbers assigned ends 
 of the edge, and the third number is the length of the edge <code>d(x, y)</code>, a nonnegative integer less than 1000.

 <b>Output </b>

On a single line of standard output to display searched diameter

<b>Example input:</b>
<pre>
10 
4 5 5 
4 3 2 
4 2 1 
5 6 4 
5 1 0 
5 7 4 
3 8 4 
3 9 3 
3 10 3 
</pre>
<b>Example output:</b>
<pre>
15
</pre>