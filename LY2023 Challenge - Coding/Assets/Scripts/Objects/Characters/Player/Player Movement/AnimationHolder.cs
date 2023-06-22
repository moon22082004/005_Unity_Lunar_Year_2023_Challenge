using UnityEngine;

public class AnimationHolder
{
    private GameObject _parentAni;
    private GameObject _downAni;
    private GameObject _sideAni;
    private GameObject _upAni;

    public GameObject ParentAnimation
    {
        get => this._parentAni;
        // set => this._parentAni = value;
    }

    public GameObject DownAnimation
    {
        get => this._downAni;
        // set => this._downAni = value;
    }

    public GameObject SideAnimation
    {
        get => this._sideAni;
        // set => this._sideAni = value;
    }

    public GameObject UpAnimation
    {
        get => this._upAni;
        // set => this._upAni = value;
    }

    public AnimationHolder(GameObject parentAni)
    {
        this._parentAni = parentAni;

        this._downAni = this.ParentAnimation.transform.GetChild(0).gameObject;
        this._sideAni = this.ParentAnimation.transform.GetChild(1).gameObject;
        this._upAni = this.ParentAnimation.transform.GetChild(2).gameObject;
    }

    public void SetActiveParentAnimation(bool boolean)
    {
        this._parentAni.SetActive(boolean);
    }

    public void SetSideDirection()
    {
        this._downAni.SetActive(false);
        this._sideAni.SetActive(true);
        this._upAni.SetActive(false);
    }

    public void SetDownDirection()
    {
        this._downAni.SetActive(true);
        this._sideAni.SetActive(false);
        this._upAni.SetActive(false);
    }

    public void SetUpDirection()
    {
        this._downAni.SetActive(false);
        this._sideAni.SetActive(false);
        this._upAni.SetActive(true);
    }
}
