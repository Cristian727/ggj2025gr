# ggj2025gr

Parte de camacho:
# Enemigos
Movimiento continuo de derecha a izquierda y un segundo enemigo de arriba a abajo.
He hecho un script llamado EnemyMovement. Tenemos que crear 2 enemigos diferentes(he puesto un circulo(medusa) y un triangulo(pez)), le añades
el script que os he comentado y teneis que poner los siguientes valores a cada uno. 

Al triangulo que es el movimiento del pez, teneis que poner en Movement Type: Horizontal, Min Boundary: -7 y Max Boundary: 7
Al circulo que es el movimiento de la medusa, teneis que poner en Movement Type: Vertical, Min boundary: -5 y max Boundary: 5
Speed en ambos ponerlo en 8

# Pasar de nivel
Collider para pasar de una escena a otra.
He creado un script llamado "LevelTransition". Teneis primero que crear un objeto vacio y añadirle un box collider 2D. No olvideis acticar el IsTrigger.
Ademas dentro de Box Collider 2D, en la parte de "Size" teneis que poner la X en 13(OPCIONAL, PODEMOS CAMBIARLO).

Por ultimo añadir el script que he creado y no olvideis que en la interfaz de unity a la hora de meter el script en el "Next Scene Name" tendreis que poner el nombre
de la escena donde quereis que vaya dirigido(Level1, Level2...)

# Game over
Es basicamente cogerlo de mi carperta de assets ya que esta todo bien implementado con el funcionamiento clave de los botones
