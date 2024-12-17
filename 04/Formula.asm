// RAM[4] = (RAM[0] * 3 + (RAM[1] | RAM[2])) & !RAM[3] + 11

// RAM[0] * 3
@0
D = M      // D = RAM[0]
D = D + M  // D = RAM[0] * 2
D = D + M  // D = RAM[0] * 3

@12
M = D

// RAM[1] | RAM[2]
@1
D = M  // D = RAM[1]
@2
D = D | M  // D = (RAM[1] | RAM[2])

//RAM[0] * 3 + (RAM[1] | RAM[2])
@12
D = M + D
M = D

// !RAM[3]
@3 
D = M  // D = ((RAM[0] * 3 + (RAM[1] | RAM[2])) & RAM[3])
D = !D

// (RAM[0] * 3 + (RAM[1] | RAM[2])) & !RAM[3]
@12
D = M & D

// Добавление 11
@11        // A = 11
D = D + A  // D = ((RAM[0] * 3 + (RAM[1] | RAM[2])) & !RAM[3]) + 11

// Запись результата в RAM[4]
@4
M = D      // RAM[4] = D
