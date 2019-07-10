using UnityEngine;
using System.Collections;

public class WeaponsController : MonoBehaviour
{

    //получаем ссылку на оружие персонажа
    private BaseWeapons[] _weapons;
    private int _currentWeapon;

    private void Awake()
    {
        _weapons = CharController.LocalPlayer.Weapons;

        for (int i = 0; i < _weapons.Length; i++) { _weapons[i].IsVisible = i == 0; }
    }

    public void ChangeWeapon()
    {
        _weapons[_currentWeapon % _weapons.Length].IsVisible = false;
        _currentWeapon++;
        _weapons[_currentWeapon % _weapons.Length].IsVisible = true;
        //_weapons[_currentWeapon % _weapons.Length].gameObject.
        //    _light = GameObject.Find("MagicArrowPrefab").GetComponent<Light>();
    }

    public void Fire()
    {
        if (_weapons[_currentWeapon % _weapons.Length] != null)
            _weapons[_currentWeapon % _weapons.Length].TryShoot();
    }

    internal void SetFireForceFromMSW(float mswValue)
    {
        if (_weapons[_currentWeapon % _weapons.Length] != null)
            _weapons[_currentWeapon % _weapons.Length].FireForce = mswValue;
    }

    public void ReloadCartridge()
    {
        if (_weapons[_currentWeapon % _weapons.Length] != null)
            _weapons[_currentWeapon % _weapons.Length].Reload();
    }

    public void SetFireForce()
    {
        if (_weapons[_currentWeapon % _weapons.Length] != null)
            _weapons[_currentWeapon % _weapons.Length].FireForce = Time.time;

        //GetComponent<Animation>().Play("Fire1");
    }
}
