using UnityEngine;

public class MapSpawnPoints : MonoBehaviour
{
    [SerializeField] private Transform[] _spawnPoints;

    public Transform[] SpawnPoints => _spawnPoints;
}
