using UnityEngine;

public class TV : MonoBehaviour
{
    [SerializeField] private GameObject _glass;
    [SerializeField] private int _HealthPointsTV;

    int _hp;

    private void Awake()
    {
        _hp = _HealthPointsTV;
    }


    public void Damage(int _Damage)
    {
        _hp -= _Damage;
        if (_hp <= 0)
            Destroyglass();

        Debug.Log(_hp);
    }

    private void Destroyglass()
    {
        Destroy(_glass);
        Debug.Log("Стекло жирное");
    }

}
