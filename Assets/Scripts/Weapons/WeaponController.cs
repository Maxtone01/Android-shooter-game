using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    public Weapon _pistol, _riffle;
    public GunShoot _gunShoot;
    public Weapon equippedWeapon;

    public int bulletsPistol, bulletsRiffle, bulletsPistolSupply, bulletsRiffleSupply;
    public GameObject _activePistol, _activeRiffle;
    public static WeaponController Instance { get; private set; }

    public List<Weapon> weapons;

    [SerializeField]
    private PlayerScript _playerScript;

    [SerializeField]
    private Transform _weaponSlot;

    private GameObject _currentWeapon;

    private void Start()
    {
        Instance = this;
        _gunShoot = GetComponent<GunShoot>();

        _activePistol = Instantiate(_pistol.weaponPrefab);
        _activePistol.SetActive(false);
        _activePistol.transform.SetParent(_weaponSlot);
        _activePistol.transform.localPosition = Vector3.zero;
        _activePistol.transform.localRotation = Quaternion.identity;

        bulletsPistol = _pistol.bulletsQuantity;
        bulletsPistolSupply = _pistol.bulletsSupply;

        _gunShoot._shootingDelay = _pistol.shootingDelay;

        _activeRiffle = Instantiate(_riffle.weaponPrefab);
        _activeRiffle.SetActive(false);
        _activeRiffle.transform.SetParent(_weaponSlot);
        _activeRiffle.transform.localPosition = Vector3.zero;
        _activeRiffle.transform.localRotation = Quaternion.identity;

        bulletsRiffle = _riffle.bulletsQuantity;
        bulletsRiffleSupply = _riffle.bulletsSupply;

        _gunShoot._shootingDelay = _riffle.shootingDelay;
    }

    public void SetWeaponData(string _weaponType)
    {
        switch (_weaponType)
        {
            case "Pistol":
                _activePistol.SetActive(true);
                _activeRiffle.SetActive(false);
                Counter.quantity = bulletsPistol;
                Counter.supply = bulletsPistolSupply;
                break;
            case "Riffle":
                _activePistol.SetActive(false);
                _activeRiffle.SetActive(true);
                Counter.quantity = bulletsRiffle;
                Counter.supply = bulletsRiffleSupply;
                break;
        }
    }

    public void SetSupplyQuantity(CollectableScript.WeaponType weaponName, int supplyQuantity)
    {
        switch (weaponName)
        {
            case CollectableScript.WeaponType.Pistol:
                bulletsPistolSupply += supplyQuantity;
                Counter.supply += supplyQuantity;
                break;
            case CollectableScript.WeaponType.Riffle:
                bulletsRiffleSupply += supplyQuantity;
                Counter.supply += supplyQuantity;
                break;
        }
    }

    public void CallReload()
    {
        StartCoroutine(Reload());
    }

    public IEnumerator Reload()
    {
        if (_activePistol.activeSelf)
        {
            if (bulletsPistolSupply > 0)
            {
                yield return new WaitForSeconds(2);
                bulletsPistol = _pistol.bulletsQuantity;
                bulletsPistolSupply -= 7;
                Counter.quantity = bulletsPistol;
                Counter.supply = bulletsPistolSupply;
                print("Reloaded Pistol");
            }
            else if (bulletsPistolSupply == 0)
            {
                Debug.Log("Can't reload!");
            }
        }
        if (_activeRiffle.activeSelf)
        {
            if (bulletsRiffleSupply != 0)
            {
                yield return new WaitForSeconds(2);
                bulletsRiffle = _riffle.bulletsQuantity;
                bulletsRiffleSupply -= 30;
                Counter.quantity = bulletsRiffle;
                Counter.supply = bulletsRiffleSupply;
                print("Reloaded Riffle");
            }
            else if (bulletsRiffleSupply == 0)
            {
                Debug.Log("Can't reload!");
            }
        }
    }
}
