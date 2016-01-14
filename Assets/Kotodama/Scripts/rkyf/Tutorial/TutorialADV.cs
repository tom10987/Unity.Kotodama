
using UnityEngine;


public class TutorialADV : MonoBehaviour {

  EventState _tutorial = null;

  void Start() {
    _tutorial = gameObject.GetComponentInChildren<EventState>();
  }

  public readonly string[,] Sentence = {
    { Command.start, "", "", "", },
    { Command.act, "GameStart", "", "", },
    { Command.name, CharaName.narrator, "", "", },
    { Command.text, "マリという少女がいた。", "", "", },
    { Command.text, "彼女は学校で独りぼっち。", "", "", },
    { Command.text, "それが原因で部屋から出なくなった。", "", "", },
    { Command.text, "それから彼女は「夢」に囚われるようになった。", "", "", },
    { Command.text, "「夜」の夢を。", "", "", },
    { Command.text, "彼女は「暗夜の夢」に囚われ、そしてランタンを手にした。", "", "", },
  };

  public readonly string[,] Sentence2 = {
    { Command.start, "", "", "", },
    { Command.act, "StageStart", "", "", },
    { Command.name, CharaName.mari, "", "", },
    { Command.text, "少しは…明るくなったかな", "", "", },
    { Command.name, CharaName.nana, "", "", },
    { Command.text, "だーれ？", "", "", },
    { Command.name, CharaName.mari, "", "", },
    { Command.text, "………………", "", "", },
    { Command.text, "火がしゃべってる…？", "", "", },
    { Command.name, CharaName.nana, "", "", },
    { Command.text, "あんまり驚かないんだね", "", "", },
    { Command.name, CharaName.mari, "", "", },
    { Command.text, "…だって、ここは私の夢の中でしょう？", "", "", },
    { Command.name, CharaName.nana, "", "", },
    { Command.text, "何を言ってるの…？", "", "", },
    { Command.name, CharaName.mari, "", "", },
    { Command.text, "最近こういう夢をよく見るんだ。\n暗い夜の夢", "", "", },
    { Command.name, CharaName.nana, "", "", },
    { Command.text, "ここは夢じゃないよ。暗くて、寂しくて、", "", "", },
    { Command.text, "\"あいつら\"が巣くう場所なんだ", "", "", },
    { Command.name, CharaName.mari, "", "", },
    { Command.text, "あなたは何か知ってるの？", "", "", },
    { Command.name, CharaName.nana, "", "", },
    { Command.text, "ううん。ただ、そういう場所だってことは知ってる…\nでも、私が何でこんなところにいるのかも、誰だったのかも覚えてないの……", "", "", },
    { Command.name, CharaName.mari, "", "", },
    { Command.text, "元々は人間だったの？", "", "", },
    { Command.name, CharaName.nana, "", "", },
    { Command.text, "そのはず…", "", "", },
    { Command.text, "", "", "", },
    { Command.text, "っ！", "", "", },
    { Command.name, CharaName.mari, "", "", },
    { Command.text, "どうしたの？", "", "", },
    { Command.name, CharaName.nana, "", "", },
    { Command.text, "近くにいる…\nきっと\"あいつら\"だ…", "", "", },
    { Command.text, "ここを離れよう！", "", "", },
  };

  public readonly string[,] Sentence3 = {
    { Command.start, "", "", "", },
    { Command.act, "FirstItem", "", "", },
    { Command.name, CharaName.mari, "", "", },
    { Command.text, "なんだろう…これ", "", "", },
    { Command.name, CharaName.nana, "", "", },
    { Command.text, "お札…かな？", "", "", },
    { Command.name, CharaName.mari, "", "", },
    { Command.text, "初めて見た、お札", "", "", },
    { Command.name, CharaName.nana, "", "", },
    { Command.text, "なんでこんな所にあるんだろう…", "", "", },
    { Command.name, CharaName.mari, "", "", },
    { Command.text, "とりあえず持っていこうか", "", "", },
  };
}
