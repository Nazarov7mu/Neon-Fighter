using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Enemy
{
    public class EnemySpawn : MonoBehaviour
    {
        [SerializeField] private GameObject[] _enemies;
    
        [Header("Stats")]
        [SerializeField] private float _spawnDelay = 10;
    
        [Header("Map Stats")]
        [SerializeField] private float _xMin;
        [SerializeField] private float _xMax;

        [SerializeField] private float _yMin;
        [SerializeField] private float _yMax;

        private void Start()
        {
            StartCoroutine(SpawnEnemy());
        }

        private IEnumerator SpawnEnemy()
        {
            yield return new WaitForSeconds(_spawnDelay);
        
            Vector2 pos = new(Random.Range(_xMin, _xMax), Random.Range(_yMin, _yMax));
            GameObject someEnemy = _enemies[Random.Range(0, _enemies.Length)];
            Instantiate(someEnemy, pos, transform.rotation);

            StartCoroutine(SpawnEnemy());
        }
    }
}