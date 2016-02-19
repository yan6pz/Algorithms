We have a group of friends and one of them is injured.
As input you get the houses and hospitals and the distances between them.
 Your task is to find in which hospital is best to leave the injured so that the total distance
 that the friends must elapse from the hospital to their homes is minimal.

<b>Input</b>
 The first line of standard input get three integers <i>N, M and H</i> (separated by spaces)
 that represent the number of points on the map (houses and hospitals),
 the number of streets on the map and the number of hospitals respectively.
 The second line will get H numbers - the points on the map, which are hospitals.
 All other items (not hospitals) are homes. The next M lines represent the streets.
 Each line will contain three integers <i>F, S and D</i>. This means that between nodes F and S has a street and it has a length D.
 All streets are undirected, ie if we have street between nodes A and B, we have street between B and A.
 The inputs are always valid and descriptions format.

 <b>Output</b>
The program must write to the standard output a single integer - the minimum amount of distance that each of the friends
 of Peter must travel from a hospital.
 
 <b>Example Input</b>
 <pre>
3 2 1
1
1 2 1
3 2 2
 </pre>
 There is only one hospital
 <b>Example Output</b>
  <pre>
4
 </pre>
 
  <b>Example Input</b>
 <pre>
5 8 2
1 2
1 2 5
4 1 2
1 3 1
3 4 4
4 5 1
2 4 3
5 2 1
2 3 20
</pre>

<b>Example Output</b>
 <pre>
6
</pre>