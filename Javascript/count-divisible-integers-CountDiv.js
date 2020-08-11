/* Compute number of integers divisible by k in range [a..b].

Write a function:

    class Solution { public int solution(int A, int B, int K); }

that, given three integers A, B and K, returns the number of integers within the range [A..B] that are divisible by K, i.e.:

    { i : A ≤ i ≤ B, i mod K = 0 }

For example, for A = 6, B = 11 and K = 2, your function should return 3, because there are three numbers divisible by 2 within the range [6..11], namely 6, 8 and 10.

Write an efficient algorithm for the following assumptions:

        A and B are integers within the range [0..2,000,000,000];
        K is an integer within the range [1..2,000,000,000];
        A ≤ B.

*/

const fileStream = require('fs')

function countDiv(startIndex, endIndex, K) {
  let result = Math.floor(endIndex / K) - Math.floor(startIndex / K);
  if (startIndex % K == 0) {
    result = result + 1;
  }
  return result;
}

function main() {
  var inputFile = 'count-divisible-integers-CountDiv.txt';
  fileStream.readFile(inputFile, 'utf8', (error, data) => {
    if (error) {
      throw error;
    }
    let lines = data.split('\r\n');
    for (let index = 0; index < lines.length; index++) {
      let input = lines[index].split(' ');
      console.log(`Result: ${countDiv(Number(input[0]), Number(input[1]), Number(input[2]))}`);
    }
  });
}

main();
