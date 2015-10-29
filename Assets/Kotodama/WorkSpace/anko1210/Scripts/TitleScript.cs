using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TitleScript : MonoBehaviour {

    public GameObject StartCanvas;
    public GameObject SelectCanvas;
    public bool _changeCan = true;

    public void Start()
    {
        StartCanvas.SetActive(_changeCan);
        SelectCanvas.SetActive(!_changeCan);
    }

    public void ChangeCanvas()
    {
        if (StartCanvas.activeInHierarchy) { _changeCan = !_changeCan; }
        else { _changeCan=!_changeCan; }

        StartCanvas.SetActive(_changeCan);
        SelectCanvas.SetActive(!_changeCan);
    }



}