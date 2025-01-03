using UnityEngine;
using static UnityEditor.Searcher.SearcherWindow.Alignment;

//Koopa es un enemigo con el tag "enemy_01". No tiene nada especial y cuando Mario lo toca se muere.
public class KoopaScript : MonoBehaviour
{
    public float horizontalSpeed = 0.2f;

    //Es necesario tener el GameObject del jugador para que este enemigo/Koopa le esté mirando y sepa hacia donde ir.
    public GameObject player;

    private Rigidbody2D rigidbody2D;
    private float horizontal;

    void Start()
    {
        //Esto busca un componente "Rigidbody2D". Como el Script va a estar asociado al enemigo/Koopa, va a coger el de ese enemigo.
        rigidbody2D = GetComponent<Rigidbody2D>();

        //Esto busca un componente "Animator". Como el Script va a estar asociado a la animación de Mario, es la que va a coger
        //animator = GetComponent<Animator>();
    }

    void Update()
    {
        //Esto resta la posición del jugador menos la posición del enemigo/koopa. De ese modo se obtiene la dirección que va de NOSOTROS a PLAYER.
        Vector3 direction = player.transform.position - transform.position;

        switch (direction.x)
        {
            //Si esto es TRUE significa que la dirección va hacia la IZQUIERDA
            case < 0f:
                //Si está mirando a la derecha (el valor de SCALE.X es positivo)
                //¡¡OJO!! Para que esto funcione el sprite por defecto debe estar mirando a la derecha, si no irá siempre al revés.
                if (transform.localScale.x > 0f)
                {
                    invertirScaleX();
                }
                break;
            //Si esto es TRUE significa que la dirección va hacia la DERECHA
            case > 0f:
                //Si está mirando a la izquierda (el valor de SCALE.X es negativo)
                //¡¡OJO!! Para que esto funcione el sprite por defecto debe estar mirando a la derecha, si no irá siempre al revés.
                if (transform.localScale.x < 0f)
                {
                    invertirScaleX();
                }
                break;
        }

        horizontal = direction.x;
    }


    /**
     * Este método invierte la coordenada X de SCALE. Esto hace que la imagen se voltee horizontalmente.
     * Se usa para simular que esté mirando a la derecha o la izquierda.
     */
    private void invertirScaleX()
    {
        transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
    }

    //Para las físicas (movimiento) mejor utilizar FixedUpdate que Update, ya que FixedUpdate es independiente de los FPS.
    private void FixedUpdate()
    {
        rigidbody2D.linearVelocity = new Vector2(horizontal * horizontalSpeed, rigidbody2D.linearVelocity.y);
    }
}
