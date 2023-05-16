# BinCalc
 Proyecto de una calculadora binaria hecha en C#.


## Funcionalidad y uso
Esta calculadora es una herramienta en desarrollo, para facilitar la comparación
de resultados en cálculos hechos a mano sobre interpretaciones de binarios en
en diferentes sistemas, o la representación binaria de números en los diversos
sistemas. Los sistemas soportados son:
- **BSS** (Binario sin signo)
- **BCS** (Binario con signo)
- **CA1** (Complemento a 1)
- **CA2** (Complemento a 2)
- **EX2** (Exceso a 2, tambien llamado exceso a la mitad)
- **EX2-1** (Exceso a la mitad menos 1, usado en IEEE753) _Próximamente_

***
> Dado que la herramienta está aún en desarrollo, se pueden presentar diversos
errores o resultados inesperados a la hora de realizar alguna conversión o
cálculo. De ser así, se agradece reportar el error en la sección de _Issues_ del
repositorio, para poder  hacer un seguimiento de la incidencia y corregirla en
futuras versiones de la aplicación.
***

Actualmente la herramienta permite realizar las siguientes operaciones:
- <b><ins>Conversión de entero a binario</ins></b>: Mediante esta función es 
posible convertir enteros a su representación binaria. La calculadora brindará
el resultado binario en diversas interpretaciones en caso de que dicho número
se pueda mostrar en ellas, o un mensaje de error en caso contrario.
- <b><ins>Conversión de binario a entero</ins></b>: Esta función permite realizar
la inversa de la función anterior, es decir, recibe un número binario y lo
convierte a entero en cada una de las interpretaciones posibles.

Utilidades próximas a ser realizadas:
- Cálculo de binarios en punto fijo
- Cálculo de binarios en punto flotante
- Normalizacion simple, bit implícito, y IEE754
- Rango y resolución