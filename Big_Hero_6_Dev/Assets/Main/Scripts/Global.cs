using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Global : MonoBehaviour
{
    public static bool tutorial1 = false;
    public static bool tutorial2 = false;
    public static bool showTutorial2 = false;

    public static bool yellowKey = false;
    public static bool redKey = false;
    public static bool gamePause = false;
    public static bool deathHandled = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(deathHandled);
        Debug.Log(gamePause);
    }
}
