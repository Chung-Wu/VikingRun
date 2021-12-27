using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour, IPointerClickHandler
{
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnPointerClick(PointerEventData e)
    {
        Scene scene = SceneManager.GetActiveScene();
        

        if(scene.buildIndex == 0)
        {
            //SceneManager.LoadScene("SampleScene");


            if (this.name == "Button")
            {
                SceneManager.LoadScene("SampleScene");
            }
            else if (this.name == "HowToPlay_btn")
            {
                SceneManager.LoadScene("HowToPlay_Scene");
            }
            else if(this.name == "Exit")
            {
                Application.Quit();
            }
        }
        else if(scene.buildIndex == 2)
        {
            SceneManager.LoadScene("Menu");
        }
        
    }

}
