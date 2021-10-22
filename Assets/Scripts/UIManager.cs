using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{

    public static UIManager Instance;

    public TutorialType ActiveTutorial;

    public GameObject TutorialPanel;
    public GameObject TutorialHand;
    public GameObject TutorialTextObject;
    private TMP_Text TutorialText;

    public enum TutorialType
    {
        Movement,
        Stick,
        SpeedChange,
        Jump        
    }

    void Awake()
    {
        Instance = this;
    }


    // Start is called before the first frame update
    void Start()
    {
        TutorialText = TutorialTextObject.GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OpenTutorialPopUp(TutorialType tt)
    {
        switch (tt)
        {
            case TutorialType.Movement:
                ActiveTutorial = TutorialType.Movement;
                TutorialText.text = "Move your finger left/right to Move";
                TutorialPanel.SetActive(true);
                GameMaker.Instance.StartCoroutine("CheckForMovement");
                break;

            case TutorialType.Stick:
                ActiveTutorial = TutorialType.Stick;
                TutorialText.text = "Collect Sticks to Increase Jump Power";
                TutorialPanel.SetActive(true);
                break;

            case TutorialType.Jump:
                ActiveTutorial = TutorialType.Jump;
                TutorialText.text = "Release the screen to Jump";
                TutorialPanel.SetActive(true);
                break;

            case TutorialType.SpeedChange:
                ActiveTutorial = TutorialType.SpeedChange;
                TutorialText.text = "Pull your finger up/down to Increase/Decrase Speed";
                TutorialPanel.SetActive(true);
                break;
            
        }
                
    }


    public void CloseTutorialPopUp(TutorialType tt)
    {
        if(ActiveTutorial == tt)
        {
            TutorialPanel.SetActive(false);
        }
    }

}
