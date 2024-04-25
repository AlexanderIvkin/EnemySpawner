using System.Collections;
using UnityEngine;

[SelectionBase]

public class Spawner : MonoBehaviour
{
    [SerializeField] private Enemy _enemyPrefab;
    [SerializeField] private Transform _parent;
    [SerializeField] private Transform _target;
    [SerializeField] private float _delay;
    [SerializeField] private Color _color;

    private SpawnPoint[] _spawnPoints;
    private bool _isSpawned = true;

    private void Awake()
    {
        _spawnPoints = _parent.GetComponentsInChildren<SpawnPoint>();
    }

    private void Start()
    {
        StartCoroutine(Create());
    }

    private IEnumerator Create()
    {
        var wait = new WaitForSeconds(_delay);

        while (_isSpawned)
        {
            if (_spawnPoints.Length > 0)
            {
                int index = Random.Range(0, _spawnPoints.Length);

                SpawnPoint currentSpawnPoint = _spawnPoints[index];

                Instantiate(_enemyPrefab, currentSpawnPoint.transform.position, Quaternion.identity).SetProperties(_target, _color);

                yield return wait;
            }
        }
    }
}
