using System;
using UnityEngine;

public class LevelTile : MonoBehaviour
{
    [SerializeField] private GameObject _catNip;

    private void Awake()
    {
        _catNip.SetActive(false);
    }

    public void SpawnCatNip()
    {
        _catNip.SetActive(true);
    }
}
