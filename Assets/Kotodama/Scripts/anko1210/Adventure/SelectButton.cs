
using UnityEngine;
using UnityEngine.UI;


public class SelectButton : MonoBehaviour {

  EventResource state { get { return EventResource.instance; } }
  NovelSystem novel { get { return NovelSystem.instance; } }

  private Text _buttonText;

  public string _actName;
  public string _goTo;

  void Start() {
    _buttonText = this.gameObject.GetComponentInChildren<Text>();
    _buttonText.text = _actName;
  }

  public void IsSelect() {
    if (_goTo == "through") {
      novel._msgCur++;
      novel._isChoices = true;
    }
    else if (!state._act.ContainsKey(_goTo)) {
      Debug.Log("NO ENTRY IS" + _goTo);
      return;
    }
    else {
      novel._msgCur = state._act[_goTo];
      novel._isChoices = true;
    }
  }
}
