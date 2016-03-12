
using UnityEngine;

public class MenuButton : MonoBehaviour {

  [SerializeField]
  GameObject _create = null;

  [SerializeField]
  bool _isActivePlayer = false;
  System.Action _action = null;

  void Start() {
    var player = PlayerState.instance;
    _action = _isActivePlayer ? (System.Action)player.Play : player.Stop;
  }

  public void OnTouch() {
    _action();
    Instantiate(_create);
    Destroy(gameObject);
  }
}
