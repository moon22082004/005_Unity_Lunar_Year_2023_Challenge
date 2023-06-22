using UnityEngine;

public abstract class Item : ScriptableObject
{
    public abstract string Name
    {
        get;
    }
    public abstract Sprite ItemIcon 
    { 
        get; 
    }

    private int _level = 1;
    public int Level
    {
        get
        {
            if (_level <= 0)
            {
                return 1;
            }

            return _level;
        }
        set
        {
            if (value <= 0)
            {
                _level = 1;
            }
            else
            {
                _level = value;
            }
        }
    }
}