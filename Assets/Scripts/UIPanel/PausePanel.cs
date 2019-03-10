using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PausePanel : PanelBase {

    public static PausePanel instance;

    public Image MusicON;
    public Image MusicOFF;
    public Image SoundON;
    public Image SoundOFF;

    public override void Init(params object[] args)
    {
        base.Init(args);
        layer = PanelLayer.Panel;
        instance = this;
        ResMusicPanel();
    }

    private void ResMusicPanel()
    {
        bool DB_CloseMusic = KeyValue.GetBool("DB_CloseMusic");
        bool DB_CloseSound = KeyValue.GetBool("DB_CloseSound");
        if (DB_CloseMusic)
        {
            MusicON.gameObject.SetActive(false);
            MusicOFF.gameObject.SetActive(true);
        }
        else
        {
            MusicON.gameObject.SetActive(true);
            MusicOFF.gameObject.SetActive(false);
        }
        if (DB_CloseSound)
        {
            SoundON.gameObject.SetActive(false);
            SoundOFF.gameObject.SetActive(true);
        }
        else
        {
            SoundON.gameObject.SetActive(true);
            SoundOFF.gameObject.SetActive(false);
        }
        MusicManager.instance.RefreshSound();
        SoundManager.instance.RefreshSound();
    }

    public void ClickMusic()
    {
        bool DB_CloseMusic = KeyValue.GetBool("DB_CloseMusic");
        KeyValue.SetBool("DB_CloseMusic", !DB_CloseMusic);
        ResMusicPanel();
        SoundManager.instance.PlayBtn();
    }

    public void ClickSound()
    {
        bool DB_CloseSound = KeyValue.GetBool("DB_CloseSound");
        KeyValue.SetBool("DB_CloseSound", !DB_CloseSound);
        ResMusicPanel();
        SoundManager.instance.PlayBtn();
    }

    public override void OnShowing()
    {
        base.OnShowing();
    }

    public void OnLVButton()
    {
        SoundManager.instance.PlayBtn();
        SceneJump.instance.Jump(SceneType.Map);
    }

    public void OnReplayButton()
    {
        SoundManager.instance.PlayBtn();
        SceneJump.instance.Jump(SceneType.Game);
    }

    public void OnGoGameButton()
    {
        SoundManager.instance.PlayBtn();
        Close();
    }
}
