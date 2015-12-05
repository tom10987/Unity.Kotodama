
using UnityEngine;
using UnityEngine.EventSystems;


public class HideEventSystem : MonoBehaviour {

  // 自分以外の EventSystem が見つかったら自分を無効化する
  void Awake() {
    var system = FindObjectsOfType<EventSystem>();
    if (system.Length > 1) { gameObject.SetActive(false); }
  }
}
