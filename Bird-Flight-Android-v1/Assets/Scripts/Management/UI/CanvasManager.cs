using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;




public enum CanvasType
{
    MainMenu = 0, Credits = 1, InGameMenu = 2

}

public class CanvasManager : Singleton<CanvasManager>
{
    List<CanvasController> canvasControllerList;
    CanvasController lastActiveCanvas;

    void Awake()
    {
        canvasControllerList = GetComponentsInChildren<CanvasController>().ToList(); //Beginning of canvas related stuff

        canvasControllerList.ForEach(x => x.gameObject.SetActive(false)); //Deactivate all canvas

        SwitchCanvas(CanvasType.MainMenu);

    }


    public void SwitchCanvas(CanvasType _type)
    {
        if (lastActiveCanvas != null)
        {
            lastActiveCanvas.gameObject.SetActive(false);
        }

        CanvasController desiredCanvas = canvasControllerList.Find(x => x.canvasType == _type);

        if (desiredCanvas != null)
        {
            desiredCanvas.gameObject.SetActive(true);
            lastActiveCanvas = desiredCanvas;
        }
        else
        {
            Debug.Log("The desired canvas can't be found.");
        }
    }

}
