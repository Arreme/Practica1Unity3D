using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class Shooter : MonoBehaviour
{
    [Header("Shooting")]
    [SerializeField] private GameObject _bullet;
    [SerializeField] private Transform _spawn;
    [SerializeField] private float _speed;    

    [Header("Loading")]
    [SerializeField] private int _loadedBullets = 0;
    [SerializeField] private int _unloadedBullets = 60;
    [SerializeField] private int _maxLoadedBullets = 120;
    [SerializeField] private KeyCode _reloadKey = KeyCode.R;
    [SerializeField] private UnityEvent<int, int> ammoChanged;

    [SerializeField] private Pool _decalPool;
    [SerializeField] private Animation _anim;


    private bool _gunActive;
    [SerializeField] private FPSController _controller;
    [SerializeField] private GunScriptableObject _initialGun;
    private static GunScriptableObject _currentGun;
    public static GunScriptableObject CurrentGun
    {
        set { _currentGun = value; }
        get { return _currentGun; }
    }

    [SerializeField] private AudioManager _audioManager;
    private enum ShootingAudios
    {
        SHOOT, NOBULLETS, RELOAD
    }
    private void Awake()
    {
        _currentGun = _initialGun;
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
                shootBullet();
                _loadedBullets--;
                ammoChanged.Invoke(_loadedBullets,_unloadedBullets);
                _audioManager.playAudio((int)ShootingAudios.SHOOT);
                _anim.Play("ShootPistol");
                _controller.giveRecoil(Random.Range(-_currentGun._recoilX, _currentGun._recoilX),_currentGun._recoilY);

            } else
            {
                //Cannot Shoot remember to recharge
                _audioManager.playAudio((int)ShootingAudios.NOBULLETS);
            }
            
        }
        if (Input.GetKey(_reloadKey))
        {
            reloadingWeapon();
            ammoChanged.Invoke(_loadedBullets, _unloadedBullets);
            _audioManager.playAudio((int)ShootingAudios.RELOAD);
        }
        
    }

    private void reloadingWeapon()
    {
        int bulletsToRecharge = _currentGun._clipSize - _loadedBullets;
        bulletsToRecharge = Mathf.Min(bulletsToRecharge, _unloadedBullets);
        _unloadedBullets -= bulletsToRecharge;
        _loadedBullets += bulletsToRecharge;
    }

    private void shootBullet()
    {
        GameObject obj = _decalPool.bulletActivateObject(_spawn.transform.position, Quaternion.LookRotation(-transform.forward));
        obj.GetComponent<Rigidbody>().velocity = transform.forward * _speed;
        obj.GetComponent<Rigidbody>().useGravity = false;

    }

    private IEnumerator AttackSpeed()
    {
        yield return new WaitForSecondsRealtime(_currentGun._attckSpeed);
        _gunActive = true;
    }

    public bool giveAmmo(int value)
    {
        if (_unloadedBullets == _maxLoadedBullets) return false;
        _unloadedBullets += value;
        _unloadedBullets = _unloadedBullets > _maxLoadedBullets ? _maxLoadedBullets : _unloadedBullets;
        ammoChanged.Invoke(_loadedBullets, _unloadedBullets);
        return true;
    }
}
