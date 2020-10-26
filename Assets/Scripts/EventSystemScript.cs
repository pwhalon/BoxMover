using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventSystemScript : MonoBehaviour
{
    public AudioSource IntroLevelOne;
    public CapsuleController Player;

    // Start is called before the first frame update
    void Start()
    {
        IntroLevelOne = GetComponent<AudioSource>();

        IntroLevelOne.play(0);

        Player.currentObjective = new CurrentObjective("Title", new Step(TargetArea, numberOfBox));
    }
}
