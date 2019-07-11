using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPoolable
{
    string PoolID { get; }
    int ObjectsCount { get; }
}