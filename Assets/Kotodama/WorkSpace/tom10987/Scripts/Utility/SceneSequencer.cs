
using UnityEngine;


public class SceneSequencer : MonoBehaviour {

  [SerializeField]
  [Tooltip("次のシーンの名前")]
  string _nextScene = null;

  ScreenEffect _effect = null;


  /// <summary>
  /// シーンをフェードアウトさせながら終了する
  /// </summary>
  public void SceneFinish(string nextSceneName = null) {
    if (_effect.IsFadeTime()) { return; }
    if (nextSceneName != null) { _nextScene = nextSceneName; }
    _effect.FadeOutStart();
  }


  void Awake() {
    if (_nextScene == null) { _nextScene = "Title"; }
  }

  void Start() {
    _effect = FindObjectOfType<ScreenEffect>();
  }

  void Update() {
    if (!_effect.IsFadeFinish()) { return; }
    Application.LoadLevel(_nextScene);
  }
}
