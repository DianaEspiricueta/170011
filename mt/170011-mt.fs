(*Alumno: Jessica Elizabeth Bueno Sánchez
Matricula: 170011
Institución: Universidad Politécnica de San Luis Potosí
Carrera: Ingeniería en Tecnologías de la Información
Materia: Teoría Computacional
Docente: Juan Carlos González Ibarra*)

(*La manera en la que se leen las reglas es la siguiente
["s2";"1";"1";"left";"s2"];
esta en s2, lee un 1, escribe un 1 y va a la izquierda hacia s2*)

open System

open System.Collections.Generic

exception Error of string //exepciones
//función para recorrer la cinta
let turing_M (estado,blank,rules:list<list<string>>,cinta:list<string>,final,pos) =
    //variables que cambian su valor
    let mutable st=estado
    let mutable pos=pos
    let mutable cinta=cinta
    //si esta vacia se le pone un vacío
    if cinta.IsEmpty then
        cinta<-[blank]
    //si la posicion es menor a 0 
    if pos<0 then
        pos<-pos+cinta.Length//se le suma el tamaño de la cinta
    //si es mayor al tamaño de la cinta esta mal
    if pos>=cinta.Length || pos<0 then
        raise(Error("Se inicializa mal la posición"))

    //rules = dict(((s0, v0), (v1, dr, s1)) for  (s0, v0, v1, dr, s1) in rules)
    //let dict = new Dictionary<string, string>()
    let mutable aux=true//ayuda con el while

    while aux do//mientras sea true se ejecuta
        let mutable direc=""
        let mutable s1=""
        let mutable v1=""

        printf"%A\t"st//imprime el estado
        //imprime toda la cinta
        for i=0 to cinta.Length-1 do
            if i.Equals(pos) then
                printf "[%A] " cinta.[i]
            else
                printf " %A  " cinta.[i]
        printfn " "
        //si esta en el estado final
        if st.Equals(final)then
            aux<-false//manda un false al while
        let mutable noEsta:bool=true
        //revisa eregla por regla para saber si se encuentra la que esta "leyendo"
        for r in rules do
            //printfn"%A %A %A"st r cinta.[pos]
            if st.Equals(r.[0]) && cinta.[pos].Equals(r.[1])then
                noEsta<-false
                //toma los valores de la regla
                direc<-r.[3]
                s1<-r.[4]
                v1<-r.[2]
                //printfn"%A %A %A %A"noEsta direc s1 v1
                //let mutable cintaxu=[]
                //cintaxu<-cintaxu @ [v1]

        //si no esta manda false al while
        if noEsta then
            aux<-false
        let mutable cintaxu=[]//cinta auxiliar
        //reccore la cinta nuevamente para poder sobrescribirla
        for i=0 to cinta.Length-1 do
            if i.Equals(pos)then
                cintaxu<-cintaxu @ [v1] //coloca el nuevo valor
            else
                cintaxu<-cintaxu @ [cinta.[i]]//si no es igual a la posición se coloca el que ya estaba
        cinta<-cintaxu//lo agrega a la cinta ya existente
        
        if direc.Equals("left")then//si es a la izquierda 
            if pos>0 then//y la posicion es mayor a 0
                pos<-pos-1//se le resta 1
            else//si es menor a 0
                 cinta <- [blank] @ cinta//se le coloca al inicio un vacio
        if direc.Equals("right")then//si va  a la derecha
            pos<-pos+1//le suma 1
            if pos >= cinta.Length then//si la posicion es igual o mayor al tamaño de la cinta
                cinta <- cinta @ [blank]//se le coloca un vacio al final
        st<-s1



[<EntryPoint>]
let main argv =
    //reglas de transiciones
    let reglas = [   ["s1";"1";"1";"right";"s1"];
                ["s1";"/";"/";"right";"s1"];
                ["s1";"b";"=";"left";"s2"];
                ["s2";"1";"1";"left";"s2"];
                ["s2";"/";"/";"right";"s3"];
                ["s3";"x";"x";"right";"s3"];
                ["s3";"=";"=";"right";"s7"];
                ["s3";"1";"x";"left";"s4"];
                ["s4";"1";"1";"left";"s4"];
                ["s4";"/";"/";"left";"s4"];
                ["s4";"x";"x";"left";"s4"];
                ["s4";"D";"D";"right";"s5"];
                ["s4";"b";"b";"right";"s5"];
                ["s5";"1";"D";"right";"s6"];
                ["s6";"1";"1";"right";"s6"];
                ["s6";"/";"/";"right";"s3"];
                ["s7";"1";"1";"right";"s7"];
                ["s7";"b";"1";"left";"s8"];
                ["s8";"1";"1";"left";"s8"];
                ["s8";"=";"=";"left";"s8"];
                ["s8";"x";"1";"left";"s8"];
                ["s8";"/";"/";"left";"s9"];
                ["s9";"1";"1";"right";"s13"];
                ["s9";"D";"D";"right";"s10"];
                ["s10";"1";"1";"right";"s10"];
                ["s10";"=";"=";"right";"s10"];
                ["s10";"/";"/";"right";"s10"];
                ["s10";"b";"B";"right";"s11"];
                ["s11";"b";"b";"right";"s12"];
                ["s13";"1";"1";"right";"s13"];
                ["s13";"=";"=";"right";"s13"];
                ["s13";"/";"/";"right";"s13"];
                ["s13";"b";"B";"right";"s14"];
                ["s14";"b";"1";"right";"s12"];]

    turing_M ("s1","b",reglas,["1";"1";"1";"/";"1";"1"],"s12",0)//llamado de la función
    0 // return an integer exit code
