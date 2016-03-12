
using UnityEngine;


public class GoToShrine : MonoBehaviour {

  WindowManager window { get { return WindowManager.instance; } }

  [SerializeField]
  [Tooltip("神社エリアの開始地点を設定")]
  Vector3 _shrinePosition = Vector3.zero;

  [SerializeField]
  string _telop = string.Empty;


  void OnTriggerEnter(Collider other) {
    if (other.tag != ObjectTag.Player.ToString()) { return; }

    // TIPS: プレイヤーを停止、神社エリアのスタート地点を設定
    PlayerState.instance.Stop();
    GameManager.instance.playerStartPosition = _shrinePosition;

    //window.CreateCommandWindow(_telop, OnYes);
  }

  void OnYes() {
    //window.DestroyWindow();
    //SceneSequencer.instance.SceneFinish(SceneTag.Shrine.ToString());
  }
}
