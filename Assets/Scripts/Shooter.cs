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

    [SerializeField] float _bulletDamage;
    [SerializeField] float zOffset;

    [Header("Loading")]
    [SerializeField] private int _loadedBullets = 0;
    [SerializeField] private int _unloadedBullets = 60;
    [SerializeField] private int _clipSize = 10;
    [SerializeField] private KeyCode _reloadKey = KeyCode.R;

    [SerializeField] private UnityEvent<int, int> ammoChanged;
    [SerializeField] private Pool _decalPool;

    private void Start()
    {
        ammoChanged.Invoke(_loadedBullets, _unloadedBullets);
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
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
        int bulletsToRecharge = _clipSize - _loadedBullets;
        bulletsToRecharge = Mathf.Min(bulletsToRecharge, _unloadedBullets);
        _unloadedBullets -= bulletsToRecharge;
        _loadedBullets += bulletsToRecharge;
    }

    private void shootByInstantiation()
    {
        if (Input.GetMouseButtonUp(0))
        {
            GameObject currbullet = Instantiate(_bullet, _spawner.position, _spawner.rotation);
            currbullet.GetComponent<Rigidbody>().velocity = transform.forward * _speed;
        }
    }

    private void shootByRaycast()
    {
        Ray r = _cam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));
        RaycastHit hitInfo;
        if (Physics.Raycast(r, out hitInfo, _maxDistance, _shootingLayerMask))
        {
            hitInfo.transform.gameObject.GetComponent<HealthSystem>()?.getHit(_bulletDamage);
            _decalPool.activateObject(hitInfo.point + hitInfo.normal * zOffset, Quaternion.LookRotation(-hitInfo.normal));
        }

    }
}
