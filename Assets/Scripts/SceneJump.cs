using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneJump : MonoBehaviour {

    public static SceneType NowScene = SceneType.Start;

    public GameObject IconCanvasObj;
    public GameObject MapCanvasObj;
    public GameObject StartCanvasObj;

    public static SceneJump instance;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject);
        Instantiate(StartCanvasObj);
        SceneManager.activeSceneChanged += ChangedActiveScene;
    }

    /// <summary>
    /// 根据不同
    /// </summary>
    /// <param name="current"></param>
    /// <param name="next"></param>
    private void ChangedActiveScene(Scene current, Scene next)
    {
        //string currentName = current.name;

        //if (currentName == null)
        //{
        //    // Scene1 has been removed
        //    currentName = "Replaced";
        //}

        //Debug.Log("Scenes: " + currentName + ", " + next.name);

        if (NowScene == SceneType.Start)
        {
            Instantiate(StartCanvasObj);
        }
        else if (NowScene == SceneType.Map)
        {
            Instantiate(IconCanvasObj);
            Instantiate(MapCanvasObj);
        }
        else if (NowScene == SceneType.Game)
        {
            SceneManager.LoadScene("start");
        }
    }


    // Use this for initialization
    void Start () {
        //Application.LoadLevel("start");
    }

    public void Jump(SceneType sceneType)
    {
        if (sceneType == SceneType.Start)
        {
            SceneManager.LoadScene("start");
        }
        else if (sceneType == SceneType.Map)
        {
            SceneManager.LoadScene("start");
        }
        else if (sceneType == SceneType.Game)
        {
            SceneManager.LoadScene("start");
        }
        NowScene = sceneType;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
