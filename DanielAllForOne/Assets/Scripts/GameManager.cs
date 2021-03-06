﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region Field

    public static GameManager Instance;

    [SerializeField] private GameObject[] _powerUpsObjects;
    [SerializeField] private GameObject[] _weaponsObjects;
    private int[,] _powerUpGrid = new int[100, 100];
    public float PlayerTime;

    #endregion

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
    }

    public void InitializePowerUpGrid()
    {
        for (int x = 0; x < _powerUpGrid.GetLength(0); x++)
        {
            for (int z = 0; z < _powerUpGrid.GetLength(1); z++)
            {
                int randomPowerUp = Random.Range(0, 100);
                int randomWeapon = Random.Range(0, 100);

                Vector3 pos = new Vector3(x + 0.5f - _powerUpGrid.GetLength(0) / 2, 0, z + 0.5f - _powerUpGrid.GetLength(1) / 2);

                if (randomPowerUp == 1)
                {
                    int r2 = Random.Range(0, _powerUpsObjects.Length);

                    Instantiate(_powerUpsObjects[r2], pos, Quaternion.identity);
                }

                if (randomWeapon == 1)
                {
                    int r2 = Random.Range(0, _weaponsObjects.Length);

                    Instantiate(_weaponsObjects[r2], pos, Quaternion.identity);
                }
            }
        }
    }

}
