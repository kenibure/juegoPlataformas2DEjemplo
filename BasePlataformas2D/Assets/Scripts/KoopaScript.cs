using UnityEngine;
using static UnityEditor.Searcher.SearcherWindow.Alignment;

public class KoopaScript : MonoBehaviour
{
    //Es necesario tener el GameObject del jugador para que este enemigo/Koopa le esté mirando y sepa hacia donde ir.
    public GameObject player;


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
    }


    /**
     * Este método invierte la coordenada X de SCALE. Esto hace que la imagen se voltee horizontalmente.
     * Se usa para simular que esté mirando a la derecha o la izquierda.
     */
    private void invertirScaleX()
    {
        transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
    }
}
