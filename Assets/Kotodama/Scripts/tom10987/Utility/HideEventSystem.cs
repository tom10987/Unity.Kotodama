
using UnityEngine;
using UnityEngine.EventSystems;


public class HideEventSystem : MonoBehaviour {

  // 自分以外の EventSystem が見つかったら自分を無効化する
  void Awake() {
    var system = FindObjectOfType<EventSystem>();
    if (system != this) { gameObject.SetActive(false); }
  }
}
