using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopMenuPanel : MonoBehaviour
{
    Animator _animator;
    bool check;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    public void MenuOnOff()
    {
        check = !check;
        if (check)
        {
            _animator.SetBool("Menu", true);
        }
        if (!check)
        {
            _animator.SetBool("Menu", false);
        }
    }

}
