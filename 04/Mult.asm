// Программа должна умножать числа из R0 и R1 и сохранять результат в R2.

//R2=0
//counter=0
//(LOOP)
//  if counter - r1 == 0:
//      R2 = counter
//      goto END
//  else:
//      counter += R0
//      R2=counter
//   
//(END)
//  R2=couner

// сделаем counter and R2 = 0
@R2        // R2 = 0 (тут будет результат умножения)
M=0
@counter
M=0

(LOOP)
    @counter
    D=M
    M=M+1   // counter = counter + 1
    @R1
    D=D-M   // D = counter - R1
    @END    // if counter == R1 goto END
    D;JEQ

    @R0     // else R2 += R0
    D=M
    @R2
    M=M+D   // R2 = R2 + R0

    @LOOP   // повторяем
    0;JMP

(END)
@END
0;JMP       // Бесконечный цикл, чтобы нас не взломали
