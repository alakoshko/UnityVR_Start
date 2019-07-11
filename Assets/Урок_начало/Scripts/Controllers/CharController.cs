using System;
using UnityEngine;

public class CharController : BaseSceneObject, IDamageable
{
    [SerializeField] private GameObject _camera;
    [SerializeField] private float _speed = 6;
    [SerializeField] private float _sideSpeed = 2;
    [SerializeField] private float _deadZoneRotation = 10;

    //private Rigidbody _player;
    public string PlayerName = "Player01";
    public static CharController LocalPlayer { get; private set; }

    public BaseWeapons[] Weapons;
    //public Image ImgMaxHealth;
    public event Action<float> HealthAmountChanged;
    public event Action<bool> HealthStateChanged;

    public float speed {
        get => _speed;
        set { _speed = value; }
    }

    protected override void Awake()
    {
        base.Awake();

        if (LocalPlayer) DestroyImmediate(gameObject);
        else LocalPlayer = this;

        _currentHealth = _maxHealth;

        if (Weapons == null || Weapons.Length == 0)
            Weapons = GetComponentsInChildren<BaseWeapons>(true);
    }


    //// Use this for initialization
    //void Start()
    //{
    //    _player = Rigidbody;
    //}

    // Update is called once per frame
    void Update()
    {
        Vector3 dir = Rigidbody.velocity;

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

        Rigidbody.velocity = dir;
    }


    #region IDamageable implementation
    [SerializeField]
    private float _maxHealth;
    public float MaxHealth => _maxHealth;

    private float _currentHealth;
    public float CurrentHealth => _currentHealth;


    public void ApplyDamage(float damage)
    {
        if (CurrentHealth <= 0) return;
        _currentHealth -= damage;

        //Debug.Log($"Current health: {_currentHealth}");

        if (CurrentHealth <= 0) Die();

        if (HealthAmountChanged != null) HealthAmountChanged.Invoke(_currentHealth / _maxHealth);
    }


    public void Die()
    {
        Collider.enabled = false;
        var rb = GetComponent<Transform>().gameObject.GetComponent<Rigidbody>();
        rb.useGravity = false;


        Debug.Log("CharCollider: Hit the Enemy");
        //m_Animator?.Play(_animatorDead);


        //gameObject.GetComponentInChildren<Camera>().enabled = false;
        //Destroy(gameObject, 5f);
    }
    #endregion
}
