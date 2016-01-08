
using UnityEngine;
using System.Collections.Generic;


public class MaholeEvent : MonoBehaviour {

  [SerializeField]
  private string _chapter;

  EventState state;

  private Dictionary<string, string[,]> _chapterList = new Dictionary<string, string[,]>();


  void Start() {
    state = gameObject.GetComponentInChildren<EventState>();
    _chapterList.Add("event1", event1);
    _chapterList.Add("event2", event2);
    state._entry = _chapterList[_chapter];
  }

  public string[,] event1 = {
    { Command.start, "", "", "" },
    { Command.act,   "event1", "", "" },
    { Command.image, CharaName.mari, ImageName.MARI_NORMAL, ImagePosition.center },
    { Command.name,  CharaName.mari, "", "" },
    { Command.text,  "「ここはどこだろう…」", "", "" },
    { Command.image, CharaName.nana, ImageName.NANA_NORMAL, ImagePosition.right },
    { Command.image, CharaName.mari, ImageName.MARI_NORMAL, ImagePosition.left },
    { Command.name,  CharaName.nana, "", "" },
    { Command.text,  "「うーん…」", "", "" },
    { Command.text,  "「とりあえず先行こう？」", "", "" },
    { Command.name,  CharaName.mari, "", "" },
    { Command.text,  "「うん…」", "", "" },

    { Command.end,   "", "", "" },
  };

  public string[,] event2 = {
    { Command.start, "", "", "" },
    { Command.act,   "event2", "", "" },
    { Command.image, CharaName.nana, ImageName.NANA_NORMAL, ImagePosition.right },
    { Command.name,  CharaName.nana, "", "" },
    { Command.text,  "「あそこ、変なのがいるね！」", "", "" },
    { Command.image, CharaName.mari, ImageName.MARI_NORMAL, ImagePosition.left },
    { Command.name,  CharaName.mari, "", "" },
    { Command.text,  "「あ、ほんとだ」", "", "" },
    { Command.name, CharaName.nana, "", "" },
    { Command.text,  "「近付かない方がいいよね！」", "", "" },
    { Command.name,  CharaName.mari, "", "" },
    { Command.text,  "（どうなんだろ）", "", "" },
    { Command.end,   "", "", "" },
  };
}
