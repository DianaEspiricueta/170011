(*Nombre: Jessica Elizabeth Bueno Sánchez
Carrera: ITI
Matricula: 170011
Teoría computacional
Juan Carlos González
Universidad Politécnica de San Luis Potosí*)

(*Programa para aprender acerca de NFA en donde el expresión regular sea E(r)=a*ba*
esto quiere decir que a*.b.a*, en donde los "." son concatenaciones.*)

open System
open System.Text.RegularExpressions
let mutable simbolo=""
let mutable FIN=""
let mutable cont=0//auxiliar
//hacerle un for dentro para ver si 
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

 //solo muestra la linea que se repetira cada vez que la mandemos a llamar
//solo muestra la linea que se repetira cada vez que la mandemos a llamar
let body() = 
    printfn "+---------------+------------+-----------+------------------+"

//definicion de la funcion del encabezado
let encabezado() = 
    printfn "|  Edo. Actual  |  Caracter  |  Simbolo  |  Edo. Siguiente  |"
    body()

//definimos la funcion contenido donde guarda cada valor despues de encontrarlo en un ciclo
let contenido (estadosig, character, simbolo,estado) =  
    printfn "|        %A      |     %A     |  %A    |        %A        |" estadosig character simbolo estado
    body()

        
[<EntryPoint>]
let main argv = //matriz de transiciones segun elif NFA realizado
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


    
    let mutable estado = 0
    printfn """
     +-------------------------------------+
     |    Ingresa una cadena a evaluar     |
     +-------------------------------------+"""

    let cadena = System.Console.ReadLine() //entrada de teclado
    body() 
    encabezado()
    let mutable size=cadena.Length;//para poder utilizarlo en un if para impesión
   
    let mutable characte = 0 
    //recorrer la cadena
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

    0 // return an integer exit code







    (*if estadosig.Equals(1) && character.Equals("b")then
    estado<-4
        if estadosig.Equals(7) && character.Equals(FIN)then
    estado<-10
        if estadosig.Equals(4) && not(character.Equals("b"))then
    estado<-1
        if estadosig.Equals(10) && not(character.Equals(FIN))then
    estado<-7
    if estadosig.Equals(0) && not(character.Equals(FIN))then
    estado<-7*)
