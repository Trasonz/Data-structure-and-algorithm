Bài Thang đo nhiệt độ KFC

Với đầu vào là độ F, yêu cầu của đề bài là chuyển sang độ C và K. Chúng ta chỉ cần sử dụng 2 công thức đơn giản là:  c=(f−32)/1.8  và  k=c+273.15 
Tuy nhiên, một vấn đề gây khó khăn cho bài này đó là độ chính xác (precision). Lý do chính ở đây là testcase của bài này được generate từ code C++ với kiểu dữ liệu float có khả năng biểu diễn số thực với precision từ 6-9 chữ số (significant digits).
Thêm vào đó, câu lệnh xuất của C++ (e.g.: cout) có precision mặc định là 6 chữ số. Tức là, nó giả định rằng toàn bộ biến kiểu số thực chỉ quan trọng đến 6 significant digits và sẽ cắt bỏ toàn bộ chữ số còn lại phía sau.
Trong khi đó, số thực trong Python lại có khả năng biểu diễn với precision cao hơn.
Có thể dùng package decimal để đặt lại precision thành 6 significant digits.
Ở đây, đối với các trường hợp in thừa các số không phía sau (e.g.: 1.23400), ta dùng normalize() để bỏ đi các số không thừa này (e.g.: 1.234).
Lệnh input() nhập một dòng dữ liệu từ thiết bị nhập chuẩn cho kết quả là xâu ký tự
Lệnh print(e) xuất dữ liệu từ biểu thức e ra thiết bị xuất chuẩn

-----

# làm quen với Decimal 
from decimal import *

# vì sao kết quả trả về là False?
print((1.1 + 2.2) == 3.3)
print(0.1 + 0.1 + 0.1 - 0.3 == 0)

# lí do là biểu diễn số thực liên quan đến số chữ số thập phân
print("Float representation: ", 1.1 + 2.2)
print("Float representation: ", 0.1 + 0.1 + 0.1 - 0.3)

# in ra context
print(getcontext())

print("Float val:", float(1/7))

# The significance of a new Decimal is determined solely by the number of digits input. 
# Context precision and rounding only come into play during arithmetic operations.

# đặt số chữ số thập phân về 6
getcontext().prec = 6

# prec không được áp dụng ở đây
print("Decimal object construction:", Decimal(float(1/7)))

# khi tính toán - prec sẽ được áp dụng
print("Decimal object normalize:", Decimal(float(1/7)).normalize())
print("Decimal object arithmetic operation:", Decimal(float(1/7))+ Decimal(0))
print("Using decimal evaluation:", Decimal(1) / Decimal(7))

# hãy thử lại đoạn code trên với giá trị prec lớn, ví dụ 30
# để thấy dùng Decimal trước hay sau sẽ có kết quả khác nhau
#getcontext().prec = 30

-----

from decimal import *

f = float(input());
c = (f - 32) /1.8;
k = c + 273.15;

getcontext().prec = 6;

print(Decimal(c).normalize(), Decimal(k).normalize());