//Programa para aprender acerca de AFD

(*Nombre: Jessica Elizabeth Bueno Sánchez
Carrera: ITI
Matricula: 170011
Teoria computacional
Juan Carlos González
Universidad Polítecnica de San Luis Potosí*)
open System 
open System.Text.RegularExpressions
let mutable simbolo=""
let mutable FIN=""
//definición de la funcion caracter
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

//MAIN
[<EntryPoint>]
let main argv =
   //tabla de transiciones del automata AFD creado 
   //let tabla= [[1;"E";"E"];["E";2;"E"];[3;"E";"E"];["E";"E";"A"]] 
   let tabla = [ [1;10;10];[10;2;10];[3;10;10];[10;10;11]]//cambiar el E-->10 A-->11
   
   let mutable estado = 0
   printfn """
    +-------------------------------------+
    |    Ingresa una cadena a evaluar     |
    +-------------------------------------+"""
   let cadena = System.Console.ReadLine() //entrada de teclado
   body() 
   encabezado()
   let mutable characte = 0 
   //recorrer la cadena
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
//al concluir si el estado no es 3 que es el de aceptacion imprimimos cadena no valida
   if estado <> 3 then 
            printfn """|                    Cadena NO Valida                       |
                       +---------------+------------+-----------+------------------+"""
   //si el estado 3 es una cadena de aceptación
   if estado = 3 && characte < 4 then 
            printfn "|      %A   |                 |Final de cadena|              |" estado
            body()
            printfn "|                     Cadena Valida                         |"
            printfn "+---------------+------------+-----------+------------------+"
   0 //return 

