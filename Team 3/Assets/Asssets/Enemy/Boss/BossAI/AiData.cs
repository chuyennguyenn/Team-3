using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiData : MonoBehaviour
{
   public List<Transform> targets=null;
    public Collider2D[] obstacles=null;

    public Transform currTarget;

    public int GetTargetsCount() => targets == null ? 0 : targets.Count;    
}
