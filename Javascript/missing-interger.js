/*
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
const file_stream = require('fs')
var sortLibrary = require('./lib/sort-library')

function missingInteger(array_string) {
    let array = JSON.parse(array_string);
    array.sort((a, b) => a - b);
    let missing_number = 1;
    for (let index = 0; index < array.length; index++) {
        if (array[index] > 0) {            
            if (missing_number == array[index]) {
                missing_number++;
            } else{
                if (array[index] != array[index -1]) {
                    break;
                }
            }
        }
    }
    return missing_number;
}

function main() {
    var input_file = 'missing-interger.txt';
    file_stream.readFile(input_file, 'utf8', (error, data) => {
        if (error) {
            throw error;
        }
        let lines = data.split('\r\n');
        for (let index = 0; index < lines.length; index++) {
            console.log(`Result: ${missingInteger(lines[index])}`);
        }
    });
}

main();