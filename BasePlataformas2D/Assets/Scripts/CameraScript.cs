using UnityEngine;

public class CameraScript : MonoBehaviour
{
    //GameObject al que la cámara va a seguir.
    public GameObject gameObjectToFollow;

    private void Update()
    {
        Vector3 cameraPosition = transform.position;
        //Esto hace que solo le siga en el eje X.
        cameraPosition.x = gameObjectToFollow.transform.position.x;
        transform.position = cameraPosition;
    }
}
