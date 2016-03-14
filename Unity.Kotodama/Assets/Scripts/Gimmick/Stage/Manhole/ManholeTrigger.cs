
using UnityEngine;
using System;

public class ManholeTrigger : MonoBehaviour {

  WindowManager window { get { return WindowManager.instance; } }

  [SerializeField]
  ManholeEvent _event = null;

  [SerializeField]
  Transform _destination = null;

  [SerializeField]
  string _command = "移動しますか？";

  [SerializeField, Range(0f, 1f)]
  [Tooltip("ウィンドウが閉じるまでの待機時間")]
  float _closeTime = 0.5f;

  [SerializeField]
  string _message = "開かない・・・";

  [SerializeField, Range(0.5f, 1.5f)]
  float _messageTime = 1f;

  void OnTriggerEnter(Collider other) {
    if (!ObjectTag.Player.EqualTo(other.tag)) { return; }

    PlayerState.instance.Stop();
    Action Next = _event.existKeyItem ? (Action)ManholeOpenEvent : Command;
    Next();
  }

  void ManholeOpenEvent() {
    var find = ItemManager.instance.GetItem(_event.keyItem);
    var success = (find != null ? !find.useItem : false);
    Action Next = success ? (Action)Command : Message;
    Next();
  }

  void Command() {
    window.CreateCommandWindow(_command, _closeTime, OnYes);
  }

  void Message() {
    window.CreateMessageWindow(_message, _messageTime);
  }

  void OnYes() {
    var sequencer = ScreenSequencer.instance;
    sequencer.SequenceStart(TranslatePlayer, new Fade(_closeTime));
  }

  void TranslatePlayer() {
    PlayerState.instance.agent.gameObject.SetActive(false);
    PlayerState.instance.transform.position = _destination.position;
    PlayerState.instance.agent.gameObject.SetActive(true);
    PlayerState.instance.Translate(_destination.position);
  }
}
