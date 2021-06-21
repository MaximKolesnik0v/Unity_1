using UnityEngine;

public class Turrel : MonoBehaviour
{

    [SerializeField] private Transform _target;
    [SerializeField] private float _speed = 3f;
    [SerializeField] private GameObject _BulletPref;
    [SerializeField] private Transform _BulletStartPosition;

    private void Update()
    {
        /*var pos = (_target.position + Vector3.up) - transform.position;
        var rot = Vector3.RotateTowards(transform.forward, pos, _speed * Time.deltaTime, 0.0f);
        transform.rotation = Quaternion.LookRotation(rot);
       */
    }


    private void OnTriggerStay(Collider other)
    {
        if (other.GetComponent<MovePlayer>())
        {
            Debug.Log("I'm here");
            other.GetComponent<Turrel>().Target();
            other.GetComponent<Turrel>().Fire();
        }
    }

    private void Target()
    {

        var pos = (_target.position + Vector3.up) - transform.position;
        var rot = Vector3.RotateTowards(transform.forward, pos, _speed * Time.deltaTime, 0.0f);
        transform.rotation = Quaternion.LookRotation(rot);
    }

    private void Fire()
    {
        var Bullet = Instantiate(_BulletPref, _BulletStartPosition.position, Quaternion.identity);
        var b = Bullet.GetComponent<Bullet>();
        b.Init();
    }
}
