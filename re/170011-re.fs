// Programa de expresiones regulares

(*Nombre: Jessica Elizabeth Bueno Sánchez
Carrera: ITI
Matricula: 170011
Teoria computacional
Juan Carlos González
Universidad Polítecnica de San Luis Potosí*)

(*Como dato
para ingresar nuevos elementos a la lista se utilizo
tokens <- tokens @ [["INTEGER";word] ]  
para concatenar lo que ya habia en la lista con lo nuevo a ingresar*)

open System
open System.Text.RegularExpressions //para expresiones regulares

[<EntryPoint>]
let main argv =
    let  mutable tokens=[];  //lista vacia
    let source_code="int VALOR + 14;".Split();  //convierte en una lista de palabras

    for word in source_code do

        //elif re.match("[a-z]", word) or re.match("[A-Z]", word)
        if (word.Equals("str")||word.Equals("int")||word.Equals("bool"))then //revisa si es datatype 
            tokens <- tokens @ [["DATATYPE";word]] 

        //elif (Regex.IsMatch("[a-z]",word) || Regex.IsMatch("[A-Z]",word)) then //revisa que solo sea una palabra
        elif (Regex.IsMatch(word, "^[a-zA-Z]+$")) then //revisa que solo sea una palabra
            tokens <- tokens @ [["IDENTIFIER";word] ]

        elif (Regex.IsMatch(word,"(\+|\-|\*|\/|\%|\=)"))then//verificar que sea un operador
            tokens <- tokens @ [["OPERATOR";word] ]

        elif (Regex.IsMatch(word,"[0-9]"))then//verifica que sea un numero
            
            if (word.EndsWith(";"))then //si lo es verifica que termine con el caracter de finalización de linea ;
                tokens <- tokens @ [["INTEGER";word] ]  
                tokens <- tokens @ [["END_STATEMENT";";"] ]
            else
                tokens <-tokens @ [["INTEGER";word] ]
    printfn"%A" tokens

    (*let variablePROLOG(w:string)=
        let mutable waux=w.[0]
        if (Char.IsLetter(waux) && waux.Equals(Char.IsUpper(waux)) || waux.Equals("_") )then
            printf""
            //w <- w.[1..(w.Length-1)]
            while (w &&(Char.IsNumber waux || waux.Equals("_")) ) do
                //w <- w.[1..(w.Length-1)]
     *)    
            
        
    0 // return an integer exit code
    (*
    ^ inicio de la cadena
    [] conjunto de caracteres
    \+ una vez o mas
    $ final de la cuerda
    ^ y $ necesario porque desea validar toda la cadena, no parte de la cadena
    @ concatenar dos listas
    *)
