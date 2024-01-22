using UnityEngine;

public class HPBarManager : BarManager
{
    protected override void Update() 
    {
        this.Slider.value = this.AttributesManager.CurrentHP / this.AttributesManager.MaxHP;
        base.Update();
    }
    }