using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HidePanel : MonoBehaviour
{
    Animator _animator;
    public bool check;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }
    public void Hide()
    {
        check = !check;
        if (check == true)
        {
            _animator.SetBool("Hide", true);
        }
           
        

        if (check == false)
        {
            _animator.SetBool("Hide", false);
        }
    }
}
