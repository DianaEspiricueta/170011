## Datos
* Alumno: Jessica Elizabeth Bueno Sánchez
* Matricula: 170011
* Institución: Universidad Politécnica de San Luis Potosí
* Carrera: Ingeniería en Tecnologías de la Información
* Materia: Teoría Computacional
* Docente: Juan Carlos González Ibarra

## Objetivos
El objetivo de este programa es hacer una Maquina de Turing
para simular una división, la division se hace con números 
en base unaria. la manera en la que se vera seria:
3/2 = 111/11
El resultado de esto seria:
3/2=111/11=1b1
La matriz de transiciones que utilice es:
|Estado|  Lee  | Escribe | Dirección | Estado sig |
| -------- | -------- | ------ | ------ | ------------ |
|s1|	1|	1|	right|	s1|
|s1|	/|	/|	right|	s1|
|s1|	b|	=|	left|	s2|
|s2|	1|	1|	left|	s2|
|s2|	/|	/|	right|	s3|
|s3|	x|	x|	right|	s3|
|s3|	=|	=|	right|	s7|
|s3|	1|	x|	left|	s4|
|s4|	1|	1|	left|	s4|
|s4|	/|	/|	left|	s4|
|s4|	x|	x|	left|	s4|
|s4|	D|	D|	right|	s5|
|s4|	b|	b|	right|	s5|
|s5|	1|	D|	right|	s6|
|s6|	1|	1|	right|	s6|
|s6|	/|	/|	right|	s3|
|s7|	1|	1|	right|	s7|
|s7|	b|	1|	left|	s8|
|s8|	1|	1|	left|	s8|
|s8|	=|	=|	left|	s8|
|s8|	x|	1|	left|	s8|
|s8|	/|	/|	left|	s9|
|s9|	1|	1|	right|	s13|
|s9|	D|	D|	right|	s10|
|s10|	1|	1|	right|	s10|
|s10|	=|	=|	right|	s10|
|s10|	/|	/|	right|	s10|
|s10|	b|	B|	right|	s11|
|s11|	b|	b|	right|	s12|
|s13|	1|	1|	right|	s13|
|s13|	=|	=|	right|	s13|
|s13|	/|	/|	right|	s13|
|s13|	b|	B|	right|	s14|
|s14|	b|	1|	right|	s12|

Basada en:

![alt text](https://github.com/upslp-teoriacomputacional/170011/blob/master/mt/Maquina.JPG)

## Código

Función para el barrido de la cinta
* estado: estado
* blank: estapacion en blanco
* rules: reglas
* cinta: la división a realizar
* final: s final
* pos: posición inicial
```
let turing_M (estado,blank,rules:list<list<string>>,cinta:list<string>,final,pos) =
```
Como se llama a la funcion es de la siguiente manera:
```
turing_M ("s1","b",rules,["1";"1";"/";"1";"1"],"s12",0)
```
Realizar impresiones de errores
```
exception Error of string //error
raise(Error("Se inicializa mal la posición"))
```
Variables que se van a editar conforme se va ejecutando 
```
let mutable st=estado//inicializa el estado tomando el valor
let mutable pos=pos//posición
let mutable cinta=cinta//cinta
```
Verificar si:
* esta vacia
* la posicion es menor a 0
* la posicion es mayor o igual a la cinta o menor a 0
```
if cinta.IsEmpty then//si la cinta esta vacia
	cinta<-[blank]//agrega el blanck
if pos<0 then//si la posición es menor a 0
        pos<-pos+cinta.Length//se toma el valor de la posición mas el tamaño de la cinta
if pos>=cinta.Length || pos<0 then//si la posicion es mayor o igual  al de la cinta o menor a 0
        raise(Error("Se inicializa mal la posición")) 
```
Recorrer las transiciones
```
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
```
## Problemas
Al realizar el programa no habia utilizado una cinta auxiliar por lo que
1)no escribir nada.
Después procedí a escribir sobre la misma cinta, pero creo que no lo realizaba bien por lo que
2) realizaba cosas que no deberia,
procedí a utilizar una cinta auxiliar para poder escribir sobre ella y fuera de donde obtenia
los nuevos valores. 
