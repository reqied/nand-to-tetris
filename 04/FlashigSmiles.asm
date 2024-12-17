// инициализируем основной цикл, в нем происходят основные действия
(LOOP)
    // считываем текущую нажатую клавишу
    @KBD         
    D=M  
    @previousKey   
    D=D-M         // проверяем, изменилась ли клавиша
    @END 
    D;JEQ         // if (текущая_клавиша==предыдущаяя) goto END

    // очистка экрана <=> все предыдущие строки в 0
    @previousEyesLine1
    A = M
    M = 0
    @previousEyesLine2
    A = M
    M = 0
    @previousEyesLine3
    A = M
    M = 0
    @previousSmileLine1
    A = M
    M = 0
    @previousSmileLine2
    A = M
    M = 0
    @previousSmileLine3
    A = M
    M = 0

    // обновление previousKey текущей нажатой клавишей
    @KBD 
    D=M 
    @previousKey
    M=D

    // Проверяем LEFT 130
    @130
    D=D-A       // сравниваем текущую клавишу с 130
    @LEFT
    D;JEQ        // if A-D=0: goto LEFT_POS

    // Проверяем UP 131     // сравниваем текущую клавишу с 131
    @UP
    D=D-1;JEQ        // if A-D=0: goto UP_POS

    // Проверяем RIGHT 132      // сравниваем текущую клавишу с 132
    @RIGHT
    D=D-1;JEQ        // if A-D=0: goto RIGHT_POS

    // Проверяем DOWN 133       // сравниваем текущую клавишу с 133
    @DOWN
    D=D-1;JEQ        // if A-D=0: goto DOWN_POS

    @END
    0;JMP       // иначе в end

    // находим сдвиг, если нажата left
    (LEFT)
        @3978
        D=A 
        @R0 
        M=D 
        @DRAW
        0;JMP

    // находим сдвиг, если нажата up
    (UP)
        @2640
        D=A 
        @R0 
        M=D 
        @DRAW
        0;JMP

    // находим сдвиг, если нажата right
    (RIGHT)
        @3989
        D=A 
        @R0 
        M=D 
        @DRAW
        0;JMP

    // находим сдвиг, если нажата down
    (DOWN)
        @5296
        D=A 
        @R0 
        M=D 
        @DRAW
        0;JMP

    // отрисовка смайлика как в задании smile, но теперь не просто меняем адрес, но и записываем значение в память
    (DRAW)
        @16384
        D=A 
        @R0
        D=D+M
        @address
        M=D

        @previousEyesLine1
        M=D

        @7224
        D=A

        @address
        A=M 
        M=D 

        @32
        D=A
        @address
        M=M+D 
        D=M

        @previousEyesLine2
        M=D

        @7224
        D=A 

        @address
        A=M 
        M=D 

        @32
        D=A
        @address
        M=M+D 
        D=M

        @previousEyesLine3
        M=D

        @7224
        D=A 

        @address
        A=M 
        M=D 

        @32
        D=A
        @address
        M=M+D 

        @address
        A=M 
        M=0

        @32
        D=A
        @address
        M=M+D 

        @address
        A=M 
        M=0

        @32
        D=A
        @address
        M=M+D
        D=M

        @previousSmileLine1
        M=D 

        @24582
        D=A 
        @address
        A=M 
        M=D 

        @32
        D=A
        @address
        M=M+D 
        D=M

        @previousSmileLine2
        M=D 

        @14364
        D=A 
        @address
        A=M 
        M=D 

        @32
        D=A
        @address
        M=M+D 
        D=M

        @previousSmileLine3
        M=D 

        @4080
        D=A 
        @address
        A=M 
        M=D 

//(ﾉ◕ヮ◕)ﾉ*:･ﾟ✧(ﾉ◕ヮ◕)ﾉ*:･ﾟ✧
(END)
    @LOOP
    0;JMP