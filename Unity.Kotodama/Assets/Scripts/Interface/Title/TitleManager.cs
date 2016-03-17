
using UnityEngine;
using System.Collections;

public class TitleManager : MonoBehaviour {

  [SerializeField]
  CanvasGroup _mode = null;

  [SerializeField]
  CanvasGroup _chapterButton = null;

  [SerializeField]
  CanvasGroup _chapterLogo = null;

  [SerializeField]
  ButtonAlphaController _controller = null;

  [SerializeField]
  [Range(0.5f, 2.0f)]
  float _alphaSpeed = 1f;

  void Start() {
    InitializeCanvas(_mode, 1f);
    InitializeCanvas(_chapterButton, 0f);
    InitializeCanvas(_chapterLogo, 0f);
    _chapterLogo.interactable = true;
  }

  public void ChangeState(bool isChapter) { StartCoroutine(StateShift(isChapter)); }

  IEnumerator StateShift(bool isChapter) {
    SetValidate(_mode, false);
    SetValidate(_chapterButton, false);
    SetValidate(_chapterLogo, false);

    var time = 0f;

    while (time < _alphaSpeed) {
      time += Time.deltaTime;
      _mode.alpha = isChapter ? 1f - time : time;
      _chapterButton.alpha = isChapter ? time : 1f - time;
      _chapterLogo.alpha = isChapter ? time : 1f - time;
      _controller.UpdateAlpha(_chapterButton.alpha);
      yield return null;
    }

    SetValidate(_mode, !isChapter);
    SetValidate(_chapterButton, isChapter);
    SetValidate(_chapterLogo, isChapter);
  }

  void InitializeCanvas(CanvasGroup canvas, float alpha) {
    canvas.alpha = alpha;
    SetValidate(canvas, alpha > 0f);
  }

  void SetValidate(CanvasGroup canvas, bool state) {
    canvas.interactable = state;
    canvas.blocksRaycasts = state;
  }
}
