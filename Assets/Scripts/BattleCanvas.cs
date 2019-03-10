using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.EventSystems;

public class BattleCanvas : MonoBehaviour {
    [SerializeField] Button pauseButton;
    [SerializeField] GameObject scoreTip;
    [SerializeField] Image bgImage;
    [SerializeField] GameObject prop1;
    [SerializeField] GameObject prop2;
    [SerializeField] GameObject prop3;
    [SerializeField] Text diamondText;
    [SerializeField] Text levelText;
    [SerializeField] GameObject scoreFlowText;
    [SerializeField] GameObject scoreStarContainer;
    ScoreTipPanel scoreTipPanel;

    static BattleCanvas instance;
    static public BattleCanvas Instance
    {
        get
        {
            if(instance == null)
            {
                instance = GameObject.Instantiate(Resources.Load<BattleCanvas>("Prefabs/UI/BattleCanvas"));
                instance.Init();
            }
            return instance;
        }
    }

    public void Init()
    {
        GetComponent<Canvas>().worldCamera = Camera.main;
        pauseButton.onClick.AddListener(OnClickPauseButton);

        //TODO： 初始化道具点击事件
    }

    public void SetBgImage(string name)
    {
        bgImage.sprite = Resources.Load<Sprite>("Textures/" + name);
    }

    public void SetScoreTipPanel(string name)
    {
        if (scoreTipPanel != null)
            GameObject.Destroy(scoreTipPanel);

        scoreTipPanel = GameObject.Instantiate(Resources.Load<ScoreTipPanel>("Prefabs/UI/" + name), scoreTip.transform, false);
    }

    public ScoreTipPanel GetScoreTipPanel()
    {
        return scoreTipPanel;
    }


    public void SetLevelText(int level)
    {
        levelText.text = level.ToString();
    }

    public void SetDiamondText(int count)
    {
        diamondText.text = count.ToString();
    }

    public void SetProp1Image(string name)
    {
        prop1.transform
             .Find("Button")
             .GetComponent<Image>()
             .sprite = Resources.Load<Sprite>("Textures/" + name);
    }

    public void SetProp2Image(string name)
    {
        prop2.transform
              .Find("Button")
              .GetComponent<Image>()
              .sprite = Resources.Load<Sprite>("Textures/" + name);
    }

    public void SetProp3Image(string name)
    {
        prop3.transform
              .Find("Button")
              .GetComponent<Image>()
              .sprite = Resources.Load<Sprite>("Textures/" + name);
    }


    public void SetProp1Count(int count)
    {
        Text propText = prop1.transform.Find("Text").GetComponent<Text>();
        Image propPurImage = prop1.transform.Find("Image").GetComponent<Image>();

        if (count == 0)
        {
            propText.gameObject.SetActive(false);
            propPurImage.gameObject.SetActive(true);
        }
        else
        {
            propText.gameObject.SetActive(true);
            propPurImage.gameObject.SetActive(false);
        }

        propText.text = count.ToString();
    }

    public void SetProp2Count(int count)
    {
        Text propText = prop2.transform.Find("Text").GetComponent<Text>();
        Image propPurImage = prop2.transform.Find("Image").GetComponent<Image>();

        if (count == 0)
        {
            propText.gameObject.SetActive(false);
            propPurImage.gameObject.SetActive(true);
        }
        else
        {
            propText.gameObject.SetActive(true);
            propPurImage.gameObject.SetActive(false);
        }

        propText.text = count.ToString();
    }

    public void SetProp3Count(int count)
    {
        Text propText = prop3.transform.Find("Text").GetComponent<Text>();
        Image propPurImage = prop3.transform.Find("Image").GetComponent<Image>();

        if (count == 0)
        {
            propText.gameObject.SetActive(false);
            propPurImage.gameObject.SetActive(true);
        }
        else
        {
            propText.gameObject.SetActive(true);
            propPurImage.gameObject.SetActive(false);
        }

        propText.text = count.ToString();
    }

    public void AddScore(int socre)
    {
        var playerMinerEntity = EntityManager.Instance.GetPlayerMinerEntity();
        playerMinerEntity.score += socre;

        string scoreText = playerMinerEntity.score + " / "
                             + EntityManager.Instance.GetLevelEntity().passScore;

        BattleCanvas.Instance.GetScoreTipPanel().SetScoreText(scoreText);
        BattleCanvas.Instance.AddScoreFlowText(socre);
    }

  
    public void AddMinerControlDetector(PlayerMiner playerMiner)
    {
        EventTrigger eventTrigger = bgImage.gameObject.GetComponent<EventTrigger>()
                                      ?? bgImage.gameObject.AddComponent<EventTrigger>();

        EventTrigger.Entry entry = new EventTrigger.Entry();
        entry.callback.AddListener((BaseEventData data) =>
        {
            if (playerMiner.IsDropAble())
                playerMiner.Drop();
        });
        entry.eventID = EventTriggerType.PointerDown;
        eventTrigger.triggers.Add(entry);
    }


    public void AddScoreStar()
    {
        const float startX = -70f;
        const float startY = -63f;
        const float gapX = 70f;
        const float endY = 0f;
        int starCount = scoreStarContainer.transform.childCount;
        GameObject scoreStar = GameObject.Instantiate(Resources.Load<GameObject>("Prefabs/UI/ScoreStar"));
        scoreStar.transform.position = new Vector3(startX + starCount * gapX, startY, 0);
        scoreStar.transform.SetParent(scoreStarContainer.transform, false);
        scoreStar.transform.DOLocalMoveY(endY, 1f);
    }


    void OnClickPauseButton()
    {
        pauseButton.transform.DOScale(1.08f, 0.1f).OnComplete(()=> {
            pauseButton.transform.DOScale(1f, 0.1f);
        });
        SoundManager.instance.PlayBtn();
        PanelMgr.instance.OpenPanel<MusicSettingPanel>("");
    }


    void AddScoreFlowText(int score)
    {
        FlowTextCreator.CreateScoreFlowText(scoreFlowText.transform.localPosition, score.ToString(), 15f, 0.4f)
                       .transform
                       .SetParent(transform, false);
    }

}

