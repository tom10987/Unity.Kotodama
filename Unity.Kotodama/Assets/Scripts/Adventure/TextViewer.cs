
using UnityEngine;
using UnityEngine.UI;

public class TextViewer : MonoBehaviour {

  public string[] text;                       // テキストの格納

  [SerializeField]
  Text uiText;                                // uiTextの参照

  [SerializeField, Range(0.001f, 2.0f)]
  float intervalForCharacterDisplay = 0.05f;  // 1文字の表示にかかる時間

  string currentText = string.Empty;         // 現在の文字列
  float timeUntilDisplay = 0.5f;                   // 表示にかかる時間
  float timeElapsed = 1.0f;                        // 文字列の表示を開始した時間

  int currentLine = 0;                        // 現在の行番号
  int lastUpdateCharacter = -1;               // 表示中の文字数


  public bool IsCompleteDisplayText { get { return Time.time > timeElapsed + timeUntilDisplay; } }

  void Start() {
    SetNextLine();
  }

  void Update() {
    // 現在の行番号がラストまで行っていない状態でクリックすると、テキストを更新する

    // 文字の表示が完了しているならクリック時に次の行を表示する
    if (IsCompleteDisplayText) {
      if (currentLine < text.Length && Input.GetMouseButtonDown(0)) {
        SetNextLine();
      }
    }
    // 完了していないなら文字をすべて表示する
    else {
      if (Input.GetMouseButtonDown(0)) {
        timeUntilDisplay = 0;
      }
    }

    // クリックから経過した時間が想定表示時間の何％かを確認し、表示文字数を出す
    int displayCharacterCount = (int)(Mathf.Clamp01((Time.time - timeElapsed) / timeUntilDisplay) * currentText.Length);

    // 表示文字数が前回の表示文字数と異なるならテキストを更新する
    if (displayCharacterCount != lastUpdateCharacter) {
      uiText.text = currentText.Substring(0, displayCharacterCount);
      lastUpdateCharacter = displayCharacterCount;
    }
  }

  // テキストの更新
  void SetNextLine() {
    // 現在の行のテキストをuiTextに流し込み、現在の行番号を一つ追加する
    currentText = text[currentLine];
    currentLine++;

    // 想定表示時間と現在の時刻をキャッシュ
    timeUntilDisplay = currentText.Length * intervalForCharacterDisplay;
    timeElapsed = Time.time;

    // 文字カウントを初期化
    lastUpdateCharacter = -1;
  }
}
