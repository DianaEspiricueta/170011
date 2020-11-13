(*Nombre: Jessica Elizabeth Bueno Sánchez
Carrera: ITI
Matricula: 170011
Teoría computacional
Juan Carlos González
Universidad Politécnica de San Luis Potosí*)

(*  a*b*    *)

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
        printfn "|                           Cadena No Valida  %A                                  |"character
        printfn "+---------------+------------+-----------+------------------+---------------------+"
        Environment.Exit 1      //y termina el programa
        15


//solo muestra la linea que se repetira cada vez que la mandemos a llamar
let body() = 
    printfn "+---------------+------------+-----------+------------------+---------------------+"

//definicion de la funcion del encabezado
let encabezado() = 
    printfn "|  Edo. Actual  |  Caracter  |  Simbolo  |  Edo. Siguiente  |       Pila          |"
    body()

//definimos la funcion contenido donde guarda cada valor despues de encontrarlo en un ciclo
let contenido (estadosig, character, simbolo,estado,vector) =  
    printfn "|        %A      |     %A     |  %A    |        %A          |  %A   \t   | " estadosig character simbolo estado vector
    body()

        
[<EntryPoint>]
let main argv = //matriz de transiciones segun elif NFA realizado
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

    let mutable auxa=0;//contador auxiliar de cuantas a se ingresaron
    let mutable auxb=0;//contador auxiliar de cuantas b se ingresaron
    let vector = ResizeArray<char>()//definicion del vector
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
        
        
        
        //recursividad de a
        if cont.Equals(0)then
            if estadosig.Equals(1) && not(character.Equals("b")) then//recursividad de a* (primera a)
                estado <- 0
            vector.Add(character)//añade a la pila el caracter
            //printfn"%A" vector
            auxa<-auxa+1//aumenta el contador

        //printfn"%A %A %A"estado estadosig character
        //recursividad de b
        if estado.Equals(100)  then//si el estado es 100
            estado<-5               //vuelve a la recursividad
            auxb<-auxb+1        //aumenta el contador de b
            if(auxa-auxb)<0 then//si el contador a menos el b es menor a 0 significa que hay más b que a y eso es error
                estado<-100
            else                //si no
                vector.RemoveAt(auxa-auxb)//remueve un caracter
                //printfn"%A" vector

        //fin de cadena
        if size.Equals(1) then //si solo queda un elemento
            estado<-110 //va estado valido

        if estado.Equals(100) && estadosig.Equals(5)then //sirve como una recursividad para b
            estado<-5
        
        if estado.Equals(6) && estadosig.Equals(5) && not(character.Equals("a")) then       //si tiene a despues de b es incorrecto
            printfn "|                              Cadena No Valida                                   |"
            printfn "+---------------+------------+-----------+------------------+---------------------+"
            Environment.Exit 1      //y termina el programa
        if estado.Equals(110) &&    (character.Equals("a")) then           // si es solo una a despues de b tambien lo marca como error
            printfn "|                               Cadena No Valida                                  |"
            printfn "+---------------+------------+-----------+------------------+---------------------+"
            Environment.Exit 1      //y termina el programa

        

        if characte < 15   then 
     
            if estado = 15 then 
                printfn "|        %A      |     %A    |  %A |        %A        |" estadosig character simbolo estado
                body()
                
            contenido(estadosig, character, simbolo, estado,vector)
            
       

        if size.Equals(100) || estadosig.Equals(100)  then//se utiliza el size<-100 para poder imprimir que hay un error en cadena
            printfn "|                             Cadena No Valida                                    |"
            printfn "+---------------+------------+-----------+------------------+---------------------+"
            if auxa.Equals(auxb)  then  //si tienen el mismo numero en el contador quiere decir que es correcto 
                printfn "|                             Cadena es valida                                    |"
                printfn "+---------------+------------+-----------+------------------+---------------------+"
            else            //si no, es incorrecto
                printfn "|                           Cadena no es valida                                   |"
                printfn "+---------------+------------+-----------+------------------+---------------------+"
            Environment.Exit 1      //y termina el programa
        size<-size-1
        if size.Equals(0) || estado.Equals(110) then        //si ya no quedan caracteres y es estado valido se va a final
            printfn "|                              Fin de cadena                                      |"
            printfn "+---------------+------------+-----------+------------------+---------------------+"
            if auxa.Equals(auxb)  then//si tienen el mismo numero en el contador quiere decir que es correcto 
                printfn "|                             Cadena es valida                                    |"
                printfn "+---------------+------------+-----------+------------------+---------------------+"
            else        //si no, es incorrecto
                printfn "|                            Cadena no es valida                                  |"
                printfn "+---------------+------------+-----------+------------------+---------------------+"
            vector |> Seq.iter (fun x -> printf "%A;" x)
            Environment.Exit 1      //y termina el programa
    
