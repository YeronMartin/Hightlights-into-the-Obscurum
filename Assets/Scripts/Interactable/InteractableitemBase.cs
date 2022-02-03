using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableitemBase : MonoBehaviour
{
    // Start is called before the first frame update

    public string Name;
    public Sprite Image;
    public string interactText;

    public virtual void  OnInteract()
    {

    }

    }
