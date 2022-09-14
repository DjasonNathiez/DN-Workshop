using UnityEngine;

public class AI : MonoBehaviour
{
    private int _healthPoint;
    private int _armorPoint;

    public void GetHurt(int damage, bool pierced = false)
    {
        _healthPoint -= pierced ? damage : damage - _armorPoint;

        if (_healthPoint <= 0)
        {
            Debug.Log("dead");
        }
    }

    public bool IsHealthMoreThan(int number)
    {
        return _healthPoint >= number && _armorPoint == 0;
    }
}
