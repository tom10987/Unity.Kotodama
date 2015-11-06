
using UnityEngine;


public class SceneSequencer : MonoBehaviour {

  [SerializeField]
  [Tooltip("次のシーンの名前")]
  string _nextScene = null;


  /// <summary>
  /// シーンをフェードアウトさせながら終了する
  /// </summary>
  public void SceneFinish(string nextSceneName = null) {
    if (ScreenEffect.IsFadeTime()) { return; }
    if (nextSceneName != null) { _nextScene = nextSceneName; }
    ScreenEffect.FadeOutStart();
  }


  void Awake() {
    if (_nextScene == null) { _nextScene = "Title"; }
  }

  void Update() {
    if (!ScreenEffect.IsFadeFinish()) { return; }
    Application.LoadLevel(_nextScene);
  }
}
