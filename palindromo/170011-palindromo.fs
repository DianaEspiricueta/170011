// Learn more about F# at http://fsharp.org
(*
* Alumno: Jessica Elizabeth Bueno Sánchez
* Matricula: 170011
* Institución: Universidad Politécnica de San Luis Potosí
* Carrera: Ingeniería en Tecnologías de la Información
* Materia: Teoría Computacional
* Docente: Juan Carlos González Ibarra
*)
open System

[<EntryPoint>]
let main argv =
    let vector = ResizeArray<char>()//definicion del arreglo
    let palindromo="anitalavalatina";//palindromo que se escribe todo junto
    let contador=palindromo.Length;//obtener el tamaño de la cadena del palindromo
    printfn "contador %A" contador//imprime como auxiliar para verificación
    let mutable auxiliar=0; 
    let mutable auxiliar2=0;
    let mutable contador2=0;
    

    //REVISAR SI ES PALINDROMA O NO
    let arreglo=palindromo.ToCharArray();//convierte a un arreglo

    if(contador%2).Equals(0)then//si es par
        auxiliar2<-(arreglo.Length-1)/2//toma el valor de en medio
        
    elif(contador%2).Equals(1)then//si es impar
        auxiliar2<-(((arreglo.Length-1)/2)+1)-1//toma el valor medio
    //revisar el ultimo elemento con el primero y asi sucesivamente 
    for i=0 to auxiliar2-1 do
        if(arreglo.[i].Equals(arreglo.[(arreglo.Length-1)-i]))then//si es igual
            contador2<-contador2+1;//se aumenta el contador


    if contador2.Equals(auxiliar2)then//si el contador es igual al auxiliar2 quiere decir que es palindromo
        printfn"ES UN PALINDROMO"

        //se guarda en un vector
        if(contador%2).Equals(0)then//saber si es par el numero de caracteres
            //printfn"Es par"
            auxiliar<-contador/2//dividir hasta donde debe hacerse
            //printfn "contador %A" auxiliar//impresion auxiliar
        elif(contador%2).Equals(1)then//o saber si es impar el numero de caracteres
            //printfn"Es impar"
            auxiliar<-(contador/2)+1//dividir hasta donde debe hacerse
            //printfn "contador %A" auxiliar//impresion auxiliar

          
        for i = 0 to auxiliar-1 do  //para evaluar los caracteres
            vector.Add(palindromo.[i])//se le agrega el caracter al vector
            printfn"%A" vector

        vector |> Seq.iter (fun x -> printf "%A;" x)//impresion del vector
        printfn""

        //eliminar los caracteres del vector
        for i = 0 to auxiliar-1 do  
            vector.RemoveAt((auxiliar-1)-i)//elimina el ultimo elemento del vector
            printfn"%A"vector

        vector |> Seq.iter (fun x -> printf "%A;" x)

    else
        printfn"NO ES UN PALINDROMO"

    

    0 // return an integer exit code
