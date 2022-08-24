using System.Collections;
using UnityEngine;

namespace Player
{
    public class PlayerWeapon : MonoBehaviour
    {
        [SerializeField] private GameObject _bullet;
        [SerializeField] private GameObject _barrel;

        [Header("Stats")]
        [SerializeField] private float _coolDownTime = 0.2f;

        private bool _canShoot = true;

        private void Update()
        {
            Shoot();
        }

        private void Shoot()
        {
            if (!_canShoot) return;

            if (Input.GetMouseButton(0))
            {
                Instantiate(_bullet, _barrel.transform.position, _barrel.transform.rotation);
                StartCoroutine(Reload());
            }
        }

        private IEnumerator Reload()
        {
            _canShoot = false;
            yield return new WaitForSeconds(_coolDownTime);
            _canShoot = true;
        }
    }
}