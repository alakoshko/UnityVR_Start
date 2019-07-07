using UnityEngine;
using System.Collections.Generic;

public class LevelGenerator : MonoBehaviour
{
    [SerializeField] private List<Transform> _segments;
    [SerializeField] private float _minDistance;
    [SerializeField] private Transform _player;

    
    // Update is called once per frame
    void Update()
    {
        Transform lastObject = _segments[_segments.Count - 1];
        float dis = Vector3.Distance(lastObject.position, _player.position);

        if(dis < _minDistance)
        {
            Transform firstObj = _segments[0];
            firstObj.position = lastObject.position;

            Vector3 offset = lastObject.GetComponent<Collider>().bounds.extents + firstObj.GetComponent<Collider>().bounds.extents;
            firstObj.position += Vector3.forward * offset.z;

            _segments.Remove(firstObj);
            _segments.Add(firstObj);
        }
    }
}
