/* Find the minimal average of any slice containing at least two elements. 

A non-empty array A consisting of N integers is given. A pair of integers (P, Q), such that 0 ≤ P < Q < N, is called a slice of array A (notice that the slice contains at least two elements). The average of a slice (P, Q) is the sum of A[P] + A[P + 1] + ... + A[Q] divided by the length of the slice. To be precise, the average equals (A[P] + A[P + 1] + ... + A[Q]) / (Q − P + 1).

For example, array A such that:
    A[0] = 4
    A[1] = 2
    A[2] = 2
    A[3] = 5
    A[4] = 1
    A[5] = 5
    A[6] = 8

contains the following example slices:

        slice (1, 2), whose average is (2 + 2) / 2 = 2;
        slice (3, 4), whose average is (5 + 1) / 2 = 3;
        slice (1, 4), whose average is (2 + 2 + 5 + 1) / 4 = 2.5.

The goal is to find the starting position of a slice whose average is minimal.

Write a function:

    function solution(A);

that, given a non-empty array A consisting of N integers, returns the starting position of the slice with the minimal average. If there is more than one slice with a minimal average, you should return the smallest starting position of such a slice.

For example, given array A such that:
    A[0] = 4
    A[1] = 2
    A[2] = 2
    A[3] = 5
    A[4] = 1
    A[5] = 5
    A[6] = 8

the function should return 1, as explained above.

Write an efficient algorithm for the following assumptions:

        N is an integer within the range [2..100,000];
        each element of array A is an integer within the range [−10,000..10,000].

*/

const fileStream = require('fs')

function frogRiverOne(totalLocations, arrayString) {
  let leaveFallLocationInSecond = JSON.parse(arrayString);
  let requiredLocation = new Array(totalLocations);
  requiredLocation.fill(false);
  sumAllLocations = (totalLocations * (totalLocations + 1)) / 2;
  for(let second = 0; second < leaveFallLocationInSecond.length; second++) {
    // requiredLocation elements started with 0 => must -1 ──┐
    if (requiredLocation[leaveFallLocationInSecond[second] - 1] == false) {
      requiredLocation[leaveFallLocationInSecond[second] - 1] = true;
      sumAllLocations = sumAllLocations - leaveFallLocationInSecond[second];
      if (sumAllLocations == 0) {
        return second;
      }
    }
    if (second == leaveFallLocationInSecond.length - 1) {
      if (sumAllLocations != 0) {
        return -1; 
      }
    }
  }
}

function main() {
  var inputFile = 'frog-river-one-input.txt';
  fileStream.readFile(inputFile, 'utf8', (error, data) => {
    if (error) {
      throw error;
    }
    let lines = data.split('\r\n');
    for (let index = 0; index < lines.length; index++) {
      let input = lines[index].split(' ');
      if (frogRiverOne(Number(input[0]), input[1]) == -1) {
        console.log(`The frog can't jump to the other side of the river in the given time`);
      } else {
        console.log(`At second ${frogRiverOne(Number(input[0]), input[1])}. the frog can jump to the other side of the river`);
      }
    }
  });
}

main();
