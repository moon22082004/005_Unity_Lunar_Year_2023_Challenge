using UnityEngine;

namespace LY2023Challenge
{
    public class RedScientistController : NpcController
    {
        protected override void SetUpNpcPanel()
        {
            base.SetUpNpcPanel();

            this.NpcPanelManager.CloneButton("Talk", (() => this.NpcPanelManager.StartTalking()));
            this.NpcPanelManager.CloneButton("Shop", (() => this.NpcPanelManager.StartShopping()));
        }

        protected override void Update()
        {
            base.Update();

            this.Animator.Play($"{this.AnimationDirection}_Idle");
        }
    }
}
