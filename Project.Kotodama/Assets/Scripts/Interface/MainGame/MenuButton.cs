
using UnityEngine;

public class MenuButton : MonoBehaviour {

  [SerializeField]
  GameObject _create = null;

  [SerializeField]
  bool _isActivePlayer = false;
  System.Action _action = null;

  void Start() {
    var game = GameManager.instance;
    _action = _isActivePlayer ? (System.Action)game.ReStart : game.Pause;
  }

  public void OnTouch() {
    _action();
    Instantiate(_create);
    Destroy(gameObject);
  }
}
