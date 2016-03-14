
using UnityEngine;

public class SwitchState : MonoBehaviour {

  [SerializeField]
  MeshRenderer _renderer = null;

  [SerializeField]
  Color _before = Color.red;

  [SerializeField]
  Color _after = Color.blue;

  bool isPush { get; set; }

  void Start() {
    isPush = false;
    _renderer.material.color = _before;
  }

  /// <summary> スイッチの色を変更する </summary>
  public void ChangeSwitchColor() {
    _renderer.material.color = !isPush ? _after : _before;
    isPush = !isPush;
  }
}
