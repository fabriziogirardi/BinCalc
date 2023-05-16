# BinCalc
 Proyecto de una calculadora binaria hecha en C#.


## Funcionalidad y uso
Esta calculadora es una herramienta en desarrollo, para facilitar la comparaci�n
de resultados en c�lculos hechos a mano sobre interpretaciones de binarios en
en diferentes sistemas, o la representaci�n binaria de n�meros en los diversos
sistemas. Los sistemas soportados son:
- **BSS** (Binario sin signo)
- **BCS** (Binario con signo)
- **CA1** (Complemento a 1)
- **CA2** (Complemento a 2)
- **EX2** (Exceso a 2, tambien llamado exceso a la mitad)
- **EX2-1** (Exceso a la mitad menos 1, usado en IEEE753) _Pr�ximamente_

***
> Dado que la herramienta est� a�n en desarrollo, se pueden presentar diversos
errores o resultados inesperados a la hora de realizar alguna conversi�n o
c�lculo. De ser as�, se agradece reportar el error en la secci�n de _Issues_ del
repositorio, para poder  hacer un seguimiento de la incidencia y corregirla en
futuras versiones de la aplicaci�n.
***

Actualmente la herramienta permite realizar las siguientes operaciones:
- <b><ins>Conversi�n de entero a binario</ins></b>: Mediante esta funci�n es 
posible convertir enteros a su representaci�n binaria. La calculadora brindar�
el resultado binario en diversas interpretaciones en caso de que dicho n�mero
se pueda mostrar en ellas, o un mensaje de error en caso contrario.
- <b><ins>Conversi�n de binario a entero</ins></b>: Esta funci�n permite realizar
la inversa de la funci�n anterior, es decir, recibe un n�mero binario y lo
convierte a entero en cada una de las interpretaciones posibles.

Utilidades pr�ximas a ser realizadas:
- C�lculo de binarios en punto fijo
- C�lculo de binarios en punto flotante
- Normalizacion simple, bit impl�cito, y IEE754
- Rango y resoluci�n