using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using Vector3 = UnityEngine.Vector3;

public class LevelGenerator : MonoBehaviour
{
    public GameObject Tile1;
    public GameObject Tile2;
    public GameObject StartTile;

    [SerializeField] private GameObject[] _tiles;
    
    [SerializeField] private float _currentLevelSpeed = 4;
    private int _baseSpeed = 4;

    [SerializeField] private float _speedFactor = .5f;
    
    private float Index = 0;

    private void Start()
    {
        GameObject StartPlane1 = Instantiate(StartTile, transform);
        StartPlane1.transform.position = new Vector3(7, 0, 0);
        GameObject StartPlane2 = Instantiate(StartTile, transform);
        StartPlane2.transform.position = new Vector3(-1, 0, 0);
        GameObject StartPlane3 = Instantiate(StartTile, transform);
        StartPlane3.transform.position = new Vector3(-9, 0, 0);
        GameObject StartPlane4 = Instantiate(StartTile, transform);
        StartPlane4.transform.position = new Vector3(-17, 0, 0);
        GameObject StartPlane5 = Instantiate(StartTile, transform);
        StartPlane5.transform.position = new Vector3(-25, 0, 0);
    }

    private void Update()
    {
        gameObject.transform.position += new Vector3(_currentLevelSpeed * Time.deltaTime, 0, 0);

        if(transform.position.x >= Index)
        {
            int RandomInt1 = Random.Range(0, 2);

            if(RandomInt1 == 1)
            {
                SpawnTile(Tile1, new Vector3(-16, 0, 0));
            }
            else if(RandomInt1 == 0)
            {
                SpawnTile(Tile2, new Vector3(-16, 0, 0));
            }

            int RandomInt2 = Random.Range(0, 2);

            if(RandomInt2 == 1)
            {
                SpawnTile(Tile1, new Vector3(-24, 0, 0));
            }
            else if(RandomInt2 == 0)
            {
                SpawnTile(Tile2, new Vector3(-24, 0, 0));
            }

            Index += 15.95f;
            _currentLevelSpeed += _speedFactor;
        }
    }

    private void SpawnTile(GameObject tile, Vector3 tilePosition)
    {
        GameObject TempTile = Instantiate(tile, transform);
        TempTile.transform.position = tilePosition;
    }
}
