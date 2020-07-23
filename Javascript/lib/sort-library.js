
module.exports = {
    /*
        Thuật toán selection sort sắp xếp một mảng bằng cách đi tìm phần tử có giá trị nhỏ nhất(giả sử với sắp xếp mảng tăng dần) trong đoạn đoạn chưa được sắp xếp và đổi cho phần tử nhỏ nhất đó với phần tử ở đầu đoạn chưa được sắp xếp (không phải đầu mảng). Thuật toán sẽ chia mảng làm 2 mảng con
            1/ Một mảng con đã được sắp xếp
            2/ Một mảng con chưa được sắp xếp

        Độ  phức tạp thuật toán

            Trường hợp tốt: O(n^2)
            Trung bình: O(n^2)
            Trường hợp xấu: O(n^2)

        Không gian bộ nhớ sử dụng: O(1)
    */
    selectionSort: (array) => {
        console.log(array);
        for (let index = 0; index < array.length; index++) {
            let min_value_index = index;
            for (let next_index = index + 1; next_index < array.length; next_index++) {
                if (array[next_index] < array[min_value_index]) {
                    min_value_index = next_index;
                }
            }
            if (min_value_index !== index) {
                console.log(`swapping between: ${array[index]} and ${array[min_value_index]}`);
                let temp = array[index];
                array[index] = array[min_value_index];
                array[min_value_index] = temp;
            }
        }
        return array;
    },
    insertionSort: (array) => {
        for (let current_index = 1; current_index < array.length; current_index++) {
            let current_value = array[current_index];
            let previous_index = current_index - 1;
            while (previous_index >= 0 && array[previous_index] > current_value) {
                array[previous_index + 1] = array[previous_index];
                previous_index = previous_index - 1;
            }
            array[previous_index + 1] = current_value;
        }
        return array;
    }
}
