 // Conjuntos en f#
(*Programa para realizar diferentes operaciones de 
conjuntos como en matemáticas*)

(*Nombre: Jessica Elizabeth Bueno Sánchez
Carrera: ITI
Matricula: 170011
Teoria computacional
Juan Carlos González
Universidad Polítecnica de San Luis Potosí*)

//definición de los conjuntos
namespace conjuntos
let A= Set.ofList [1;2;3;4;5]  //conjunto A
let B= Set.ofList [3;4;5;6;7]  //conjunto B
let C=Set.empty                //conjunto C

printfn "El conjunto A: %A" A
printfn "El conjunto B: %A" B
printfn "El conjunto C: %A" C
(*printf, printfn son las funciones que imprimen los
resultados*)

//pertenencia
let pertenencia=
    printfn("1 Pertenece a A: %A")(A.Contains 1) //verifica si 1 se encuentra dentro del conjunto
    printf("10 Pertenece a A: %A")(A.Contains 10)//imprime true si lo encuentra y false en caso contrario

//Convertir a un conjunto
let convertir=
    let A = [1;2;3;4;5]//definicion de una lista
    let conjuntoA =Set.ofList A//la cual se convierte a conjunto 
    printf"\nEl conjunto A es: %A" conjuntoA
    let B = [3;4;5;6;7]
    let conjuntoB =Set.ofList B
    printf"\nEl conjunto B es: %A" conjuntoB
    let C=Seq.toList "Hola mundo"//se define una lista que contiene la frase hola mundo
    let conjuntoC = Set.ofList  C//de la lista se convierte a conjunto
    printf"\nEl conjunto C es: %A" conjuntoC

//eliminar un elemento del conjuntolimpiar set
let eliminar=
    let A= Set.ofList [0;1;2;3;4;5]  //conjunto A
    printf "\nEl conjunto despues de borrar: "
    Set.iter (fun x -> printf " %O " x) (A.Remove 2)//funcion remove permite eliminar un elemento

//eliminar todos los elementos del conjunto
let limpiarSet =
    let A= Set.ofList [0;1;2;3;4;5]  //conjunto A
    printfn "\nEl conjunto limpio: %A" ((Set.union A B)-(Set.union B A))//limpiar todo el conjunto resta de la union de a y b

//copiar conjunto
let copiar =
    printf "Copiar.\nConjunto A: %A " A 
    printf "compara Conjunto B: %A "  ((Set.union A B)-(B-A))//union de A y B y se resta la diferencia simetrica de B
    

//Agregar un elemento
let agregar=
    printf "\nAgregar.\nEl nuevo conjunto B: "
    Set.iter (fun x -> printf " %O " x) (B.Add 987) //funcion de add permitio agregar un nuevo elemento

(*Operaciones de conjuntos*)

//Union de conjuntos
let union=
    printf "\nLa union: "
    Set.iter (fun x -> printf " %O " x) (Set.union A B)//funcion de union para realizar la union de A y B
    printf "\nLa union: "
    Set.iter (fun x -> printf " %O " x) (A + B)//además se puede con la suma de estos

//Intersección de conjuntos
let interseccion=
    printf"\nLa interseccion: "
    Set.iter (fun x -> printf " %O" x) (Set.intersect A B)//funcion intersecr para obtener la interseccion de A y B

//Diferencia de conjuntos
let diferencia=
    printf"\nLa diferencia: "
    Set.iter (fun x -> printf " %O" x) (Set.difference A B)//difference permite obtener la diferencia de A y B
    printf"\nLa diferencia: "
    Set.iter (fun x -> printf " %O" x) (A - B)//pero tambien se puede si se realiza la resta

//Diferencia simetrica de conjuntos
let DSimetrica=
    printf"\nDiferencia simetrica: "
    Set.iter (fun x -> printf " %O" x) ((A-B)+(B-A))//se realiza la diferencia de A y B a la cual se le suma la diferencia de B y A
    printf"\nDiferencia simetrica: "
    Set.iter (fun x -> printf " %O" x) ((B-A)+(A-B))//permite obtener los resultados sin los números que comparten
    printf"\nDiferencia simetrica: "
    Set.iter (fun x -> printf " %O" x) ((A-C)+(C-A))//esto con cada conjunto
    printf"\nDiferencia simetrica: "
    Set.iter (fun x -> printf " %O" x) ((C-A)+(A-C))
    

//subconjunto de conjuntos
let subconjunto=
    let B= Set.ofList [0;1;2;3;4;5;6;7;8;9]  //conjunto b
    let A= Set.ofList [1;2;3;4;5]  //conjunto A
    printf "\nEl subconjunto: %A" (Set.isSubset A B)//isSubset permite obtener si es un subconunto de otro
    printf "\nEl subconjunto: %A" (Set.isSubset B A)//se obtiene true o false por medio de comparación

//Superconjunto de conjuntos
let superconjunto=
    let B= Set.ofList [0;1;2;3;4;5;6;7;8;9]  //conjunto b
    let A= Set.ofList [1;2;3;4;5]  //conjunto A
    printfn "\nEl superconjunto: %A" (Set.isSuperset  A B)//obtener si es un superconjunto de otro funcion isSuperset
    printfn "El superconjunto: %A" (Set.isSuperset B A)//respuesta por medio de true o false