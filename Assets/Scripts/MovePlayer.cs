
using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private GameObject _BulletPref;
    [SerializeField] private Transform _BulletStartPosition;
    [SerializeField] private float _sensetivity;
    [SerializeField] private int _MaxHP = 100;
    [SerializeField] private int _MaxBullet = 20;
    [SerializeField] private float _ReloadTime = 1;
    [SerializeField] private int _MaxMins = 3;
    [SerializeField] private GameObject _MinaPref;
    [SerializeField] private Transform _MinaPosition;
    [SerializeField] private float _JumpPower;

    private Rigidbody _RigidBody;
    private Vector3 _JumpVector = Vector3.up;
    private bool _reload = true;
    private bool _JumpReload = true;
    private int _bullet;
    private float _hp;
    private Vector3 _dir;
    private int _Mins;

    public int _bottle = 0;


    private void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked;
        _hp = _MaxHP;
        _bullet = _MaxBullet;
        _Mins = _MaxMins;
        this._RigidBody =this.GetComponent<Rigidbody>();

    }

    void Update()
    {
        _dir.x = Input.GetAxis("Horizontal");
        _dir.z = Input.GetAxis("Vertical");

        if (Input.GetKeyDown(KeyCode.Mouse0) && _reload)
        {
            Fire();
        }

        if (Input.GetKeyDown(KeyCode.T))
        {
            PlaceMina();
        }

        Cursor.visible = true;

        if (Input.GetKeyDown(KeyCode.Space) && _JumpReload) 
        {
            Jump();
        }       
    }

    void FixedUpdate()
    {
        var speed = _dir * _speed * Time.fixedDeltaTime;
        transform.Translate(speed);

        PlayerLook();
    }

    private void PlayerLook()
    {
        float mouseLook = Input.GetAxis("Mouse X") * _sensetivity * Time.deltaTime;
        transform.Rotate(0, mouseLook, 0);
        float mouseLook1 = Input.GetAxis("Mouse Y") * _sensetivity * Time.deltaTime;
        transform.Rotate(0, mouseLook1,0);

    }

    private void Fire()
    {
        if (_bullet > 0)
        {
            var Bullet = Instantiate(_BulletPref, _BulletStartPosition.position, Quaternion.identity);
            var b = Bullet.GetComponent<Bullet>();
            b.Init(transform.forward);

            _reload = false;
            _bullet -= 1;

            Invoke("Reload", _ReloadTime);

            Debug.Log(_bullet);
        }
    }

    private void PlaceMina()
    {
        if (_Mins > 0)
        {
            var Mina = Instantiate(_MinaPref, _MinaPosition.position, Quaternion.identity);
            var M = Mina.GetComponent<mina>();
            M.Boom(transform.forward);

            _Mins--;

            Debug.Log(_Mins);
        }
    }

    private void Reload()
    {
        _reload = true;
    }

    public void TakeBullet()
    {
        _bullet += 10;
        Debug.Log(_bullet);
    }

    public void Damage (int _Damage)
    {
        _hp -= _Damage;

        if (_hp <= 0)
            Death();

        Debug.Log( "Player" + _hp);
    }

    private void Death()
    {
        Destroy(gameObject);
    }

    public void Kit()
    {
        if (_hp < 100)
        {
            _hp += 25;
            if ((_hp) / 100 > 1)

                _hp = 100;
        }
        Debug.Log(_hp);
    }

    public void Trap()
    {
        _hp -= 50;
        if (_hp <= 0)
            Death();

        Debug.Log(_hp);
    }

    private void Jump()
    {
        _RigidBody.AddForce(_JumpVector * _JumpPower, ForceMode.Impulse);
        _JumpReload = false;

        Invoke("JumpReload", 1f);
    }

    private void JumpReload()
    {
        _JumpReload = true;
    }

    public void TakeBottle(int _NumberOfBottles)
    {
        _bottle += _NumberOfBottles;

        Debug.Log(_bottle);
    }
}
