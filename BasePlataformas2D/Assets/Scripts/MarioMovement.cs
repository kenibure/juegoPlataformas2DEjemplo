using UnityEngine;

public class MarioMovement : MonoBehaviour
{
    private Rigidbody2D rigidbody2D;
    private float horizontal;
    void Start()
    {
        //Esto busca un componente "Rigidbody2D". Como el Script va a estar asociado al personaje (Mario), va a coger el de Mario.
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        //Si pulsa "A" => -1
        //Si pulsa "D" => +1
        horizontal = Input.GetAxisRaw("Horizontal");
    }

    //Para las físicas (movimiento) mejor utilizar FixedUpdate que Update, ya que FixedUpdate es independiente de los FPS.
    private void FixedUpdate()
    {
        rigidbody2D.linearVelocity = new Vector2(horizontal, rigidbody2D.linearVelocity.y);
    }
}
