using UnityEngine;

public class UIScript : MonoBehaviour {

    // Menu Button
    private GameObject _menuCanvas = null;
    public  bool       _menuActive = false;

    public void Start()
    {
        _menuCanvas = Resources.Load<GameObject>("UI/MenuWindow");
    }

    public void OnMenu()
    {
        if (!_menuActive) { Instantiate(_menuCanvas); }
        _menuActive = true;
    }
}
