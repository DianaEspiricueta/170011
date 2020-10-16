## Datos
* Alumno: Jessica Elizabeth Bueno Sánchez
* Matricula: 170011
* Institución: Universidad Politécnica de San Luis Potosí
* Carrera: Ingeniería en Tecnologías de la Información
* Materia: Teoría Computacional
* Docente: Juan Carlos González Ibarra
## Objetivos
Con este programa se busca el aprendizaje del manejo de los NFA, aprender a manejar sus transiciones asi como las restricciones que maneja.
El programa esta evaluado por E(r)=a *ba * en donde el alfabeto es {a,b}, al ser NFA se utiliza el elemento vacio y concatenaciones.

La matriz que se utilizara como base o regla es:

|Estado|  Vacío	| a | b |Fin de cadena|
| -------- | -------- | ------ | ------ | ------------ |
|q0|	q1|	E|	E|	E|
|q1|	q2,q4|	E|	E|	E|
|q2|	E|	q3|	E|	E|
|q3|	q4|	E|	E|	E|
|q4|	q5,q1|	E|	E|	E|
|q5|	E|	E|	q6|	E|
|q6|	q7|     E|	E|	E|
|q7|	q8,q10|	E|	E|	E|
|q8|	E|	q9|	E|	E|
|q9|	q10|	E|	E|	E|
|q10|	q7,q11|	E|	E|	E|
|q11|	E|	E|	E|	A|

Basada en


![alt text](https://github.com/upslp-teoriacomputacional/170011/blob/master/nfa/nfa.JPG)


**NFA**
Se utiliza para poder utilizar expresiones regulares dentro del código:
Este se utilizo para poder hacer uso de las expresiones regulares.
```
open System.Text.RegularExpressions 
```
Para la evaluación de los caracteres de la cadena.
```
let caracter (character):int = 
    simbolo <- "" 
    FIN <- ""
    let mutable a = "a"
    let mutable b= "b"
   
    //comparamos si es digito o operador
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
        printfn "|               Cadena No Valida  %A                        |"character
        printfn "+---------------+------------+-----------+------------------+"
        15
```
Matriz de transiciones sobre la que se trabaja.
```
let tabla = [[1;100;100;100];
                [2;100;100;100];
                [100;3;100;100];
                [4;100;100;100];
                [5;100;100;100];
                [100;100;6;100];
                [7;100;100;100];
                [8;100;100;100];
                [100;9;100;100];
                [10;100;100;100];
                [11;100;100;100];
                [100;100;100;110]]//cambiar el E-->100 A-->110
```
Para poder realizar las transiciones y trabajar caracter por caracter ingresado
```
for character in cadena do
        let mutable estadosig = estado
        //llamamos al metodo para saber si es un caracter valido y el valor retornado se guarda en character
        
        characte <- caracter(string character)

        estado <- tabla.[estado].[characte]
        
        if estadosig.Equals(0) && character.Equals("b") then //si el inicio es b 1-0
            estado <- 4
        //para saber a que parte del NFA va, si antes del b o después del b
        if cont.Equals(0)then
            if estadosig.Equals(1) && not(character.Equals("b")) then//recursividad de a* (primera a)
                estado <- 0
        elif cont.Equals(1) then
            if estadosig.Equals(1) && not(character.Equals("b")) then//recursividad de a* (segunda a)
                estado <- 7
        
        
        (*if estadosig.Equals(8) && not(character.Equals("b")) then//recursividad de a* (segunda a)
            estado <- 7*)
        if estadosig.Equals(7) && not(character.Equals("b"))then
            estado<-8
        if size.Equals(1) then//si termina la cadena manda al estado 11
            estado<-11
        

        size<-size-1//va restando al tamaño de la cadena
        if not(cadena.Contains("b")) && size.Equals(0) then//revisa que tenga una b concatenada
                  estado <- tabla.[0].[2]//busca el error
                  size<-100//se le asigna un numero al azar
        

        if characte < 15   then 
     
            if estado = 15 then 
                printfn "|        %A      |     %A    |  %A |        %A        |" estadosig character simbolo estado
                body()
                
            contenido(estadosig, character, simbolo, estado)

        if size.Equals(100)then//se utiliza el size<-100 para poder imprimir que hay un error en cadena
            printfn "|                  Cadena No Valida                         |"
            printfn "+---------------+------------+-----------+------------------+"
```


## Poblemas y soluciónes del programa
El principal problema que se tuvo son las transiciones, por lo que se procedio a realizar los automatas
dentro de la aplicación de JFLAP para poder entender la manera en la que las transiciones trabajaran.
Una vez que se realizo se procedio a obtener las transiciones y realización de la matriz.

Algunas transiciones con las que se debia aceptar ciertas cadenas no funcionaban por lo que se realizaron varias sentencias de if 
y asi poder evaluar esas situaciones.
