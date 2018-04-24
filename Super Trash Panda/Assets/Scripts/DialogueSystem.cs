using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueSystem : MonoBehaviour {
    public GameObject textBoxBG;
    public Text textBox;

    public Dialogue[] dialogues;

    public void StratDialogue()
    {
        StartCoroutine(Text());
    }

    public IEnumerator Text()
    {
        ShowTextBox();
        foreach(Dialogue dialogue in dialogues)
        {
            if(dialogue.speakerName == "")
            {
                yield return (ChangeText(dialogue.sentence, 0, 0.01f));
            }
            else
            {
                yield return (ChangeText(dialogue.speakerName +":\n"+dialogue.sentence, dialogue.speakerName.Length + 1, 0.01f));
            }
            
        }
        CloseTextBox();
    }

    IEnumerator ChangeText(string text, int starting, float interval)
    {
        for(int x = starting; x<= text.Length; ++x)
        {
            textBox.text = text.Substring(0, x);
            yield return new WaitForSeconds(interval);
        }
        yield return new WaitUntil(() => Input.GetButtonDown("Fire1"));
    }

    public void ShowTextBox()
    {
        textBoxBG.SetActive(true);
    }

    public void CloseTextBox()
    {
        textBoxBG.SetActive(false);
    }

}
