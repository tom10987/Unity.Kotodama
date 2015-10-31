using UnityEngine;


public class TitleScript : MonoBehaviour {

  [SerializeField]
  GameObject StartCanvas;

  [SerializeField]
  GameObject SelectCanvas;

  [SerializeField]
  bool _changeCan = true;

  void Start() {
    StartCanvas.SetActive(_changeCan);
    SelectCanvas.SetActive(!_changeCan);
  }

  public void ChangeCanvas() {
    if (StartCanvas.activeInHierarchy) { _changeCan = !_changeCan; }
    else { _changeCan = !_changeCan; }

    StartCanvas.SetActive(_changeCan);
    SelectCanvas.SetActive(!_changeCan);
  }
}