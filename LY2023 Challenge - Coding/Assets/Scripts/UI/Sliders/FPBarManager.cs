public class FPBarManager : BarManager
{
    protected override void Update()
    {
        this.Slider.value = this.AttributesManager.CurrentFP / this.AttributesManager.MaxFP;
        base.Update();
    }
}