using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TypeOfController
{
    pc = 0,
    mobile = 1,
    vr_mobile = 2
}

public class PlayerContainer : BaseSceneObject
{
    [SerializeField] private GameObject _pcPlayer;
    [SerializeField] private GameObject _mobilePlayer;
    [SerializeField] private GameObject _VRmobilePlayer;

    public TypeOfController _currentChar;

    // Start is called before the first frame update
    void Start() => DontDestroyOnLoad(gameObject);


    public void SetCurrentChar(int num) => _currentChar = (TypeOfController)num;

    public GameObject GetCurrentChar()
    {
        switch (_currentChar)
        {
            case TypeOfController.pc:
                return _pcPlayer;
            case TypeOfController.mobile:
                return _mobilePlayer;
            case TypeOfController.vr_mobile:
                return _VRmobilePlayer;

            default:
                return null;
        }
    }
}
