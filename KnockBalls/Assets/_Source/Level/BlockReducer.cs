using DG.Tweening;
using UnityEngine;

public class BlockReducer : MonoBehaviour
{
    [SerializeField] private LayerMask blockLayerMask;

    private int _blockLayer;

    void Start()
    {
        _blockLayer = (int)Mathf.Log(blockLayerMask.value, 2);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.layer == _blockLayer)
        {
            collision.gameObject.transform.DOScale(Vector3.zero, 4);
        }
    }
}