/* Check whether array A is a permutation.

A non-empty array A consisting of N integers is given.

A permutation is a sequence containing each element from 1 to N once, and only once.

For example, array A such that:
    A[0] = 4
    A[1] = 1
    A[2] = 3
    A[3] = 2

is a permutation, but array A such that:
    A[0] = 4
    A[1] = 1
    A[2] = 3

is not a permutation, because value 2 is missing.

The goal is to check whether array A is a permutation.

Write a function:

    class Solution { public int solution(int[] A); }

that, given an array A, returns 1 if array A is a permutation and 0 if it is not.

For example, given array A such that:
    A[0] = 4
    A[1] = 1
    A[2] = 3
    A[3] = 2

the function should return 1.

Given array A such that:
    A[0] = 4
    A[1] = 1
    A[2] = 3

the function should return 0.

Write an efficient algorithm for the following assumptions:

        N is an integer within the range [1..100,000];
        each element of array A is an integer within the range [1..1,000,000,000].

*/

const fileStream = require('fs')

function permutationCheck(arrayString) {
  let array = JSON.parse(arrayString);  
  let permuationArrayCheck = new Array(array.length);
  permuationArrayCheck.fill(false);
  for (let index = 0; index < array.length; index++) {
    if (array[index] <= 0 || array[index] > array.length) {
      return 0;
    }
    if (permuationArrayCheck[array[index] - 1] == true) {
      return 0;
    } else {
      permuationArrayCheck[array[index] - 1] = true;
    }
  }
  return 1;
}

function main() {
  var inputFile = 'permutation-check-input.txt';
  fileStream.readFile(inputFile, 'utf8', (error, data) => {
    if (error) {
      throw error;
    }
    let lines = data.split('\r\n');
    for (let index = 0; index < lines.length; index++) {
      console.log(`Is this array a permutation? -  ${permutationCheck(lines[index])}\t${lines[index]}`);
    }
  });
}

main();
