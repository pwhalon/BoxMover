using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectiveScript : MonoBehaviour
{
    public bool isActive;
    public List<Step> steps;

    public class Step {
        public string title;
        public Action action;
    }
}
