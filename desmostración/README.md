## Datos
* Alumno: Jessica Elizabeth Bueno Sánchez
* Matricula: 170011
* Institución: Universidad Politécnica de San Luis Potosí
* Carrera: Ingeniería en Tecnologías de la Información
* Materia: Teoría Computacional
* Docente: Juan Carlos González Ibarra
## Objetivos
Con este programa se pretende obtener aprendizaje acerca de las compuertas lógicas las cuales ayudan
a resolver algunas tablas de verdad, de esta manera se aprendera a utilizarlas mediante
la programación. Las que se utilizaron fueron las siguientes:

**OR**
Es verdadero si cualquiera de los dos es verdadero
```
for x in boleanos do
    for y in boleanos do
        printf" %A\t"x
        printf"%A\t"y
        printfn"%A"(x||y) 
```
**AND**
Es verdadero solo si los dos elementos son verdaderos.
```
for x in boleanos do
    for y in boleanos do
        printf" %A\t"x
        printf"%A\t"y
        printfn"%A"(x&&y)
```
**NOT**
Este cambia el valor de falso a verdadero y viceversa.
```
for x in boleanos do
        printf" %A\t"x
        printfn"%A"(not x)
```
**XOR (^)**
Es verdadero si cualquiera de las expresiones (pero no ambas) es verdadera
```
for x in boleanos do
    for y in boleanos do
        printf" %A\t"x
        printf"%A\t"y
        printfn"%A"( not (x && y) && (x || y))
```

## Poblemas y soluciónes del programa
El problema es que de entre las funciones de F# no se encuentra una para XOR. 
Para resolverlo se fijo en la definición para poder obtener el resultado con lo
que ya se conocia y a lo que si se tenia acceso. La definición dice que es verdadera cuando
solo una de ellas es verdadera entonces se utilizó:
```
 not (x && y) && (x || y)
```
Solamente una de condiciones tiene que ser verdadera entonces una de ellas se niega, la que se nego fue la operación
de and la cual si es verdadera la niega y viceversa. 
Esta se tiene que cumplir al igual que la siguiente condicion que se realizo con
otra compuerta or de ambos casos, este valor se toma automáticamente.  
