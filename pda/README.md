## Datos
* Alumno: Jessica Elizabeth Bueno Sánchez
* Matricula: 170011
* Institución: Universidad Politécnica de San Luis Potosí
* Carrera: Ingeniería en Tecnologías de la Información
* Materia: Teoría Computacional
* Docente: Juan Carlos González Ibarra
## Objetivos
Con este programa se busca realizar un automata de pila. Este debe de validar la expresion 
a*b* convertida a lenguaje libre de contexto es (anbn|n>=0).
La matriz que se utiliza es:
|Estado	|Vacío	|a	|b	|Fin de cadena|
|-------|-------|-------|-------|-------------|
|q0	|q1	|E	|E	|E|
|q1	|q2,q4	|E	|E	|E|
|q2	|E	|q3	|E	|E|
|q3	|q4	|E	|E	|E|
|q4	|q1,q5	|E	|E	|E|
|q5	|q6	|E	|E	|E|
|q6	|E	|E	|q7	|E|
|q7	|q8	|E	|E	|E|
|q8	|q5,q9	|E	|E	|E|
|q9	|E	|E	|E	|A|

Se utilizo el siguiente código:

Se utiliza para poder utilizar expresiones regulares dentro del código.
```
open System.Text.RegularExpressions 
```
Validar que caracter ingresa
```
if Regex.IsMatch(character, a) then
        simbolo <- "a"
        0
    elif Regex.IsMatch(character, b) then
        simbolo <- "b"
        cont<-cont+1
        1
    elif character.Equals(FIN) then 
        2
    else 
       //printf"Error no es valido el caracter %A"character
        printfn "|                           Cadena No Valida  %A                                  |"character
        printfn "+---------------+------------+-----------+------------------+---------------------+"
        Environment.Exit 1      //y termina el programa
        15
```
Tabla de transiciones
```
let tabla =    [[1;100;100;100];
                    [2;100;100;100];
                    [100;3;100;100];
                    [4;100;100;100];
                    [1;100;100;100];
                    [6;100;100;100];
                    [100;100;7;100];
                    [8;100;100;100];
                    [5;100;100;100];
                    [100;100;100;110];]//cambiar el E-->100 A-->110 
```
Recursividad de a
```
if cont.Equals(0)then
            if estadosig.Equals(1) && not(character.Equals("b")) then//recursividad de a* (primera a)
                estado <- 0
```
Recursividad de b
```
if estado.Equals(100)  then//si el estado es 100
            estado<-5               //vuelve a la recursividad
            auxb<-auxb+1        //aumenta el contador de b
            if(auxa-auxb)<0 then//si el contador a menos el b es menor a 0 significa que hay más b que a y eso es error
                estado<-100
            else                //si no
                vector.RemoveAt(auxa-auxb)//remueve un caracter
                //printfn"%A" vector

        if estado.Equals(100) && estadosig.Equals(5)then //sirve como una recursividad para b
            estado<-5
```
No se ingrese una a despues de b
```
if estado.Equals(6) && estadosig.Equals(5) && not(character.Equals("a")) then       //si tiene a despues de b es incorrecto
            printfn "|                              Cadena No Valida                                   |"
            printfn "+---------------+------------+-----------+------------------+---------------------+"
            Environment.Exit 1      //y termina el programa
        if estado.Equals(110) &&    (character.Equals("a")) then           // si es solo una a despues de b tambien lo marca como error
            printfn "|                               Cadena No Valida                                  |"
            printfn "+---------------+------------+-----------+------------------+---------------------+"
            Environment.Exit 1      //y termina el programa
```
Ingreso en la pila
```
vector.Add(character)//añade a la pila el caracter
            //printfn"%A" vector
            auxa<-auxa+1//aumenta el contador 
```
Remover de la pila
```
auxb<-auxb+1        //aumenta el contador de b
            if(auxa-auxb)<0 then//si el contador a menos el b es menor a 0 significa que hay más b que a y eso es error
                estado<-100
            else                //si no
                vector.RemoveAt(auxa-auxb)//remueve un caracter
                //printfn"%A" vector
```
Verificar si cumple con las condiciones de anbn
```
if auxa.Equals(auxb)  then//si tienen el mismo numero en el contador quiere decir que es correcto 
                printfn "|                             Cadena es valida                                    |"
                printfn "+---------------+------------+-----------+------------------+---------------------+"
            else        //si no, es incorrecto
                printfn "|                            Cadena no es valida                                  |"
                printfn "+---------------+------------+-----------+------------------+---------------------+"
```
