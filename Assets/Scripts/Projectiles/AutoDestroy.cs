using System.Collections;
using UnityEngine;

namespace Projectiles
{
    public class AutoDestroy : MonoBehaviour
    {
        [SerializeField] private float _delay = 2;

        private void OnEnable()
        {
            StartCoroutine(DestroySelf());
        }

        private IEnumerator DestroySelf()
        {
            yield return new WaitForSeconds(_delay);
            Destroy(gameObject);
        }
    }
}