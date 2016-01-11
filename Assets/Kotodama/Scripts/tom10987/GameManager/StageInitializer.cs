
using UnityEngine;


public class StageInitializer : MonoBehaviour {

  [SerializeField]
  uint _bgmNumber = 0;


  void Start() {
    AudioManager.instance.bgm.Play(_bgmNumber);
  }
}
