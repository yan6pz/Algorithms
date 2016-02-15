Suppose you have a huge truck (with no limit of the capacity). However the roads in the graph have maximum capacity per truck.
Write a program that fills the truck with maximum amount of elements so that it can go from every two nodes in the graph.

<b>Input</b>

 The first line of input there are two integers n and m
 - the number of districts and the number of
 direct two-way road between two neighborhoods in the city.
 Each of the next m lines are set at three integers a, b and d,
 which means that there is a direct path from neighborhood 'a' to neighborhood 'b', for which there is a limit to the size 'd'.
 Between two neighborhoods can have more than one direct route. It is guaranteed that between every two neighborhoods in the
 city have path (can not direct).

 <b>Output</b>

 On a separate line display singular - maximum weight of Tirana which are not violated
 restrictions on the road.

 <b>Restrictions</b>
 <pre>
 0 <n ≤ 1000,
 0 <m ≤ 50000
 1 ≤ a, b ≤ n,
 (a ≠ b) 1 ≤ d ≤ 1000
 </pre>
 
 <b>Example Input</b>
 <pre>
4 5
1 2 1
4 2 2
2 3 3
3 4 4
1 3 5
 </pre>
 
 <b>Example Output</b>
 <pre>
 3
 </pre>