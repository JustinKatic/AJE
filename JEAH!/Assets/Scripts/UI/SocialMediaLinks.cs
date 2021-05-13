using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SocialMediaLinks : MonoBehaviour
{
    public string url;

    public void OpenURL()
    {
        Application.OpenURL(url);
    }
}
