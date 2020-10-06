## Datos
- Alumno: Jessica Elizabeth Bueno Sánchez
- Matricula: 170011
- Institución: Universidad Politécnica de San Luis Potosí
- Carrera: Ingeniería en Tecnologías de la Información
- Materia: Teoría Computacional
- Docente: Juan Carlos González Ibarra
## Objetivos
Este programa pretende inicializar al programador en el lenguaje de F#, esto mediante la programación
de conjuntos algunas de las operaciones básicas y funciones las cuales se pueden utilizar en lo ya mencionado.
- Algunas de las funciones Básicas en conjuntos:
Definición, imprimirlo, pertenencia, transformación, eliminar, remover, copiar y agregar.
- La operaciones en conjuntos:
Unión, intersección, diferencia, diferencia simétrica, subconjunto y superconjunto.
### Comandos para las operaciones y funciones
***Definir*** 
```
    let A= Set.ofList [1;2;3;4;5]  //conjunto A
```
***Imprimrir***
```
    printfn "El conjunto A: %A" A
```
***Pertenencia***
```
    printfn("1 Pertenece a A: %A")(A.Contains 1) //verifica si 1 se encuentra dentro del conjunto
```
***Transformación***
```
    let A = [1;2;3;4;5]//definicion de una lista
    let conjuntoA =Set.ofList A//la cual se convierte a conjunto 
    printf"\nEl conjunto A es: %A" conjuntoA
```
***Eliminar***
```
    let A= Set.ofList [0;1;2;3;4;5]  //conjunto A
    printf "\nEl conjunto despues de borrar: "
    Set.iter (fun x -> printf " %O " x) (A.Remove 2)//funcion remove permite eliminar un elemento
```
***Remover***
```
    let A= Set.ofList [0;1;2;3;4;5]  //conjunto A
    printfn "\nEl conjunto limpio: %A" ((Set.union A B)-(Set.union B A))//limpiar todo el conjunto resta de la union de a y b
```
***Copiar***
```
    printf "Copiar.\nConjunto A: %A " A 
    printf "compara Conjunto B: %A "  ((Set.union A B)-(B-A))//union de A y B y se resta la diferencia simetrica de B
```
***Agregar***
```
    printf "\nAgregar.\nEl nuevo conjunto B: "
    Set.iter (fun x -> printf " %O " x) (B.Add 987) //funcion de add permitio agregar un nuevo elemento
```
***Unión***
```
    printf "\nLa union: "
    Set.iter (fun x -> printf " %O " x) (Set.union A B)//funcion de union para realizar la union de A y B
```
***Intersección***
```
    printf"\nLa interseccion: "
    Set.iter (fun x -> printf " %O" x) (Set.intersect A B)//funcion intersecr para obtener la interseccion de A y B
```
***Diferencia***
```
    printf"\nLa diferencia: "
    Set.iter (fun x -> printf " %O" x) (Set.difference A B)//difference permite obtener la diferencia de A y B
```
***Diferencia simétrica***
```
    printf"\nDiferencia simetrica: "
    Set.iter (fun x -> printf " %O" x) ((A-B)+(B-A))//se realiza la diferencia de A y B a la cual se le suma la diferencia de B y A
```
***Subconjunto***
```
    let B= Set.ofList [0;1;2;3;4;5;6;7;8;9]  //conjunto b
    let A= Set.ofList [1;2;3;4;5]  //conjunto A
    printf "\nEl subconjunto: %A" (Set.isSubset A B)//isSubset permite obtener si es un subconunto de otro
```
***Superconjunto***
```
    let B= Set.ofList [0;1;2;3;4;5;6;7;8;9]  //conjunto b
    let A= Set.ofList [1;2;3;4;5]  //conjunto A
    printfn "\nEl superconjunto: %A" (Set.isSuperset  A B)//obtener si es un superconjunto de otro funcion isSuperset
```
## Problemas y soluciones al programa
**- Eliminar un conjunto completo**
 _No podia utilizar las funciones definidas por lo que me dicidi a utilizar otras dos que ya sabia manejar:
 unión y diferencia (hice la unión de ambos y le reste la unión de ambos)._
 ```
    let A= Set.ofList [0;1;2;3;4;5]  //conjunto A
    printfn "\nEl conjunto limpio: %A" ((Set.union A B)-(Set.union B A))//limpiar todo el conjunto resta de la union de a y b
```
**- Copiar un conjunto**
 _No se cuenta con una función de copiado como tal por lo que utilice la union y la diferencia
 (es la diferencia de la union de ambos con la diferencia de el segundo menos el primero)._
 ```
    printf "Copiar.\nConjunto A: %A " A 
    printf "compara Conjunto B: %A "  ((Set.union A B)-(B-A))//union de A y B y se resta la diferencia simetrica de B
```
**- Diferencia simétrica**
 _No se cuenta con una funcion como tal por lo que procedí a realizar una suma de diferencias (el primero menos el segundo más
el segundo menos el primero)._
```
    printf"\nDiferencia simetrica: "
    Set.iter (fun x -> printf " %O" x) ((A-B)+(B-A))//se realiza la diferencia de A y B a la cual se le suma la diferencia de B y A
    printf"\nDiferencia simetrica: "
    Set.iter (fun x -> printf " %O" x) ((B-A)+(A-B))//permite obtener los resultados sin los números que comparten
    printf"\nDiferencia simetrica: "
    Set.iter (fun x -> printf " %O" x) ((A-C)+(C-A))//esto con cada conjunto
    printf"\nDiferencia simetrica: "
    Set.iter (fun x -> printf " %O" x) ((C-A)+(A-C))
