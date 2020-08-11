/* Find the minimal nucleotide from a range of sequence DNA.

A DNA sequence can be represented as a string consisting of the letters A, C, G and T, which correspond to the types of successive nucleotides in the sequence. Each nucleotide has an impact factor, which is an integer. Nucleotides of types A, C, G and T have impact factors of 1, 2, 3 and 4, respectively. You are going to answer several queries of the form: What is the minimal impact factor of nucleotides contained in a particular part of the given DNA sequence?

The DNA sequence is given as a non-empty string S = S[0]S[1]...S[N-1] consisting of N characters. There are M queries, which are given in non-empty arrays P and Q, each consisting of M integers. The K-th query (0 ≤ K < M) requires you to find the minimal impact factor of nucleotides contained in the DNA sequence between positions P[K] and Q[K] (inclusive).

For example, consider string S = CAGCCTA and arrays P, Q such that:
    P[0] = 2    Q[0] = 4
    P[1] = 5    Q[1] = 5
    P[2] = 0    Q[2] = 6

The answers to these M = 3 queries are as follows:

        The part of the DNA between positions 2 and 4 contains nucleotides G and C (twice), whose impact factors are 3 and 2 respectively, so the answer is 2.
        The part between positions 5 and 5 contains a single nucleotide T, whose impact factor is 4, so the answer is 4.
        The part between positions 0 and 6 (the whole string) contains all nucleotides, in particular nucleotide A whose impact factor is 1, so the answer is 1.

Write a function:

    class Solution { public int[] solution(String S, int[] P, int[] Q); }

that, given a non-empty string S consisting of N characters and two non-empty arrays P and Q consisting of M integers, returns an array consisting of M integers specifying the consecutive answers to all queries.

Result array should be returned as an array of integers.

For example, given the string S = CAGCCTA and arrays P, Q such that:
    P[0] = 2    Q[0] = 4
    P[1] = 5    Q[1] = 5
    P[2] = 0    Q[2] = 6

the function should return the values [2, 4, 1], as explained above.

Write an efficient algorithm for the following assumptions:

        N is an integer within the range [1..100,000];
        M is an integer within the range [1..50,000];
        each element of arrays P, Q is an integer within the range [0..N − 1];
        P[K] ≤ Q[K], where 0 ≤ K < M;
        string S consists only of upper-case English letters A, C, G, T.

*/

/* Prefix sum
  A             = [6,3,-2,4,-1,0,-5]
  A(prefix sum) = [6,9,7,11,10,10,5]
  sum (A[0] to A[4]) = A(prefix sum)[4] = 10
  sum (A[i] to A[j]) = A(prefix sum)[j] - A(prefix sum)[i - 1]
  Ex: A(prefix sum) [2 to 6] = A(prefix sum) [6] - A(prefix sum) [1]
*/

const fileStream = require('fs')

/*
function genomicRangeQuery(DNASequence, PArmArrayString, QArmArrayString) {
  let PArmArray = JSON.parse(PArmArrayString);
  let QArmArray = JSON.parse(QArmArrayString);
  // idea: use prefix sum to check if the DNA (A or B or C or D) by this priority order A (1), C (2), G (3), T (4) 
  //       appear in the string from P to Q
  let nucleotide = {
    'A': 1,
    'C': 2,
    'G': 3,
    'T': 4
  }

  let nucleotidePrefixSumArray = {
    'A': new Array(DNASequence.length + 1),
    'C': new Array(DNASequence.length + 1),
    'G': new Array(DNASequence.length + 1)
    // T may not need because it is the last option in the DNA priority list.
  }

  nucleotidePrefixSumArray['A'][0] = 0;
  nucleotidePrefixSumArray['C'][0] = 0;
  nucleotidePrefixSumArray['G'][0] = 0;

  for (let index = 0; index < DNASequence.length; index++) {
    let isContainA = 0;
    let isContainC = 0;
    let isContainG = 0;
    if (DNASequence[index] == 'A') {
      isContainA = 1;
    }
    if (DNASequence[index] == 'C') {
      isContainC = 1;
    }
    if (DNASequence[index] == 'G') {
      isContainG = 1;
    }
    nucleotidePrefixSumArray['A'][index + 1] = nucleotidePrefixSumArray['A'][index] + isContainA;
    nucleotidePrefixSumArray['C'][index + 1] = nucleotidePrefixSumArray['C'][index] + isContainC;
    nucleotidePrefixSumArray['G'][index + 1] = nucleotidePrefixSumArray['G'][index] + isContainG;
  }

  let result = new Array(PArmArray.length);

  for (let index = 0; index < PArmArray.length; index++) {
    let beginDNAPart = PArmArray[index];
    let endDNAPart = QArmArray[index] + 1;

    if (nucleotidePrefixSumArray['A'][endDNAPart] - nucleotidePrefixSumArray['A'][beginDNAPart] > 0) {
      result[index] = nucleotide['A'];
    } else if (nucleotidePrefixSumArray['C'][endDNAPart] - nucleotidePrefixSumArray['C'][beginDNAPart] > 0) {
      result[index] = nucleotide['C'];
    } else if (nucleotidePrefixSumArray['G'][endDNAPart] - nucleotidePrefixSumArray['G'][beginDNAPart] > 0) {
      result[index] = nucleotide['G'];
    } else {
      result[index] = nucleotide['T'];
    }
  }

  return result;
}
*/

function genomicRangeQuery(DNASequence, PArmArrayString, QArmArrayString) {
  let PArmArray = JSON.parse(PArmArrayString);
  let QArmArray = JSON.parse(QArmArrayString);
  // idea: use prefix sum to check if the DNA (A or B or C or D) by this priority order A (1), C (2), G (3), T (4) 
  //       appear in the string from P to Q
  let nucleotide = {
    'A': 1,
    'C': 2,
    'G': 3,
    'T': 4
  }

  let nucleotidePrefixSumArray = {
    'A': new Array(DNASequence.length),
    'C': new Array(DNASequence.length),
    'G': new Array(DNASequence.length)
    // T may not need because it is the last option in the DNA priority list.
  }

  for (let index = 0; index < DNASequence.length; index++) {
    let isContainA = 0;
    let isContainC = 0;
    let isContainG = 0;
    if (DNASequence[index] == 'A') {
      isContainA = 1;
    }
    if (DNASequence[index] == 'C') {
      isContainC = 1;
    }
    if (DNASequence[index] == 'G') {
      isContainG = 1;
    }
    if (index != 0) {
      nucleotidePrefixSumArray['A'][index] = nucleotidePrefixSumArray['A'][index - 1] + isContainA;
      nucleotidePrefixSumArray['C'][index] = nucleotidePrefixSumArray['C'][index - 1] + isContainC;
      nucleotidePrefixSumArray['G'][index] = nucleotidePrefixSumArray['G'][index - 1] + isContainG;
    } else {
      nucleotidePrefixSumArray['A'][index] = isContainA;
      nucleotidePrefixSumArray['C'][index] = isContainC;
      nucleotidePrefixSumArray['G'][index] = isContainG;
    }
  }

  let result = new Array(PArmArray.length);

  for (let index = 0; index < PArmArray.length; index++) {
    let beginDNAPart = PArmArray[index];
    let endDNAPart = QArmArray[index];
    if (beginDNAPart == 0) {
      if (nucleotidePrefixSumArray['A'][endDNAPart] > 0) {
        result[index] = nucleotide['A'];
      } else if (nucleotidePrefixSumArray['C'][endDNAPart] > 0) {
        result[index] = nucleotide['C'];
      } else if (nucleotidePrefixSumArray['G'][endDNAPart] > 0) {
        result[index] = nucleotide['G'];
      } else {
        result[index] = nucleotide['T'];
      }
    } else {
      beginDNAPart = beginDNAPart - 1
      if (nucleotidePrefixSumArray['A'][endDNAPart] - nucleotidePrefixSumArray['A'][beginDNAPart] > 0) {
        result[index] = nucleotide['A'];
      } else if (nucleotidePrefixSumArray['C'][endDNAPart] - nucleotidePrefixSumArray['C'][beginDNAPart] > 0) {
        result[index] = nucleotide['C'];
      } else if (nucleotidePrefixSumArray['G'][endDNAPart] - nucleotidePrefixSumArray['G'][beginDNAPart] > 0) {
        result[index] = nucleotide['G'];
      } else {
        result[index] = nucleotide['T'];
      }
    }
  }

  return result;
}

function main() {
  var inputFile = 'genomic-range-query-input.txt';
  fileStream.readFile(inputFile, 'utf8', (error, data) => {
    if (error) {
      throw error;
    }
    let lines = data.split('\r\n');
    for (let index = 0; index < lines.length; index++) {
      let input = lines[index].split(' ');
      console.log(`Result: ${genomicRangeQuery(input[0], input[1], input[2])}`);
    }
  });
}

main();
