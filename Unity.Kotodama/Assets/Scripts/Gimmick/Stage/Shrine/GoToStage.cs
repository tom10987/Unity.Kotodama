
using UnityEngine;

public class GoToStage : MonoBehaviour {

  static WindowManager window { get { return WindowManager.instance; } }

  [SerializeField]
  SceneTag _sceneName = SceneTag.Title;

  [SerializeField]
  ItemType _keyAmulet = ItemType.Empty;

  [SerializeField]
  GateKeeperCollider _keeper = null;

  [SerializeField]
  string _command = "先へ進みますか？";

  [SerializeField, Range(0.5f, 1.5f)]
  float _closeTime = 1f;

  void Start() {
    var find = ItemManager.instance.GetItem(_keyAmulet);
    _keeper.gameObject.SetActive(find == null);
  }

  public void OnTriggerEnter(Collider other) {
    if (other.tag != ObjectTag.Player.ToString()) { return; }

    PlayerState.instance.Stop();
    window.CreateCommandWindow(_command, _closeTime, ChangeScene);
  }

  void ChangeScene() { _sceneName.ChangeScene(); }
}
