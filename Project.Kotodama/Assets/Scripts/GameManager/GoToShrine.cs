
using UnityEngine;

public class GoToShrine : MonoBehaviour {

  [SerializeField]
  [Tooltip("神社エリアの開始地点を設定")]
  Vector3 _shrinePosition = Vector3.zero;

  [SerializeField]
  ItemType _clearItem = ItemType.Empty;

  [SerializeField]
  [Tooltip("画面切り替えの演出時間")]
  [Range(0f, 5f)]
  float _sequenceTime = 2f;

  [SerializeField]
  string _clear = "神社へ戻りますか？";

  [SerializeField]
  string _play = "まだ戻るわけにはいかない";

  void Start() { GameManager.instance.start = _shrinePosition; }

  void OnTriggerEnter(Collider other) {
    if (!ObjectTag.Player.EqualTo(other.tag)) { return; }

    GameManager.instance.Pause();
    var item = ItemManager.instance.GetItem(_clearItem);
    var result = (item != null ? !item.useItem : false);
    System.Action Window = (result ? (System.Action)Command : Message);
    Window();
  }

  void Command() {
    GameManager.instance.window.CreateCommandWindow(_clear, 0f, OnYes);
  }

  void Message() {
    GameManager.instance.window.CreateMessageWindow(_play, 1.0f);
  }

  void OnYes() {
    System.Action ChangeScene = () => { GameScene.Shrine.ChangeScene(); };
    ScreenSequencer.instance.SequenceStart(ChangeScene, new Fade(_sequenceTime));
  }
}
