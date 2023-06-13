using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    //�̱��� ���� - ���α׷��� �� �ϳ��� ������ �ν��Ͻ��� �����.
    static T _inst = null;
    public static T Inst
    {
        get
        {
            if (_inst == null)
            {
                _inst = FindObjectOfType<T>();
                if (_inst == null)
                {
                    GameObject obj = new GameObject();
                    obj.name = typeof(T).ToString();
                    _inst = obj.AddComponent<T>();
                }
            }
            return _inst;
        }
    }

    protected void Initialize()
    {
        if (_inst == null)
        {
            _inst = this as T;
        }
        else
        {
            Destroy(this);
            Destroy(gameObject);
        }
    }
}
