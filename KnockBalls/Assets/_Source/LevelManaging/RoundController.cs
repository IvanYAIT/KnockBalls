
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoundController : MonoBehaviour
{
    private int _blocksCount;
    private RoundListener _roundListener;
    public LayerMask BulletMask;
    private int _bulletLayer;

    private void Awake()
    {
        _bulletLayer = (int)Mathf.Log(BulletMask.value, 2);
    }

    public void SetBolckCount(int blocksCount)
    {
        _blocksCount = blocksCount;
    }

    public void SetListener(RoundListener roundListener)
    {
        _roundListener = roundListener;
    }

    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer != _bulletLayer)
        {
            _blocksCount--;
            if (_blocksCount == 0)
            {
                Debug.Log("Go Next Round");
                
                _roundListener.GoNextLevel();
                
                _blocksCount = _roundListener.GetActiveLevelSettings().AmountOfBlocks;
            }
        }
    }
}
