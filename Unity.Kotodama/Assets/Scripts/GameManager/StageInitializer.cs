
using UnityEngine;

public class StageInitializer : MonoBehaviour {

  [SerializeField]
  uint _bgmNumber = 0;

  [SerializeField]
  Transform _start = null;

  void Start() {
    PlayerState.instance.transform.position = _start.position;
    PlayerState.instance.Translate(_start.position);
    AudioManager.instance.bgm.Play(_bgmNumber);
  }
}
