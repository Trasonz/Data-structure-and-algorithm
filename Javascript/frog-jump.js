/* Count minimal number of jumps from position X to Y. 

A small frog wants to get to the other side of the road. The frog is currently located at position X and wants to get to a position greater than or equal to Y. The small frog always jumps a fixed distance, D.

Count the minimal number of jumps that the small frog must perform to reach its target.

Write a function:

    class Solution { public int solution(int X, int Y, int D); }

that, given three integers X, Y and D, returns the minimal number of jumps from position X to a position equal to or greater than Y.

For example, given:
  X = 10
  Y = 85
  D = 30

the function should return 3, because the frog will be positioned as follows:

        after the first jump, at position 10 + 30 = 40
        after the second jump, at position 10 + 30 + 30 = 70
        after the third jump, at position 10 + 30 + 30 + 30 = 100

Write an efficient algorithm for the following assumptions:

        X, Y and D are integers within the range [1..1,000,000,000];
        X ≤ Y.

*/

const fileStream = require('fs')

function frogJump(startLocation, endLocation, jumpDistance) {
  if (jumpDistance > endLocation) {
    if (startLocation == endLocation) {
      return 0;
    } else {
      return 1;
    }
  } else {
    return Math.ceil((endLocation - startLocation) / jumpDistance);
  }
}

function main() {
    var inputFile = 'frog-jump-input.txt';
    fileStream.readFile(inputFile, 'utf8', (error, data) => {
        if (error) {
            throw error;
        }
        let lines = data.split('\r\n');
        for (let index = 0; index < lines.length; index++) {
            let input = lines[index].split(' ');
            console.log(`The frog have to jump ` + frogJump(Number(input[0]), Number(input[1]), Number(input[2])) + ` times`);
        }
    });
}

main();