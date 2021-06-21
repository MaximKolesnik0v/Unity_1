
using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private GameObject _BulletPref;
    [SerializeField] private Transform _BulletStartPosition;
    [SerializeField] private float _sensetivity;
    [SerializeField] private int _MaxHP = 100;
    [SerializeField] private int _MaxBullet = 20;

    int _bullet;
    float _hp;
    private Vector3 _dir;

    private void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked;
        _hp = _MaxHP;
        _bullet = _MaxBullet;

    }

    void Update()
    {
        _dir.x = Input.GetAxis("Horizontal");
        _dir.z = Input.GetAxis("Vertical");

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Fire();
        }

        Cursor.visible = true;
    }

    void FixedUpdate()
    {
        var speed = _dir * _speed * Time.fixedDeltaTime;
        transform.Translate(speed);

        PlayerLook();
    }

    private void Fire()
    {
        if (_bullet > 0)
        {
            var Bullet = Instantiate(_BulletPref, _BulletStartPosition.position, Quaternion.identity);
            var b = Bullet.GetComponent<Bullet>();
            b.Init();
            _bullet -= 1;

            Debug.Log(_bullet);
        }
    }

    public void TakeBullet()
    {
        _bullet += 10;
        Debug.Log(_bullet);
    }

    private void PlayerLook()
    {
        float mouseLook = Input.GetAxis("Mouse X") * _sensetivity * Time.deltaTime;
        transform.Rotate(0, mouseLook, 0);
    }

    public void TakeDamage(int _Damage)
    {
        _hp -= _Damage;

        if (_hp <= 0)
            Death();

        Debug.Log(_hp);
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
}
