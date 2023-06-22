using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Skill : ScriptableObject
{
    public abstract string Name
    {
        get;
    }

    private int _level;
    public int Level
    {
        get => _level;
        set => _level = value;
    }

    protected virtual List<float> Values
    {
        get;
    }

    private AttributesManager _attributesManager;
    protected AttributesManager AttributesManager
    {
        get
        {
            if (_attributesManager == null)
            {
                _attributesManager = GameObject.Find("Player/Character").GetComponent<AttributesManager>();
            }

            return _attributesManager;
        }
    }

    public abstract IEnumerator Execute();
}