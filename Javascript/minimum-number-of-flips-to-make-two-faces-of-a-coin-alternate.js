/* 

Cho trước số lần lật và úp của một đồng tiền, chỉnh sửa sao cho lật và úp hoặc úp và lật kế nhau.

*/
const fileStream = require('fs')

let coinFace = {
    head: 1,
    tail: 0
}

function flipProcess(expectedFace, flipData) {
    let numberOfFlips = 0;
    for (let currentFace = 0; currentFace < flipData.length; currentFace++) 
    {
        if (flipData[currentFace] != expectedFace) {
            numberOfFlips++;
        }
  
        // flip the coin
        if (expectedFace == coinFace.head) {
            expectedFace = coinFace.tail;
        } else {
            expectedFace = coinFace.head;
        }
    }
    return numberOfFlips;
}

function minimumNumberOfFlipsToMakeTwoFacesOfACoinAlternate(arrayString) {
    let flipData = JSON.parse(arrayString);

    let expectedFace = coinFace.head;
    let resultStartWithHeadFace = flipProcess(expectedFace, flipData);

    expectedFace = coinFace.tail;
    let resultStartWithTailFace = flipProcess(expectedFace, flipData);

    if (resultStartWithHeadFace < resultStartWithTailFace) {
        return resultStartWithHeadFace;
    } else {
        return resultStartWithTailFace;
    }
}

function main() {
    var inputFile = 'minimum-number-of-flips-to-make-two-faces-of-a-coin-alternate-input.txt';
    fileStream.readFile(inputFile, 'utf8', (error, data) => {
        if (error) {
            throw error;
        }
        let lines = data.split('\r\n');
        for (let index = 0; index < lines.length; index++) {
            console.log(`Result: ${minimumNumberOfFlipsToMakeTwoFacesOfACoinAlternate(lines[index])}`);
        }
    });
}

main();