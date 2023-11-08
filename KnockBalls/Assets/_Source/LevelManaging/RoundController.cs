
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoundController : MonoBehaviour
{
    private int _blocksCount;
    private int _destroyblockcount;
    private RoundListener _roundListener;
    public LayerMask BulletMask;
    private int _blockLayer;

    private void Awake()
    {
        _blockLayer = (int)Mathf.Log(BulletMask.value, 2);
    }

    public void SetBolckCount(int blocksCount)
    {
        _blocksCount = blocksCount;
    }
    public void SetBolckDestroyCount(int destroyblocksCount)
    {
        _destroyblockcount = destroyblocksCount;
    }

    public void SetListener(RoundListener roundListener)
    {
        _roundListener = roundListener;
    }

    public void DestroyIceBlock()
    {
        _destroyblockcount--;
    }

    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == _blockLayer)
        {
            _blocksCount--;
            if (_blocksCount == 0 && _destroyblockcount == 0)
            {
                _roundListener.GoNextLevel();
                
                _blocksCount = _roundListener.GetActiveLevelSettings().AmountOfBlocks;
            }
        }
    }
}
