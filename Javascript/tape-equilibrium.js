/* Minimize the value |(A[0] + ... + A[P-1]) - (A[P] + ... + A[N-1])|.

A non-empty array A consisting of N integers is given. Array A represents numbers on a tape.

Any integer P, such that 0 < P < N, splits this tape into two non-empty parts: A[0], A[1], ..., A[P − 1] and A[P], A[P + 1], ..., A[N − 1].

The difference between the two parts is the value of: |(A[0] + A[1] + ... + A[P − 1]) − (A[P] + A[P + 1] + ... + A[N − 1])|

In other words, it is the absolute difference between the sum of the first part and the sum of the second part.

For example, consider array A such that:
  A[0] = 3
  A[1] = 1
  A[2] = 2
  A[3] = 4
  A[4] = 3

We can split this tape in four places:

        P = 1, difference = |3 − 10| = 7
        P = 2, difference = |4 − 9| = 5
        P = 3, difference = |6 − 7| = 1
        P = 4, difference = |10 − 3| = 7

Write a function:

    class Solution { public int solution(int[] A); }

that, given a non-empty array A of N integers, returns the minimal difference that can be achieved.

For example, given:
  A[0] = 3
  A[1] = 1
  A[2] = 2
  A[3] = 4
  A[4] = 3

the function should return 1, as explained above.

Write an efficient algorithm for the following assumptions:

        N is an integer within the range [2..100,000];
        each element of array A is an integer within the range [−1,000..1,000].

*/

const fileStream = require('fs')

function tapeEquilibrium(arrayString) {
  let array = JSON.parse(arrayString);
  sumOfAllElements = array.reduce((a, b) => a + b, 0);
  let firstPartSum = 0;
  let secondPartSum = sumOfAllElements;
  let minimalDifference = 0;
  for (let index = 0; index < (array.length - 1); index++) {
    firstPartSum = firstPartSum + array[index];
    secondPartSum = sumOfAllElements - firstPartSum;
    let difference = Math.abs(firstPartSum - secondPartSum);
    if (index != 0) {
      if (difference < minimalDifference) {
        minimalDifference = difference;
      }
    } else {
      minimalDifference = difference;
    }
    if (minimalDifference == 0) {
      break;
    }
  }
  return minimalDifference;
}

function main() {
  var inputFile = 'tape-equilibrium-input.txt';
  fileStream.readFile(inputFile, 'utf8', (error, data) => {
    if (error) {
      throw error;
    }
    let lines = data.split('\r\n');
    for (let index = 0; index < lines.length; index++) {
      console.log(`Result: ${tapeEquilibrium(lines[index])}\t${lines[index]}`);
    }
  });
}

main();
