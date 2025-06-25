using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowContent : StateMachineBehaviour
{
    public MyTabs book;
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       book.ShowTab2();
    }
}
