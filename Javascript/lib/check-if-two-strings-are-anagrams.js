
function generateCharacterMapping(_string) {
    // Convert all characters to lower cases in order to reduce the space of the character mapping object
    // [^\w]: match any character that not a alphanumeric character (" ", "!", "?", ...)
    let listOfAlphanumericCharacters = _string.replace(/[^\w]/g, '').toLowerCase();

    // Increment each character count by one if found
    const characterMapping = {}

    for (let alphanumericCharacter of listOfAlphanumericCharacters){
        if (characterMapping[alphanumericCharacter] === undefined) {
            characterMapping[alphanumericCharacter] = 1;
        } else {
            characterMapping[alphanumericCharacter]++;
        }

        //characterMapping[character] = characterMapping[character] + 1 || 1
    }
    return characterMapping
}

function isAnagrams(_firstString, _secondString) {
    
    const firstStringCharacterMapping = generateCharacterMapping(_firstString);
    const secondStringCharacterMapping = generateCharacterMapping(_secondString);
    
    // if two string have different length
    if (Object.keys(firstStringCharacterMapping).length !== Object.keys(secondStringCharacterMapping).length) { 
        return false 
    } else {
        for (const char in firstStringCharacterMapping) {
            // firstStringCharacterMapping[char]: return the amount of current character first string's character mapping
            if (firstStringCharacterMapping[char] !== secondStringCharacterMapping[char]) {
                return false;
            }
        }    
        return true;
    }
}

console.log(isAnagrams('a gentlemaN', 'elegant maN'));
console.log(isAnagrams('Tar', 'Rat'));
console.log(isAnagrams('Elbow', 'Below'));
console.log(isAnagrams('State', 'Taste'));
console.log(isAnagrams('Dusty', 'Study'));
console.log(isAnagrams('Thing', 'Rat'));
