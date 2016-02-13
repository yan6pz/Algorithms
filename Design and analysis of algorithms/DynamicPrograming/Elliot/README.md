<b>Input</b>
In the first line of standard input are given numbers N, K and Q - respectively
the number of products in the store, the number Elliot wants to buy, and how many times has
changed the situation on the market.
On the second line there are N numbers ai - Prices of goods in the store, in the order
are arranged from left to right (Elliot starts from the left).
Following Q lines, i-th row of which contains a number qi - Minimum price that Elliot should collect 
 in the i-th point of time.

<b>Output</b>
The output consists of Q  lines, each of which contains a number pi
  - the most left position for which a[pi] + ... + a[pi + K - 1] Is at least qi.
 If no such Position display -1.
