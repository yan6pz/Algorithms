Suppose two players have N coins infront of them. They have to choose two positive integers K and L.
 Once you choose the numbers game can begin. Each of the players interchange themselves when playing.
 The player having the move may take <i>1, K or L</i> coins from all coins.
 Wins the person who gets the last coin (or last coins).
 Here, it falls the responsibility to write a program that, given <i>K, L and N</i> to determine who will be the winner.

<b>Input</b>
The first line of standard input will have three numbers - <i>K, L and M</i>, separated by a space.
On the second row are set <i>M</i> different positive heights towers of coins <i>N1, N2, ...., NM</i>.
<b>Output</b>
The program should calculate who will be the winner in the different cases for <i>K and L</i>,
 for each tower composed of <i>Ni</i> coins. The result should appear on a separate line of standard output as a string of length <i>M</i>, composed of letters <i>A and B</i>. If the first player wins the <i>i-th</i> game,
 the <i>i-th</i> letter in the string should be <i>A</i>. if the game is won by the second player then the <i>i-th</i> point must be <i>B</i>.
 
 <b>Limitations</b>
 <pre>
- K and L are integers,
 where <i>1 <K <L <10 </i>
 - M is integer, where <i> 3 <M <50<i/>
<i> -1 <Ni <1 000 000</i> as <i>i = 1, 2, .... , M</i>
</pre>

<b>Example Input</b>
<pre>
2 3 5
3 12 113 25714 88888
</pre>

<b>Example Output</b>
<pre>
ABAAB
</pre>