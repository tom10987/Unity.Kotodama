
using UnityEngine;


public class BetaManager : MonoBehaviour {

  [SerializeField]
  string _jsonName = string.Empty;

  [SerializeField]
  string _nextScene = string.Empty;

  bool _isStart = false;


  void Update() {
    if (!_isStart) {
      Adventure.instance.Activate(_jsonName);
      _isStart = true;
      return;
    }

    if (!Adventure.instance.isActiveAndEnabled) { SceneSequencer.instance.SceneFinish(_nextScene); }
  }
}
