//programa para realizar tablas de verdad
//con compuertas logicas

(*Nombre: Jessica Elizabeth Bueno Sánchez
Carrera: ITI
Matricula: 170011
Teoria computacional
Juan Carlos González
Universidad Polítecnica de San Luis Potosí*)

(*se hace un recorrido ya sea doble o simple para x y para y segun se necesite y estas ya mencionados
toman los valores de la lista de boleanos y el recorrido es de izq->der
para que no se omita ningun valor*)
let boleanos = [false;true]

//tablas de verdad de or
printfn "\n x \t y \t x o y"
printfn "------------------------"
for x in boleanos do
    for y in boleanos do
        printf" %A\t"x
        printf"%A\t"y
        printfn"%A"(x||y) //verdadero si cualquiera de los dos es verdadero
    
//tablas de verdad de and
printfn "\n x \t y \t x and y"
printfn "--------------------------"
for x in boleanos do
    for y in boleanos do
        printf" %A\t"x
        printf"%A\t"y
        printfn"%A"(x&&y)//verdadero solo si los dos elementos son verdaderos

//tablas de verdad de not
printfn "\n x \t x not y"
printfn "---------------------"
for x in boleanos do
        printf" %A\t"x
        printfn"%A"(not x)//cambia el valor de falso a verdadero y viceversa

//tablas de verdad de  ^
printfn "\n x \t y \t x not y"
printfn "------------------------"
for x in boleanos do
    for y in boleanos do
        printf" %A\t"x
        printf"%A\t"y
        printfn"%A"( not (x && y) && (x || y)) //  Verdadero si cualquiera de las expresiones (pero no ambas) es verdadera     
