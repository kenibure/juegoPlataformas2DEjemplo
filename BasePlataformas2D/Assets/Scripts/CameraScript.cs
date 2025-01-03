using UnityEngine;

public class CameraScript : MonoBehaviour
{
    //GameObject al que la cámara va a seguir.
    public GameObject gameObjectToFollow;

    private void Update()
    {
        Vector3 cameraPosition = transform.position;
        cameraPosition.x = gameObjectToFollow.transform.position.x;
        transform.position = cameraPosition;
    }
}
