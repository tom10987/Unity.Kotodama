
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DialButton : MonoBehaviour {

  [SerializeField]
  CanvasGroup _group = null;

  [SerializeField]
  Text _dial = null;

  [SerializeField]
  string _trueNumber = string.Empty;

  [SerializeField]
  int _stringLimit = 7;

  [SerializeField]
  int _hyphenPoint = 3;

  void Awake() { StartCoroutine(StartEvent()); }

  IEnumerator StartEvent() {
    TextReset();
    _group.alpha = 0f;
    _group.interactable = false;

    while (_group.alpha < 1f) {
      _group.alpha += Time.deltaTime;
      yield return null;
    }

    _group.interactable = true;
  }

  IEnumerator DestroyEvent() {
    _group.interactable = false;

    while (_group.alpha > 0f) {
      _group.alpha -= Time.deltaTime;
      yield return null;
    }

    Destroy(gameObject);
  }

  void TextReset() { _dial.text = string.Empty; }

  public void OnNumber(int i) {
    if (_dial.text.Length < _stringLimit) { _dial.text += i.ToString(); }
    if (_dial.text.Length == _hyphenPoint) { _dial.text += "-"; }
  }

  // TIPS: * ボタン
  public void OnRemove() { TextReset(); }

  // TIPS: 戻るボタン
  public void OnFinish() { StartCoroutine(DestroyEvent()); }

  // TIPS: # ボタン
  public void OnEnter() {
    if (_dial.text == _trueNumber) { PhoneBoothEvent.instance.AwakeEvent(); }
    StartCoroutine(DestroyEvent());
  }
}
