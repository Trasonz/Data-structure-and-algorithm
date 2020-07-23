module.exports = {
    convert: {
        ToBinary: (number) => {
            return Number(number).toString(2);
        }
    },
    isInt: (number) => {
        return Number(number) % 1 === 0;
    }
}