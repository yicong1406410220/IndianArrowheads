using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour {

    //得到时间轴
    public static double GetTimestamp(DateTime d)
    {
        TimeSpan ts = d - new DateTime(1970, 1, 1);
        return ts.TotalMilliseconds;
    }


    // 仅在首次调用 Update 方法之前调用 Start
    private void Start()
    {
        //Debug.Log(GetTimestamp(new DateTime(1970, 1, 2)));
    }

    // Update is called once per frame
    void Update () {
		
	}
}
