module.exports = {
    isInt: function (number) {
        return Number(number) % 1 == 0;
    },
    convert: {
        ToBinary: function (number) {
            return Number(number).toString(2);
        }
    }
}