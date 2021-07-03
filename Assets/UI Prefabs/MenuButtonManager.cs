using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class MenuButtonManager : MonoBehaviour
{
    public GameObject buttonPrefab;
    public GameObject menuWindow;
    private RectTransform windowTransform;
    public Object returnedValue;

    private void Start()
    {
        windowTransform = menuWindow.GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //This mutates the buttons it's provided, technically, though they're doing nothing afterwards. 
    //Probably use a better pattern
    public async Task<T> getResultFromSelection<T>(List<SelectButton<T>> buttons)
    {
        MenuResult<T> result = new MenuResult<T>();
        buttons.ForEach(button => {button.result = result;});
        Debug.Log("The buttons have been added");
        addButtons(buttons);

        T resultVal = await result.getResult();
        clearButtons();
        Debug.Log("The buttons have been cleared");
        return resultVal;
    }

    public void addButtons<T>(List<SelectButton<T>> buttonsToAdd)
    {
        buttonsToAdd.ForEach((button) =>
        {
            addButton(button);
        });
    }

    public void addButton<T>(SelectButton<T> selectButton)
    {
        GameObject newButton = Instantiate(buttonPrefab, menuWindow.gameObject.transform);

        Image img = newButton.GetComponent<Image>();
        Button btn = newButton.GetComponent<Button>();

        img.color = selectButton.buttonColor;
        btn.onClick.AddListener(() => { selectButton.result.set(selectButton.returnValue);});
        btn.GetComponentInChildren<Text>().text = selectButton.displayText;

        float windowWidth = windowTransform.rect.width;

        RectTransform pos = newButton.GetComponent<RectTransform>();
        int count = menuWindow.transform.childCount;
        float yPos = (windowTransform.rect.height * -0.6f) * ((count - 1) / 2) ;
        float xPos = count % 2 == 1 ? pos.rect.x : pos.rect.x + 0.5f * windowWidth;
        pos.anchoredPosition = new Vector2(xPos, yPos);
        pos.sizeDelta = new Vector2(windowWidth / 2, windowTransform.rect.height / 2);
    }

    public void clearButtons()
    {
        foreach (Transform child in menuWindow.gameObject.transform)
        {
            GameObject.Destroy(child.gameObject);
        }
        menuWindow.gameObject.transform.DetachChildren();
    }

}
