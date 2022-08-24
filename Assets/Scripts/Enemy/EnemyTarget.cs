using UnityEngine;

namespace Enemy
{
    public class EnemyTarget : MonoBehaviour
    {
        public Transform Target { get; private set; }

        private void Awake()
        {
            Target = GameObject.FindGameObjectWithTag("Player")?.transform;

            if (Target == null) enabled = false;
        }
    }
}