using System.Collections;
using ObjectPooling;
using UnityEngine;

namespace Enemy
{
    public class EnemyWeapon : MonoBehaviour
    {
        [Header("Scripts")]
        [SerializeField] private EnemyTarget _enemyTarget;
        
        [Header("Weapon parts")]
        [SerializeField] private GameObject _bullet;
        [SerializeField] private GameObject _barrel;
        
        [Header("Stats")]
        [SerializeField] private float _shootingRange = 10;
        [SerializeField] private float _minRechargeTime = 1;
        [SerializeField] private float _maxRechargeTime = 3;

        private Transform _target;
        private bool _canShoot;

        private void Start()
        {
            _target = _enemyTarget.Target;

            StartCoroutine(Reload());
        }

        private void Update()
        {
            if (_target == null) return;
            
            CheckShootingRange();
        }

        private void CheckShootingRange()
        {
            //If target is in reach -> shoot
            if (Vector2.Distance(transform.position, _target.position) < _shootingRange)
            {
                if (_canShoot)
                {
                    Shoot();
                    StartCoroutine(Reload());
                }
            }
        }

        private void Shoot()
        {
            //Instantiate(_bullet, _barrel.transform.position, _barrel.transform.rotation);
            Pooler.Instance.GetPooledObject(_bullet.name, _barrel.transform.position, _barrel.transform.rotation);
        }

        private IEnumerator Reload()
        {
            _canShoot = false;
            float randomRechargeTime = Random.Range(_minRechargeTime, _maxRechargeTime);
            yield return new WaitForSeconds(randomRechargeTime);
            _canShoot = true;
        }
    }
}