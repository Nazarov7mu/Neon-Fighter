using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Enemy
{
    public class EnemySpawn : MonoBehaviour
    {
        [SerializeField] private GameObject[] _enemies;
    
        [Header("Scripts")]
        [SerializeField] private MapSpawnPoints _mapSpawnPoints;

        [Header("Stats")]
        [SerializeField] private int _spawnDelayMin = 3;
        [SerializeField] private int _spawnDelayMax = 10;
        
        private void Start()
        {
            StartCoroutine(SpawnEnemy());
        }

        private IEnumerator SpawnEnemy()
        {
            int randomDelay = Random.Range(_spawnDelayMin, _spawnDelayMax);
            yield return new WaitForSeconds(randomDelay);

            int randomPoint = Random.Range(0, _mapSpawnPoints.SpawnPoints.Length);
            Vector2 pos = _mapSpawnPoints.SpawnPoints[randomPoint].position;
            
            GameObject someEnemy = _enemies[Random.Range(0, _enemies.Length)];
            Instantiate(someEnemy, pos, transform.rotation);

            StartCoroutine(SpawnEnemy());
        }
    }
}