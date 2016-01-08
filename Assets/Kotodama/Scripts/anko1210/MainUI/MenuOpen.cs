
using UnityEngine;


public class MenuOpen : MonoBehaviour {

  OpenAction button { get { return MainGameButton.instance; } }
  GameObject _menuCanvas = null;

  void Awake() { _menuCanvas = Resources.Load<GameObject>("GameUI/MenuWindow"); }

  public void OnMenuOpen() { button.MenuOpen(_menuCanvas); }
}
