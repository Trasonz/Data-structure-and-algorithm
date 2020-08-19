/* Find the smallest positive integer that does not occur in a given sequence. 

Write a function:

    class Solution { public int solution(int[] A); }

that, given an array A of N integers, returns the smallest positive integer (greater than 0) that does not occur in A.

For example, given A = [1, 3, 6, 4, 1, 2], the function should return 5.

Given A = [1, 2, 3], the function should return 4.

Given A = [−1, −3], the function should return 1.

Write an efficient algorithm for the following assumptions:

        N is an integer within the range [1..100,000];
        each element of array A is an integer within the range [−1,000,000..1,000,000].

Copyright 2009–2020 by Codility Limited. All Rights Reserved. Unauthorized copying, publication or disclosure prohibited. 

*/
const fileStream = require('fs')

function missingInteger(arrayString) {
    let array = JSON.parse(arrayString);
    array.sort((a, b) => a - b);
    let missingNumber = 1;
    for (let index = 0; index < array.length; index++) {
        if (array[index] > 0) {            
            if (missingNumber == array[index]) {
                missingNumber++;
            } else {
                if (array[index] != array[index -1]) {
                    break;
                }
            }
        }
    }
    return missingNumber;
}

function main() {
    var inputFile = 'missing-interger.txt';
    fileStream.readFile(inputFile, 'utf8', (error, data) => {
        if (error) {
            throw error;
        }
        let lines = data.split('\r\n');
        for (let index = 0; index < lines.length; index++) {
            console.log(`Result: ${missingInteger(lines[index])}\t${lines[index]}`);
        }
    });
}

main();