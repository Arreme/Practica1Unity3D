using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Shooter : MonoBehaviour
{
    [Header("ShootByInstantiation")]
    [SerializeField] GameObject _bullet;
    [SerializeField] Transform _spawner;
    [SerializeField] float _speed;

    [Header("shootByRaycast")]
    [SerializeField] Camera _cam;
    [SerializeField] float _maxDistance;
    [SerializeField] LayerMask _shootingLayerMask;
    [SerializeField] float zOffset;

    [Header("Loading")]
    [SerializeField] private int _loadedBullets = 0;
    [SerializeField] private int _unloadedBullets = 60;
    [SerializeField] private KeyCode _reloadKey = KeyCode.R;
    [SerializeField] private UnityEvent<int, int> ammoChanged;

    [SerializeField] private Pool _decalPool;
    private bool _gunActive;
    [SerializeField] private GunScriptableObject _currentGun;
    public GunScriptableObject CurrentGun
    {
        set { _currentGun = value; }
        get { return _currentGun; }
    }

    private void Start()
    {
        _gunActive = true;
        _loadedBullets = _currentGun._clipSize;
        ammoChanged.Invoke(_loadedBullets, _unloadedBullets);
    }
    void Update()
    {
        if (Input.GetMouseButton(0) && _gunActive)
        {
            _gunActive = false;
            StartCoroutine(AttackSpeed());
            if (_loadedBullets > 0)
            {
                shootByRaycast();
                _loadedBullets--;
                ammoChanged.Invoke(_loadedBullets,_unloadedBullets);
            } else
            {
                //Cannot Shoot remember to recharge
                Debug.Log("clac clac no balas me sad :(");
            }
            
        }
        if (Input.GetKey(_reloadKey))
        {
            reloadingWeapon();
            ammoChanged.Invoke(_loadedBullets, _unloadedBullets);
        }
        
    }

    private void reloadingWeapon()
    {
        int bulletsToRecharge = _currentGun._clipSize - _loadedBullets;
        bulletsToRecharge = Mathf.Min(bulletsToRecharge, _unloadedBullets);
        _unloadedBullets -= bulletsToRecharge;
        _loadedBullets += bulletsToRecharge;
    }

    private void shootByInstantiation()
    {
        GameObject currbullet = Instantiate(_bullet, _spawner.position, _spawner.rotation);
        currbullet.GetComponent<Rigidbody>().velocity = transform.forward * _speed;
    }

    private void shootByRaycast()
    {
        Ray r = _cam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));
        RaycastHit hitInfo;
        if (Physics.Raycast(r, out hitInfo, _maxDistance, _shootingLayerMask))
        {
            hitInfo.transform.gameObject.GetComponent<HealthSystem>()?.getHit(_currentGun._damage);
            _decalPool.activateObject(hitInfo.point + hitInfo.normal * zOffset, Quaternion.LookRotation(-hitInfo.normal));
        }

    }

    private IEnumerator AttackSpeed()
    {
        yield return new WaitForSecondsRealtime(_currentGun._attckSpeed);
        _gunActive = true;
    }
}
