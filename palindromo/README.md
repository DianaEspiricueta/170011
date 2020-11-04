## Datos                                                                                                           
* Alumno: Jessica Elizabeth Bueno Sánchez
* Matricula: 170011
* Institución: Universidad Politécnica de San Luis Potosí
* Carrera: Ingeniería en Tecnologías de la Información
* Materia: Teoría Computacional
* Docente: Juan Carlos González Ibarra

## Objetivos
El objetivo de este programa era que al tener una palabra esta se evaluara para
saber si era un palíndromo o no, en caso de que lo fuera esta se comenzaba a evaluar 
de letra por letra y se metia dentro
de un vector el cual al llegar a la mitad se volvia a vaciar el vector.

### Código
Se definen las variables que se utilizaran a lo largo del programa.
```
    let vector = ResizeArray<char>()//definicion del arreglo
    let palindromo="anitalavalatina";//palindromo que se escribe todo junto
    let contador=palindromo.Length;//obtener el tamaño de la cadena del palindromo
    printfn "contador %A" contador//imprime como auxiliar para verificación
    let mutable auxiliar=0; 
    let mutable auxiliar2=0;
    let mutable contador2=0; 
```
Convertí en un arreglo para poder verificar si era un palíndromo
```
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
```
Si es el contador de los que son iguales es igual al auxiliar que ayudaba a conocer la mitad del programa
se considera que es un palíndromo. 
```
if contador2.Equals(auxiliar2)then//si el contador es igual al auxiliar2 quiere decir que es palindromo
        printfn"ES UN PALINDROMO"
```
Se va tomando de letra por letra y se guarda en un vector de caracteres.
```
or i = 0 to auxiliar-1 do  //para evaluar los caracteres
            vector.Add(palindromo.[i])//se le agrega el caracter al vector
            printfn"%A" vector
```
Cuando termina de guardarse significa que llego a la mitad de la cadena y procede a quitar los
caracterse desde la ultima hasta la primera.
```
//eliminar los caracteres del vector
        for i = 0 to auxiliar-1 do  
            vector.RemoveAt((auxiliar-1)-i)//elimina el ultimo elemento del vector
            printfn"%A"vector
```
Se imprime el vector de la siguiente manera
```
vector |> Seq.iter (fun x -> printf "%A;" x) 
```
En caso de no ser un palíndromo se imprime un mensaje y sale del programa.
```
else
        printfn"NO ES UN PALINDROMO"
```
