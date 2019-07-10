using System;
using UnityEngine;
using System.Collections.Generic;

public class ObstacleSpawner : BaseSceneObject
{
    [SerializeField] private Transform[] _obstacle;
    [SerializeField] private float _spawnStep;
    [SerializeField] private float _spawnDistance;

    [SerializeField] private Vector2 _segmentWidth;

    private Transform _myTransform;
    private Vector3 _lastPos;

    private List<Transform> _spawnedObstacles = new List<Transform>();
    public List<Transform> spawnedObstacles { get { _spawnedObstacles.RemoveAll(TransformIsNull); return _spawnedObstacles; } }

    public event Action<float> HealthAmountChanged;
    public event Action<bool> HealthStateChanged;

    bool TransformIsNull(Transform a)
    {
        return a == null;
    }

    // Use this for initialization
    void Start()
    {
        _myTransform = transform;
        _lastPos = _myTransform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (_myTransform.position.z > _lastPos.z + _spawnStep)
        {
            _lastPos.z += _spawnStep;

            Transform newObstacle = _obstacle[UnityEngine.Random.Range(0, _obstacle.Length)];

            _spawnedObstacles.Add(Instantiate(newObstacle, new Vector3(
                UnityEngine.Random.Range(_segmentWidth.x, _segmentWidth.y),
                0,
                _lastPos.z + _spawnDistance),
                Quaternion.identity));
        }
    }
    
}
