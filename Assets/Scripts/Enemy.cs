using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _speed;

    private void Update()
    {
        transform.Translate(Vector2.up * _speed * Time.deltaTime, Space.Self);
    }
}
