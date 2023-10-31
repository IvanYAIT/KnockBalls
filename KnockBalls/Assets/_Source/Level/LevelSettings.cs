using System;
using System.Collections.Generic;
using UnityEngine;

namespace Level
{
    [CreateAssetMenu(fileName = "LevelSettings", menuName = "SO/NewLevelSettings")]
    public class LevelSettings : ScriptableObject
    {
        [SerializeField] private int amountOfBullets;
        [SerializeField] private GameObject levelPrefab;
        [SerializeField] private int amountOfBlocks;

        public int AmountOfBullets => amountOfBullets;
        public GameObject LevelPrefab => levelPrefab;
        
        public int AmountOfBlocks => amountOfBlocks;
    }
}