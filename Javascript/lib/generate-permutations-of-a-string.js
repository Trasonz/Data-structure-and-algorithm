/* The Master Theorem
reference: https://medium.com/@malaynandasana/master-theorem-b544fa8829f7
procedure p( input x of size n ):
   if n < some constant k:
     Solve x directly without recursion
   else:
     Create a subproblems of x, each having size n/b
     Call procedure p recursively on each subproblem
     Combine the results from the subproblems
*/


function generatePermutations(string) {
    // check 
    if (!string) {
        return "Please enter a string"
    } else if (string.length < 2) {
        return string
    }

    let permutationsArray = []

    for (let index = 0; index < string.length; index++) {
        let character = string[index];
        // all characters before and after the current character
        let remainingCharacters;
        if (index == 0) {
            remainingCharacters = string.substring(index + 1);
        } else if (0 < index && index < string.length - 1) {
            remainingCharacters = string.substring(0, index) + string.substring(index + 1);
        } else {
            remainingCharacters = string.substring(0, index);
        }
        // let remainingCharacters = string.substring(0, index) + string.substring(index + 1);

        // Call procedure p recursively on each subproblem
        for (let permutation of generatePermutations(remainingCharacters)) {
            // Combine the results from the subproblems
            permutationsArray.push(character + permutation)
        }
    }
    return permutationsArray
}

console.log(generatePermutations('banana'));
