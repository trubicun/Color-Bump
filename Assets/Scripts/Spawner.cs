using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private bool _spawnAuto;
    [SerializeField] private GameObject _object;
    [SerializeField] private int _width;
    [SerializeField] private int _length;
    [SerializeField] private float _scale = 1f;
    [SerializeField] private int _scaleIncreaseEvery = 2;
    [SerializeField] private float _scaleIncrease = 1f;
    [SerializeField] private float _objectScale = 1f;
    [SerializeField] private float _fixPositionY = 1;

    public bool SpawnInEditor { get => _spawnAuto; }

    private void Start()
    {
        _spawnAuto = false;
    }

    public void Spawn()
    {
        DeleteChilds(transform);
        AddChilds(transform, _object, _width, _length);
    }

    private void DeleteChilds(Transform obj)
    {
        var tempArray = new GameObject[obj.transform.childCount];

        for (int i = 0; i < tempArray.Length; i++)
        {
            tempArray[i] = obj.transform.GetChild(i).gameObject;
        }

        foreach (var child in tempArray)
        {
            DestroyImmediate(child);
        }

    }

    private void AddChilds(Transform parent, GameObject child, int maxX, int maxZ)
    {
        int scaleIncrease = 0;
        for(int x = 0; x < maxX; x++)
        {
            for(int z = 0; z < maxZ; z++)
            {
                Vector3 position = new Vector3((-maxX / 2 + x + transform.position.x) * _scale, 0, transform.position.z + z * _scale);
                GameObject obj = Instantiate(child, position, Quaternion.identity, parent);

                scaleIncrease = z / _scaleIncreaseEvery;
                obj.transform.localScale *= _objectScale;
                obj.transform.localScale += Vector3.up * _scaleIncrease * scaleIncrease;

                obj.transform.position = new Vector3(obj.transform.position.x, obj.transform.localScale.y / 2 * _fixPositionY, obj.transform.position.z);
            }
        }
    }

    private void OnValidate()
    {
        if (_length < 1) _length = 1;
        if (_width < 1) _width = 1;
        if (_scale < 0.001f) _scale = 0.001f;
        if (_objectScale < 0.001f) _objectScale = 0.001f;
        if (_scaleIncreaseEvery < 1) _scaleIncreaseEvery = 1;
        if (_scaleIncrease < 0) _scaleIncrease = 0;
    }
}
