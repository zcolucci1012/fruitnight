using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowHoverText : MonoBehaviour
{
    public GameObject hoverText;
    public string msg;

    // Start is called before the first frame update
    void Start()
    {
        hoverText.SetActive(false);
        hoverText.GetComponentInChildren<Text>().text = msg;
    }

    public void OnHover()
    {
        hoverText.SetActive(true);
    }

    public void OnLeave()
    {
        hoverText.SetActive(false);
    }
}
