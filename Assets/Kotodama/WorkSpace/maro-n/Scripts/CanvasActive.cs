using UnityEngine;

public class CanvasActive : MonoBehaviour {

    public GameObject _adventureCanvas;
    public bool _activeCanvas = false;
	
	void Update () {
                
        if (EventStart())
        {
            _activeCanvas = true;
        }

        if (EventEnd())
        {
            _activeCanvas = false;
        }

        _adventureCanvas.GetComponent<Canvas>().enabled = _activeCanvas;
	}

    public bool EventStart()
    {
        if (Input.GetMouseButton(1))
        {
            return true;
        }
        return false;
    }

    public bool EventEnd()
    {
        var text = GameObject.FindObjectOfType<TextBox>();
       
        if (text._current_text > text.MAX_TEXT)
        {
            return true;
        }

        return false;
    }

}


