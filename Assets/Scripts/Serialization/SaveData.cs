using System.Collections;
using UnityEngine;


[System.Serializable]
public class SaveData : MonoBehaviour
{
    public static SaveData _current;
    public static SaveData current
    {
        get
        {
            if (_current == null)
            {
                _current = new SaveData();
            }
            return _current;
        }
        set
        {
            _current = value;
        }
    }

    public PlayerProfile profile;
    public int A;
    public int B;
}
