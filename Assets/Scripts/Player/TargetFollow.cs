using UnityEngine;

public class TargetFollow : MonoBehaviour
{
    [SerializeField] private Transform _target;

    private readonly Vector3 _offset = new(0, 0, -10);
    
    private void LateUpdate()
    {
        transform.position = _target.transform.position + _offset;
    }      
}