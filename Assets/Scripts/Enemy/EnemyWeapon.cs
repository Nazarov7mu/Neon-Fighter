using System.Collections;
using UnityEngine;

namespace Enemy
{
    public class EnemyWeapon : MonoBehaviour
    {
        [SerializeField] private GameObject _bullet;
        [SerializeField] private GameObject _barrel;
        [SerializeField] private float _minDistance;

        private Transform _target;
        private bool _canShoot;

        private void Update()
        {
            //If target is in reach -> shoot
            if (Vector2.Distance(transform.position, _target.position) > _minDistance - 5)
            {
                if (_canShoot) StartCoroutine(Fire());
            }
        }

        private IEnumerator Fire()
        {
            _canShoot = false;
            Instantiate(_bullet, _barrel.transform.position, _barrel.transform.rotation);
            yield return new WaitForSeconds(1.2f);
            _canShoot = true;
        }
    }
}