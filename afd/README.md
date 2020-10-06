## Datos
* Alumno: Jessica Elizabeth Bueno Sánchez
* Matricula: 170011
* Institución: Universidad Politécnica de San Luis Potosí
* Carrera: Ingeniería en Tecnologías de la Información
* Materia: Teoría Computacional
* Docente: Juan Carlos González Ibarra
## Objetivos
Con este programa se busca realizar un automata finito, es cual se maneja con estados y transiciónes, alfabeto y una cadena.
Las transiciones de los estados se definen por la generación de una respuesta a cadenas de entrada.
Para este programa evaluara en un alfabeto que contiene operaciones de suma, resta, multiplicación y división, por lo tanto
son números del 0 al 9 y los operadores +,-,*,/.

La matriz que se utilizara como base o regla es:

| Estado| Digitos | Operadores | Fin de cadena
| ------------- | ------------- | ------------- | ------------- |
| q0  | q1    | Error  | Error |
| q1  | Error | q2 | Error |
| q2  | qf    | Error | Error |
| qf  | Error | Error  | Aceptación |

Se utilizo el siguiente código:

** ADF **
Se utiliza para poder utilizar expresiones regulares dentro del código.
```
open System.Text.RegularExpressions 
```
Nos ayuda con la revisión del caracter. 
```
let caracter (character):int = 
    simbolo <- "" 
    FIN <- ""
    let mutable digito = "[0-9]"
    let mutable operador= "(\+|\-|\*|\/)"
    //comparamos si es digito o operador
    if Regex.IsMatch(character, digito) then
        simbolo <- "Digito"
        0 
    elif Regex.IsMatch(character, operador) then
        simbolo <- "Operador"
        1 
    elif character.Equals(FIN) then 
        2
    else 
        printf"Error no es valido el caracter %A"character
        4
```
Se basa  en la siguiente tabla de transiciones.
```
let tabla= [[1;"E";"E"];["E";2;"E"];[3;"E";"E"];["E";"E";"A"]]
```
Ayuda a revisar la cadena que se va a evaluar.
```
for character in cadena do
    let mutable estadosig = estado
    //llamamos al metodo para saber si es un caracter valido y el valor retornado se guarda en character
    characte <- caracter(string character)
    //guardamos en estado el valor obtenido en la tabla segun las coordenadas que recibio anteriormente
    estado <- tabla.[estado].[characte]
    if characte < 4   then 
        if estado = 4 then 
            printfn "|        %A      |     %A    |  %A |        %A        |" estadosig character simbolo estado
            body()
            
        contenido(estadosig, character, simbolo, estado)
```
## Poblemas y soluciónes del programa
Encontre problemas con la definición de la tabla de transiciones, para solucionarlo simplemente
se cambio E-->10 A-->11, en donde E es error y A es aceptación.
```
let tabla= [[1;10;10];[10;2;10];[3;10;10];[10;10;11]]
```
