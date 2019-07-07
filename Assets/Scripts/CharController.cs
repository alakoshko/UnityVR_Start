using UnityEngine;

public class CharController : MonoBehaviour
{
    [SerializeField] private GameObject _camera;
    [SerializeField] private float _speed = 6;
    [SerializeField] private float _sideSpeed = 2;
    [SerializeField] private float _deadZoneRotation = 10;

    private Rigidbody _player;


    // Use this for initialization
    void Start()
    {
        _player = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 dir = _player.velocity;

        //влево
        if (_camera.transform.rotation.eulerAngles.z > _deadZoneRotation
            && _camera.transform.rotation.eulerAngles.z <= 180)
            dir.x = _camera.transform.rotation.eulerAngles.z * -1 * Time.deltaTime * _sideSpeed;
        //вправо
        if (_camera.transform.rotation.eulerAngles.z > 180
            && _camera.transform.rotation.eulerAngles.z <= 360 - _deadZoneRotation)
            dir.x = (360 - _camera.transform.rotation.eulerAngles.z) * Time.deltaTime * _sideSpeed;

        dir.x = Input.GetAxis("Horizontal") * _sideSpeed;
        dir.z = _speed;

        _player.velocity = dir;
    }
}
