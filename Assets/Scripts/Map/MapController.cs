
using UnityEngine;
using Random = UnityEngine.Random;

namespace Map
{
    public class MapController : MonoBehaviour
    {
        [SerializeField] private GameObject[] _quarters;

        private void Start()
        {
            foreach (GameObject quarter in _quarters)
            {
                int randomChildIdx = Random.Range(0, quarter.transform.childCount);
                Transform randomChild = quarter.transform.GetChild(randomChildIdx);
                
                randomChild.gameObject.SetActive(true);
            }
        }
    }
}