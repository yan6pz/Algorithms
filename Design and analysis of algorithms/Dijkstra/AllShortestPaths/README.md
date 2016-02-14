
<b>Input</b>

The first line of standard input will be given integers N and M
 - the number vertices and edges in the graph. The next M lines will have a threesome numbers
 Fi, Ti, Pi, representing one directed edge with its weight. There may be more than one edge between
 a pair of vertices (F, T), as it is possible to have an edge pointing to itself.
 
<b>Output</b>

On The standard exit output separated by space two integers - the length of min distance and 
the minimum number of different ways it can be achieved. Two ways are considered different
 if they use at least one other edge. Since the number of paths it can be very large display
 only its residue modulo 1,000,000,007. In case there is no path between 1 and N, display
 "-1" and a number of roads - "0".

<b>Limitations</b>
<pre>
 2 ≤ N ≤ 100,000
 1 ≤ M ≤ 500,000
 1 ≤ Pi ≤ 1,000,000,000
 1 ≤ Fi, Ti ≤ N
 </pre>
 
</b>Example input:</b>
<pre>
5 6 
1 2 10 
1 4 29 
2 3 50 
4 3 13 
4 5 24 
3 5 11 
</pre>

</b>Example Output:</b>
<pre>
53 2 
</pre>
