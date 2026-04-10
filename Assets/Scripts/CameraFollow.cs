using UnityEngine;

public class CameraFollow : MonoBehaviour
{
	[SerializeField] private GameObject followTarget;

    private void Update()
    {
        transform.position = new Vector3(followTarget.transform.position.x, followTarget.transform.position.y, -10);
    }
}
