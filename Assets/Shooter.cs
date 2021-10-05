using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    void Update()
    {
        shootByRaycast();
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
        }

    }
}
