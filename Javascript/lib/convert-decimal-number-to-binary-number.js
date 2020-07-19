/*
The Divide by 2 algorithm assumes that we start with an integer greater than 0. A simple iteration then continually divides the decimal number by 2 and keeps track of the remainder. The first division by 2 gives information as to whether the value is even or odd. An even value will have a remainder of 0. It will have the digit 0 in the ones place. An odd value will have a remainder of 1 and will have the digit 1 in the ones place. We think about building our binary number as a sequence of digits; the first remainder we compute will actually be the last digit in the sequence.
*/

module.exports = function (decimal_number) {
    let binary_number = '';
    if (decimal_number > Number.MAX_SAFE_INTEGER) {
        throw 'Your input number is too big';
    } else {
        while (decimal_number != 0) {
            remainder = decimal_number % 2;
            binary_number = remainder.toString().concat(binary_number)
            decimal_number = Math.floor(decimal_number / 2);
        }
    }

    // solution 2:
    //    binary_number = decimal_number.ToString(2);
    return binary_number;
};