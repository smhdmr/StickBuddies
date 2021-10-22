using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TutorialTrigger : MonoBehaviour
{
    public UIManager.TutorialType TutorialType;

    public GameObject TutorialPanel;
    public GameObject TutorialHand;
    public GameObject TutorialTextObject;
    private TMP_Text TutorialText;
      
        
    // Start is called before the first frame update
    void Start()
    {
        TutorialText = TutorialTextObject.GetComponent<TMP_Text>();        
    }

    
    private void OpenPopUp(UIManager.TutorialType tt)
    {
        UIManager.Instance.OpenTutorialPopUp(TutorialType);
    }


    private void ClosePopUp(UIManager.TutorialType tt)
    {
        UIManager.Instance.CloseTutorialPopUp(UIManager.Instance.ActiveTutorial);
    }

    void OnTriggerEnter(Collider other)
    {        
        OpenPopUp(TutorialType);        
    }

}
