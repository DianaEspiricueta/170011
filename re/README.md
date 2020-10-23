## Datos
* Alumno: Jessica Elizabeth Bueno Sánchez
* Matricula: 170011
* Institución: Universidad Politécnica de San Luis Potosí
* Carrera: Ingeniería en Tecnologías de la Información
* Materia: Teoría Computacional
* Docente: Juan Carlos González Ibarra

## Objetivos
Este programa es acerca de las expresiones regulares o regex, las cuales 
son una serie de carácteres que forman un patrón, normalmente representativo 
de otro grupo de carácteres mayor, de tal forma que podemos comparar el patrón 
con otro conjunto de carácteres para ver las coincidencias.
En este programa se evaluara una caden en donde se tiene tipo de dato, el identificador,
operadores y números de resultado, asi como la finalización de la cadena que es
utilizado como finalización de linea en algunos lenguajes de programación.
A continuación se presenta el código.

**Código**
Para poder utilizar las expresiones regulares:
```
open System.Text.RegularExpressions 
```
Definición de variables:
```
let  mutable tokens=[];  //lista vacia
let source_code="int VALOR + 14;".Split();  //convierte en una lista de palabras
```
For en el cual se evalua la cadena source_code
```
for word in source_code do
```
Lo que se encuentra dentro de for es lo siguiente:
*Se evalua si es un datatype*
```
if (word.Equals("str")||word.Equals("int")||word.Equals("bool"))then //revisa si es datatype 
            tokens <- tokens @ [["DATATYPE";word]] 
```
*se evalua si es un identificador*
```
elif (Regex.IsMatch(word, "^[a-zA-Z]+$")) then //revisa que solo sea una palabra
            tokens <- tokens @ [["IDENTIFIER";word] ]
```
*Se evalua si es un operador*
```
elif (Regex.IsMatch(word,"(\+|\-|\*|\/|\%|\=)"))then//verificar que sea un operador
            tokens <- tokens @ [["OPERATOR";word] ]
```
*O si es un número*
```
elif (Regex.IsMatch(word,"[0-9]"))then//verifica que sea un numero
            
            if (word.EndsWith(";"))then //si lo es verifica que termine con el caracter de finalización de linea ;
                tokens <- tokens @ [["INTEGER";word] ]  
                tokens <- tokens @ [["END_STATEMENT";";"] ]
            else
                tokens <-tokens @ [["INTEGER";word] ]
```
La impresión de la lista:
```
printfn"%A" tokens
```
Su salida es la siguiente:
```
[["DATATYPE"; "int"]; ["IDENTIFIER"; "VALOR"]; ["OPERATOR"; "+"];["INTEGER"; "14;"]; ["END_STATEMENT"; ";"]]
```
## Poblemas al programar
La última parte del código no se tenia muy clara en cuanto a como solucionarlo
para este lenguaje por lo que tome la desición de no realizarlo.
