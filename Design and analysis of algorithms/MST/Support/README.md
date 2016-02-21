The programmers want to travel freely through the N blocks (numbered from 1 to N). 
Fields are separated by woods. Since programmers are lazy (odd) and do not want to push themself way through forests rely on accidentally
 found ways made of wild animals. The roads are undirected.
 The programmers find every week a new path. 
 Then they have to decide which of found ways to maintain to be able to travel freely between all fields. 
 Since programmers are smart , they want to minimize the length of maintained roads.
 They can choose between all already found roads. 
 For each week display the sum of the lengths of roads maintained by the cows, to ensure that there is a path between any two fields.
 If no such roads, print -1.

 <b>Input</b>

 The first line of standard input contains integers <i>N (1 <= N <= 200) and W (1 <= W <= 6000)</i>. Followed by <i>W</i> lines,
 each describing newfound time this week the type <i>x y c</i>. This means that from <i>x to y</i> there is a path with length <i>c</i>.

 <b>Output</b>

For every week output the minimum sum of the lengths of paths that will ensure that there is a path between all fields.
 If there are no such roads output -1.
 
 <b>Example Input</b>
 <pre>
 4 6
 1 2 10
 1 3 8
 3 2 3
 1 4 3
 1 3 6
 2 1 2
 </pre>
 
  <b>Example Output</b>
 <pre>
 -1
 -1
 -1
 14
 12 
 8
 </pre>