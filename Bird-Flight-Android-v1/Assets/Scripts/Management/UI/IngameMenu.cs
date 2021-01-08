using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IngameMenu : MonoBehaviour
{
    public Transform player;
    public GameObject pauseMenu;

    public float currentPos, maxPos;

    private void Awake()
    {
        pauseMenu.SetActive(false);
    }
    // Start is called before the first frame update
    void Start()
    {

        currentPos = player.position.y;
        maxPos = player.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        currentPos = player.position.y;
        if (maxPos < currentPos)
            maxPos = currentPos;
        else if (maxPos > currentPos + 6f)
            pauseMenu.SetActive(true);
    }
}
