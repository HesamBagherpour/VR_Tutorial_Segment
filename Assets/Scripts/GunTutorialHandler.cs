using ArioSoren.TutorialKit;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GunTutorialHandler : HighlightBehavior
{
    private bool _isShow;
    //[SerializeField] private ShootingModeControl _shootingModeControl;
    [SerializeField] private GameObject _player;
    [SerializeField] private GunController _gunController;
    public UnityEvent OnGrabGun;
    public UnityEvent OnDropGun;
    public UnityEvent OnGetNearGun;
    public UnityEvent OnGetFarGun;


    public bool IsGunReadyToShoot;
    [SerializeField] private bool _nearGun = false;
    [SerializeField] private float _nearGunDistance;
    [SerializeField] private float _gunDistance;



    public override void Hide()
    {
        //throw new System.NotImplementedException();
        _isShow = false;
    }

    public override void Show()
    {
        //throw new System.NotImplementedException();
        _isShow = true;
        //_shootingModeControl.OnShootingModeChange = (mode) => { _shootingMode = mode; };

    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (!_isShow)
            return;
        if (IsGunReadyToShoot != _gunController.IsGunReadyToShoot())
        {
            IsGunReadyToShoot = _gunController.IsGunReadyToShoot();
            if (IsGunReadyToShoot)
                OnGrabGun.Invoke();
            else
                OnDropGun.Invoke();
        }

        _gunDistance = Vector3.Distance(_player.transform.position, _gunController.gameObject.transform.position);
        if (_nearGun != (_gunDistance < _nearGunDistance))
        {
            _nearGun = (_gunDistance < _nearGunDistance);
            if (_nearGun)
                OnGetNearGun.Invoke();
            else
                OnGetFarGun.Invoke();
        }

    }




}
