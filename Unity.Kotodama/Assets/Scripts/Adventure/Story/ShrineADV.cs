
using UnityEngine;


public class ShrineADV : MonoBehaviour {

  /// <summary>
  /// このスクリプトがついてるオブジェクトについている
  /// 「EventState.cs」を必ず読み込む！
  /// </summary>
  EventState state;
  NovelSystem novel;

  public int _int = 0;
  public float _float = 0f;
  public

  void Start() {
    state = gameObject.GetComponentInChildren<EventState>();
    //    state._entry = ;
  }

  public string[,] firstEvent =
  {
      { Command.start, "", "", "" },
      { Command.act, "", "", "" },
      { Command.name, CharaName.mari, "", "" },
      { Command.text, "「ここは？…」", "", "" },
      { Command.name, CharaName.nana, "", "" },
      { Command.text, "「…あいつらはいないみたいだね」", "", "" },
      { Command.name, CharaName.mari, "", "" },
      { Command.text, "「これからどうしよう…\n私帰りたい」", "", "" },
      { Command.name, CharaName.nana, "", "" },
      { Command.text, "「大丈夫。きっとここから出る方法があるはずだよ」", "", "" },
      { Command.name, CharaName.mari, "", "" },
      { Command.text, "「本当に？」", "", "" },
      { Command.name, CharaName.nana, "", "" },
      { Command.text, "「私はこんな姿だから、遠くには行けなかったけど…」", "", "" },
      { Command.name, CharaName.nana, "", "" },
      { Command.text, "「もしかしたら、この世界のどこかに帰るためのヒントがあるかもしれない」", "", "" },
      { Command.name, CharaName.mari, "", "" },
      { Command.text, "「でも恐いな…」", "", "" },
      { Command.name, CharaName.nana, "", "" },
      { Command.text, "「大丈夫。私がついてるよ」", "", "" },
      { Command.name, CharaName.mari, "", "" },
      { Command.text, "「…うん」", "", "" },
      { Command.name, CharaName.narrator, "", "" },
      { Command.text, "掲示板を調べると張り紙を見ることができます", "", "" },
      { Command.text, "この世界から脱出する為のヒントが書かれているかもしれないので、積極的に見ていきましょう", "", "" },
      { Command.end, "", "", "" },
    };

  public string[,] endTutorial =
  {
        { Command.start, "", "", "" },
        { Command.name, CharaName.mari, "", "" },
        { Command.text, "「お札が…神社に勝手に入っちゃったよ？」", "", "" },
        { Command.name, CharaName.nana, "", "" },
        { Command.text, "「……あれ、足元に何か落ちてる！」", "", "" },
        { Command.name, CharaName.mari, "", "" },
        { Command.text, "「本当だ。これは…ねずみのぬいぐるみ？」", "", "" },
        { Command.name, CharaName.nana, "", "" },
        { Command.text, "「違うよ！\nこれはどう見てもカバでしょ！」", "", "" },
        { Command.name, CharaName.mari, "", "" },
        { Command.text, "「カバ？…」", "", "" },
        { Command.name, CharaName.nana, "", "" },
        { Command.text, "「わかるんだ…これ、私のだもん」", "", "" },
        { Command.name, CharaName.mari, "", "" },
        { Command.text, "「これ、あなたの物なの？」", "", "" },
        { Command.name, CharaName.nana, "", "" },
        { Command.text, "「うん。これをもらった時ね、なんでカバなのー！って誰かに怒ったような気がするんだ…いつだっけ…", "", "" },
        { Command.name, CharaName.mari, "", "" },
        { Command.text, "「確かに、なんでカバなんだろうね」", "", "" },
        { Command.name, CharaName.nana, "", "" },
        { Command.text, "「でも、凄く大切だった気もするの」", "", "" },
        { Command.name, CharaName.mari, "", "" },
        { Command.text, "「そっか…それにしても、どうしてこんな所に？」", "", "" },
        { Command.name, CharaName.nana, "", "" },
        { Command.text, "「神社さんが…くれたのかな？」", "", "" },
        { Command.end, "", "", "" },
    };

}
