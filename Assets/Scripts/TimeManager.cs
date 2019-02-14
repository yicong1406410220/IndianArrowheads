using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager{

    //得到时间轴
    public static double GetTimestamp(DateTime d)
    {
        TimeSpan ts = d - new DateTime(1970, 1, 1);
        return ts.TotalSeconds;
    }

    public static double GetNow()
    {
        double now = GetTimestamp(DateTime.Now);
        return now;
    }


}
