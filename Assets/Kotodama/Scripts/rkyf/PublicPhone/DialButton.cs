
using UnityEngine;
using UnityEngine.UI;


public class DialButton : MonoBehaviour {

  [SerializeField]
  Text _dial;

  [SerializeField]
  string _trueNumber = null;

  [SerializeField]
  int _stringLimit = 7;

  [SerializeField]
  int _hyphenPoint = 3;

  GameObject rootObject { get { return transform.root.gameObject; } }

  static public bool IsInputSuccess { get; private set; }

  void Awake() {
    IsInputSuccess = false;
    _dial.text = null;
  }

  public void OnNumber(int i) {
    if (_dial.text.Length < _stringLimit) { _dial.text += i.ToString(); }
    if (_dial.text.Length == _hyphenPoint) { _dial.text += "-"; }
  }

  public void OnBackSpace() {
    _dial.text = null;
  }

  public void OnFinish() {
    Destroy(rootObject);
  }

  public void OnEnter() {
    IsInputSuccess = (_dial.text == _trueNumber);
    Destroy(rootObject);
  }
}
