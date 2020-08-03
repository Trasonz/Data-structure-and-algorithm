/* Minimize the value |(A[0] + ... + A[P-1]) - (A[P] + ... + A[N-1])|.

You are given N counters, initially set to 0, and you have two possible operations on them:

        increase(X) − counter X is increased by 1,
        max counter − all counters are set to the maximum value of any counter.

A non-empty array A of M integers is given. This array represents consecutive operations:

        if A[K] = X, such that 1 ≤ X ≤ N, then operation K is increase(X),
        if A[K] = N + 1 then operation K is max counter.

For example, given integer N = 5 and array A such that:
    A[0] = 3
    A[1] = 4
    A[2] = 4
    A[3] = 6
    A[4] = 1
    A[5] = 4
    A[6] = 4

the values of the counters after each consecutive operation will be:
    (0, 0, 1, 0, 0)
    (0, 0, 1, 1, 0)
    (0, 0, 1, 2, 0)
    (2, 2, 2, 2, 2)
    (3, 2, 2, 2, 2)
    (3, 2, 2, 3, 2)
    (3, 2, 2, 4, 2)

The goal is to calculate the value of every counter after all operations.

Write a function:

    class Solution { public int[] solution(int N, int[] A); }

that, given an integer N and a non-empty array A consisting of M integers, returns a sequence of integers representing the values of the counters.

Result array should be returned as an array of integers.

For example, given:
    A[0] = 3
    A[1] = 4
    A[2] = 4
    A[3] = 6
    A[4] = 1
    A[5] = 4
    A[6] = 4

the function should return [3, 2, 2, 4, 2], as explained above.

Write an efficient algorithm for the following assumptions:

        N and M are integers within the range [1..100,000];
        each element of array A is an integer within the range [1..N + 1].

*/

const fileStream = require('fs')

function maxCounters(maxcounterPositions, arrayString) {
  let array = JSON.parse(arrayString);
  let counterPositionsArray = new Array(maxcounterPositions);
  counterPositionsArray.fill(0);
  let maxCounter = 0;
  let lastMaxCounter = 0;
  for (let index = 0; index < array.length; index++) {
    if (array[index] <= maxcounterPositions) {
      if (counterPositionsArray[array[index] - 1] < lastMaxCounter) {
        counterPositionsArray[array[index] - 1] = lastMaxCounter;
      }
      let newCounter = counterPositionsArray[array[index] - 1] + 1;
      counterPositionsArray[array[index] - 1] = newCounter;
      if (newCounter > maxCounter) {
        maxCounter = newCounter;
      }
    } else {
      lastMaxCounter = maxCounter;
    }
  }
  // check again
  for (let counterPosition = 0; counterPosition < counterPositionsArray.length; counterPosition++) {
    if (counterPositionsArray[counterPosition] < lastMaxCounter) {
      counterPositionsArray[counterPosition] = lastMaxCounter;
    }
  }
  return counterPositionsArray;
}

function main() {
  var inputFile = 'max-counters-input.txt';
  fileStream.readFile(inputFile, 'utf8', (error, data) => {
    if (error) {
      throw error;
    }
    let lines = data.split('\r\n');
    for (let index = 0; index < lines.length; index++) {
      let input = lines[index].split(' ');
      console.log(`Result: ${maxCounters(Number(input[0]), input[1])}`);
    }
  });
}

main();
