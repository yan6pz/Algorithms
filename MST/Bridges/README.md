Suppose we have huge lake with several Islands. Our aim is to connect all the Islands
 with minimum cost and maximum capacity in order a group of people to walk together and 
 visit all the islands.

<b>Input:</b>

 The first line of standard input will be given two numbers: N and M,
 respectively, indicating the number of islands in the lake and the number
 of successful tests of bridge price . The islands are numbered from 1 to N.
 The next M lines contain 4 numbers each: <i>from, to, cost, capacity</i>. The meanings
 of these four numbers are as follows: 
 - <i>from, to</i> - indicate the numbers of the two bridges between which measurement is made;
 - <i>Cost</i> - cost to build a bridge between the islands of numbers from and to;
 - <i>Capacity</i> - the maximum number of people who can move the bridge.
 
We will assume that when the guide visit the country with friends, there will not be other
 visitors who reduce the capacity of the edges. Bridges are bidirectional - i.e. if there is
 a bridge between the islands numbered (A; B), this means that they can travel from A to B, and back.
There might be different <i>cost</i> for same pair of vertices(edge).
 
<b>Output:</b>
 
The first line of standard output maximum number of people who the guide
 can take with him so that the entire group can address all places at once, they walk together.
 If it is not possible to visit all the islands via bridges print -1.
 
<b>Example Input:</b>
3   
3
1   2   100  3
2   3   200  10
3   1   100  5

<b>Example Output:</b>
2

i.e. the guide can take maximum 2 people with him.