/* Rotate an array to the right by a given number of steps. 

An array A consisting of N integers is given. Rotation of the array means that each element is shifted right by one index, and the last element of the array is moved to the first place. For example, the rotation of array A = [3, 8, 9, 7, 6] is [6, 3, 8, 9, 7] (elements are shifted right by one index and 6 is moved to the first place).

The goal is to rotate array A K times; that is, each element of A will be shifted to the right K times.

Write a function:

    class Solution { public int[] solution(int[] A, int K); }

that, given an array A consisting of N integers and an integer K, returns the array A rotated K times.

For example, given
    A = [3, 8, 9, 7, 6]
    K = 3

the function should return [9, 7, 6, 3, 8]. Three rotations were made:
    [3, 8, 9, 7, 6] -> [6, 3, 8, 9, 7]
    [6, 3, 8, 9, 7] -> [7, 6, 3, 8, 9]
    [7, 6, 3, 8, 9] -> [9, 7, 6, 3, 8]

For another example, given
    A = [0, 0, 0]
    K = 1

the function should return [0, 0, 0]

Given
    A = [1, 2, 3, 4]
    K = 4

the function should return [1, 2, 3, 4]

Assume that:

    N and K are integers within the range [0..100];
    each element of array A is an integer within the range [−1,000..1,000].

In your solution, focus on correctness. The performance of your solution will not be the focus of the assessment.

*/
const file_stream = require('fs')

function cyclicRotation(array_string, k_times) {
    array = JSON.parse(array_string);
    let middle_point = Math.ceil(array.length / 2);
    remain_times = k_times % array.length;
    if (remain_times == 0) {
        return array;
    } else if (remain_times >= middle_point && remain_times < array.length) {
        for (let index = 0; index < (array.length - remain_times); index++) {
            let first_number = array.shift();
            array.push(first_number);
        }
        return array;
    } else {
        for (let index = 0; index < k_times; index++) {
            let last_number = array.pop();
            array.unshift(last_number);
        }
        return array;
    }
    return array;
}

function main() {
    var input_file = 'cyclic-rotation-input.txt';
    file_stream.readFile(input_file, 'utf8', (error, data) => {
        if (error) {
            throw error;
        }
        let lines = data.split('\r\n');
        for (let index = 0; index < lines.length; index++) {
            let input = lines[index].split(' ');
            console.log(`Result of the array ${input[0]} after rotated ${input[1]} times: [` + cyclicRotation(input[0], Number(input[1])) + `]`);
        }
    });
}

main();
