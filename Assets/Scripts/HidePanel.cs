using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HidePanel : MonoBehaviour
{
    public Animator Animator;
    public bool check;

    public void Hide()
    {
        check = !check;

        if (check == true)
        {
            Animator.SetBool("Hide", true);
        }
        if (check == false)
        {
            Animator.SetBool("Hide", false);
        }
    }
}
