using System;
using UnityEngine;

public class MarioMovement : MonoBehaviour
{
    public float horizontalSpeed = 3;
    public float jumpForce = 500;

    private Rigidbody2D rigidbody2D;
    private float horizontal;
    //El Animator contiene información sobre las animaciones (para que cambie a CORRER, SALTAR, ETC)
    private Animator animator;

    void Start()
    {
        //Esto busca un componente "Rigidbody2D". Como el Script va a estar asociado al personaje (Mario), va a coger el de Mario.
        rigidbody2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        //Si pulsa "A" o flecha izq => -1
        //Si pulsa "D" o flecha der => +1
        horizontal = Input.GetAxisRaw("Horizontal");

        //Esto hace que se active la animación de CORRER si la horizontal es distinto de 0, es decir si está corriendo para un lado o para otro.
        animator.SetBool("running", horizontal != 0);

        if (Input.GetKeyDown(KeyCode.Space) && marioIsGrounded())
        {
            Debug.Log("Se ha pulsado la techa de saltar.");
            Jump();
        }
    }

    //Para las físicas (movimiento) mejor utilizar FixedUpdate que Update, ya que FixedUpdate es independiente de los FPS.
    private void FixedUpdate()
    {
        rigidbody2D.linearVelocity = new Vector2(horizontal * horizontalSpeed, rigidbody2D.linearVelocity.y);
    }

    private void Jump()
    {
        //Añade una fuerza hacia arriba
        rigidbody2D.AddForce(Vector2.up * jumpForce);
    }

    //Devuelve TRUE si Mario/PSJ está en el suelo, y FALSE si no es asi. Se puede utilizar para saber si puede saltar o no.
    private bool marioIsGrounded()
    {
        //Es la distancia en la que se va a mirar que haya suelo. ¡¡OJO!! Esto no es algo universal. Hay que ponerlo manualmente para cada elemento, ir probando.
        float checkDistance = 0.5f;

        //Esto dibuja un RAYCAST hacia abajo para que sea visible. Debe estar el GIZMOS activado para que se vea. Sirve para validar si la checkDistance es correcta o no.
        //Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.down) * checkDistance, Color.green);

        //Devuelve TRUE si choca con algo que esté justo debajo
        //¡¡OJO!! Por defecto esto siempre será TRUE, por que choca contra si mismo. Para que funcione hay que ir a "Edit" > "Project Settings" > "Physics 2D" > Desactivar "Queries Start in Colliders"
        return Physics2D.Raycast(transform.position, transform.TransformDirection(Vector3.down), checkDistance);
    }
}
