Write a program that simulates the movement of a car in an ordinary city with intersections(nodes) and streets(edges).
Streets are weighted also the the intersections are weighted because of the traffic lights.

<b>Input</b>

The first line will sit the numbers H and M. Where:
- N e number of intersections in the city.
 We would like to note that for your convenience intersection of start is numbered 1 and the intersection of destination is numbered with N.
- M is the number of streets.
M lines follow, each there are two junctions and the time in seconds it takes to move from one intersection to another.
Then N lines of the i-th of which are set duration of green and red traffic lights i-th intersection. Keep in mind that:
- Moment of the replace traffic lights from one color to another is enough to pass.
- If you arrive at the junction with the number N, its lights shine red, the car must wait time of a flashing green
 to be considered arrived.
- you will hit so far his departure that all traffic lights will glow green then.

 <b>Output</b>
 
One line of standard output should be displayed minimum time in seconds needed to reach the intersection of start(1)
 to the intersection of destination (intersection N).
 
 <b>Example input</b>
 <pre>
1 
7 11 
1 2 12 
1 4 9 
1 6 6 
2 6 7 
2 3 15 
3 6 8 
3 5 2 
3 7 4 
4 5 15 
4 6 4 
5 6 10 
7 4 
5 11 
2 8 
4 5 
8 8 
0 120 
2 5
 </pre>
 
 <b>Example output</b>
 <pre>
 35
 </pre>
