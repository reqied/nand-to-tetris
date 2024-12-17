// Smile.asm
// Входное значение R0: top * 32 + left / 16

//  Вычисление стартового адреса 
@16384  //адрес памяти
D=A         // D = 16384
@R0
D=M+D       // стартовый адрес лежит в R0

// Рисование смайлика :)))))))))))))))))))))))))))))))))))))))
@address     
M=D         //не гадим в R0 - сохраняем адрес в другую ячейку

@7224
D=A         // глаз 1
@address
A=M
M=D

@32
D=A
@address    //вычисляем следующий адрес
M=M+D

@7224
D=A         // глаз 2
@address
A=M
M=D

@32
D=A
@address
M=M+D     //вычисляем следующий адрес

@7224
D=A        // глаз 3
@address
A=M
M=D

@32
D=A
@address
M=M+D      //вычисляем следующий адрес

@0
D=A         // пустота 1
@address
A=M
M=D

@32
D=A
@address
M=M+D     //вычисляем следующий адрес

@0
D=A         // пустота 1
@address
A=M
M=D

@32
D=A
@address
M=M+D      //вычисляем следующий адрес

@24582
D=A
@address    //улыбка 1
A=M
M=D

@32
D=A
@address
M=M+D      //вычисляем следующий адрес

@14364
D=A          //улыбка 2
@address
A=M
M=D

@32
D=A
@address
M=M+D      //вычисляем следующий адрес

@4080  
D=A         //улыбка 3
@address
A=M
M=D
