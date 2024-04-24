using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    public Vector3 ReturnDirection()
    {
        Vector3 direction = transform.localRotation.eulerAngles;

        return direction;
    }
}
