using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MirrorBehaviour : MonoBehaviour
{
    // Start is called before the first frame updat

   
    public iTween.EaseType easeType;
    void Start()
    {
        iTween.RotateTo(this.gameObject, iTween.Hash("y", 90, "time", 1.5f, "easetype", easeType));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpinMirror()
    {
        iTween.RotateTo(this.gameObject, iTween.Hash("y", 90, "time", 1.5f, "easetype", easeType));
    }
}
