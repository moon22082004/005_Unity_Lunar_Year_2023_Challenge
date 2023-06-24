using UnityEngine;

public abstract class Item : ScriptableObject
{
    public abstract string Name
    {
        get;
    }
    public virtual string ShortDescription 
    {
        get => this.Name + " " + this.Level.ToString(); 
    }
    public abstract Sprite ItemIcon 
    { 
        get; 
    }

    [SerializeField] private int _level = 1;
    public int Level
    {
        get
        {
            if (_level <= 0)
            {
                _level = 1;
            }
            else if (_level > this.MaxLevel) 
            {
                _level = this.MaxLevel;
            }

            return _level;
        }
        set => _level = value;

    }

    public virtual int MaxLevel
    {
        get => 12;
    }    
}