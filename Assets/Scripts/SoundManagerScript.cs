using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagerScript : MonoBehaviour
{
    public static AudioClip enemyExplodeSound, takeDMGSound;
    static AudioSource audioSrc;

    // Start is called before the first frame update
    void Start()
    {
        enemyExplodeSound = Resources.Load<AudioClip>("enemyexplode");
        takeDMGSound = Resources.Load<AudioClip>("playertakedmg");

        audioSrc = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void PlaySound(string clip)
    {
        switch (clip)
        {
            case "enemyexplode":
                audioSrc.PlayOneShot(enemyExplodeSound);
                break;
            case "playertakedmg":
                audioSrc.PlayOneShot(takeDMGSound);
                break;
        }
    }
}
