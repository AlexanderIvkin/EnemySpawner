using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _speed;

    private Transform _target;
    private SpriteRenderer _spriteRenderer;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        Move();
    }

    public void SetProperties(Transform target, Color color)
    {
        SetColor(color);
        SetTarget(target);
    }

    private void SetColor(Color parentColor)
    {
        _spriteRenderer.color = parentColor;
    }

    private void SetTarget(Transform target)
    {
        _target = target;
    }

    private void Move()
    {
        transform.position = Vector2.MoveTowards(transform.position, _target.position, _speed* Time.deltaTime);
    }
}
