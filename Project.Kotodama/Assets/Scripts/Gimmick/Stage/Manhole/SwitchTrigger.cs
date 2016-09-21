
using UnityEngine;

public class SwitchTrigger : MonoBehaviour {

  WindowManager window { get { return GameManager.instance.window; } }

  [SerializeField]
  UnderGroundBridge[] _bridges = null;

  [SerializeField]
  SwitchState _switch = null;

  [SerializeField]
  string _command = "スイッチを押しますか？";

  [SerializeField, Range(0f, 1f)]
  float _closeSpeed = 0f;

  [SerializeField]
  string _message = "仕掛けが動いたみたい";

  [SerializeField, Range(0.5f, 1.5f)]
  float _messageTime = 1.0f;
  
  void OnTriggerEnter(Collider other) {
    if (!ObjectTag.Player.EqualTo(other.tag)) { return; }

    PlayerState.instance.Stop();
    window.CreateCommandWindow(_command, _closeSpeed, OnYes);
  }

  void OnYes() {
    window.CreateMessageWindow(_message, _messageTime);
    foreach (var bridge in _bridges) { bridge.SwitchActivate(); }
    _switch.ChangeSwitchColor();
  }
}
