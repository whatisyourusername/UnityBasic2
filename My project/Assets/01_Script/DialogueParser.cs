using TMPro;
using UnityEngine;
using UnityEngine.UI; // UI를 사용하기 위해 새로 추가되었습니다.

public class DialogueParser : MonoBehaviour // 지정한 클래스 이름입니다.
{
    // [SerializeField] Image img_BG;
    // [SerializeField] Image[] CharacterImages;

    [SerializeField] Image character1Img;
    [SerializeField] Image character2Img;

    [SerializeField] TextMeshProUGUI txt_name;
    [SerializeField] TextMeshProUGUI txt_Dialogue;
    [SerializeField] TextMeshProUGUI txt_Title;
    [SerializeField] Dialogue1DB dialog1;
    [SerializeField] ResourceDB resourceDB;
    [SerializeField] DialogData[] dialogs;
    int id;
    int language;

    private void Awake()
    {
        id = 1001;

        dialogs = new DialogData[dialog1.Dialogue_Tutorial.Count]; // 배열 할당

        for (int i = 0; i < dialog1.Dialogue_Tutorial.Count; i++)
        {
            dialogs[i] = new DialogData(); // 객체도 생성
            dialogs[i].name = resourceDB.Character[dialog1.Dialogue_Tutorial[i].Character - 1].Name;
            dialogs[i].title = resourceDB.Character[dialog1.Dialogue_Tutorial[i].Character - 1].Title;
            dialogs[i].dialogue = dialog1.Dialogue_Tutorial[i].Dialogue;

            for (int j = 0; j < resourceDB.Image.Count; j++)
            {
                if (resourceDB.Image[j].CharID == dialog1.Dialogue_Tutorial[i].Character && resourceDB.Image[j].ImgID == dialog1.Dialogue_Tutorial[i].Face)
                {
                    dialogs[i].imgName = resourceDB.Image[j].Name;
                }
            }
        }
    }


    void Start()
    {
        id = 1001;
        language = 0;

        showDialog();
    }

    public void ClickLanguageButton(int number)
    {
        language = number;
        if (language == 0)
        {
            for (int i = 0; i < dialog1.Dialogue_Tutorial.Count; i++)
            {
                dialogs[i].dialogue = dialog1.Dialogue_Tutorial[i].Dialogue;
            }
        }
        else if (language == 1)
        {
            for (int i = 0; i < dialog1.Dialogue_Tutorial.Count; i++)
            {
                dialogs[i].dialogue = dialog1.Dialogue_Tutorial[i].Dialogue_En;
            }
        }
        showDialog();
    }

    public void ClickNextButton()
    {
        if (id < 1000 + dialogs.Length)
        {
            id++;
        }
        else
        {
            id = 1001;
        }
        showDialog();
    }

    public void showDialog()
    {
        txt_name.text = dialogs[id - 1001].name;
        txt_Dialogue.text = dialogs[id - 1001].dialogue;
        txt_Title.text = dialogs[id - 1001].title;

        if (txt_name.text == dialogs[0].name)
        {
            character1Img.sprite = Resources.Load<Sprite>($"Images/Characters/{dialogs[id - 1001].imgName}");
            character1Img.color = Color.white;
            character2Img.color = Color.gray;
        }
        else if (txt_name.text == dialogs[1].name)
        {
            character2Img.sprite = Resources.Load<Sprite>($"Images/Characters/{dialogs[id - 1001].imgName}");
            character1Img.color = Color.gray;
            character2Img.color = Color.white;
        }
        Debug.Log(dialogs[id - 1001].imgName);
    }
}