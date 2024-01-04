using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DetailedAttributesPanel : MonoBehaviour
{
    [SerializeField] private GameObject _firstPageUIGameObject;
    private GameObject FirstPageUIGameObject
    {
        get
        {
            if (_firstPageUIGameObject == null)
            {
                _firstPageUIGameObject = this.transform.GetChild(0).gameObject;
            }

            return _firstPageUIGameObject;
        }
    }

    [SerializeField] private GameObject _secondPageUIGameObject;
    private GameObject SecondPageUIGameObject
    {
        get
        {
            if (_secondPageUIGameObject == null)
            {
                _secondPageUIGameObject = this.transform.GetChild(1).gameObject;
            }

            return _secondPageUIGameObject;
        }
    }

    [SerializeField] private GameObject _previousPageButtonUIGameObject;
    private GameObject PreviousPageButtonUIGameObject
    {
        get
        {
            if (_previousPageButtonUIGameObject == null)
            {
                _previousPageButtonUIGameObject = this.transform.GetChild(2).gameObject;
            }

            return _previousPageButtonUIGameObject;
        }
    }

    public void ChangeToNextPage()
    {
        this.NextPageButtonUIGameObject.GetComponent<Button>().interactable = false;
        this.PreviousPageButtonUIGameObject.GetComponent<Button>().interactable = true;

        this.FirstPageUIGameObject.SetActive(false);
        this.SecondPageUIGameObject.SetActive(true);
    }

    public void ChangeToPreviousPage()
    {
        this.NextPageButtonUIGameObject.GetComponent<Button>().interactable = true;
        this.PreviousPageButtonUIGameObject.GetComponent<Button>().interactable = false;

        this.FirstPageUIGameObject.SetActive(true);
        this.SecondPageUIGameObject.SetActive(false);
    }

    [SerializeField] private GameObject _nextPageButtonUIGameObject;
    private GameObject NextPageButtonUIGameObject
    {
        get
        {
            if (_nextPageButtonUIGameObject == null)
            {
                _nextPageButtonUIGameObject = this.transform.GetChild(3).gameObject;
            }

            return _nextPageButtonUIGameObject;
        }
    }

    private void Awake()
    {
        // Set up Pages
        this.ChangeToPreviousPage();
    }
}
