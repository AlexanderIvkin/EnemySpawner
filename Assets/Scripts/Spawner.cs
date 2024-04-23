using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Enemy _enemyPrefab;
    [SerializeField] private float _delay;

    private SpawnPoint[] _spawnPoints;

    private void Awake()
    {
        _spawnPoints = GetComponentsInChildren<SpawnPoint>();
    }

    private void Start()
    {
        InvokeRepeating(nameof(Create), _delay, _delay);
    }

    private void Create()
    {
        int index = Random.Range(0, _spawnPoints.Length);

        SpawnPoint currentSpawnPoint = _spawnPoints[index];

        Instantiate(_enemyPrefab, currentSpawnPoint.transform.position , currentSpawnPoint.transform.localRotation);
    }
}
