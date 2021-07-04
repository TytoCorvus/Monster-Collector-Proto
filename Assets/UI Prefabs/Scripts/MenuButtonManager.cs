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
    public Text text;
    private RectTransform windowTransform;

    private void Awake()
    {
        windowTransform = menuWindow.GetComponent<RectTransform>();
    }

    //This mutates the buttons it's provided, technically, though they're doing nothing afterwards. 
    //Probably use a better pattern
    public async Task<T> getResultFromSelection<T>(List<SelectButton<T>> buttons, string selectionTitle)
    {
        text.text = selectionTitle;
        MenuResult<T> result = new MenuResult<T>();
        buttons.ForEach(button => {button.result = result;});
        addButtons(buttons);

        T resultVal = await result.getResult();
        clearButtons();
        return resultVal;
    }

    public void addButtons<T>(List<SelectButton<T>> buttonsToAdd)
    {
        int contentScale = buttonsToAdd.Count / 4;
        RectTransform wt = menuWindow.GetComponent<RectTransform>();
        wt.rect.Set(wt.rect.x, wt.rect.y, wt.sizeDelta.x, wt.sizeDelta.y * contentScale);

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
        float yPos = (windowTransform.rect.height * -0.5f) * ((count - 1) / 2) - (windowTransform.rect.height * 0.25f);
        float xPos = count % 2 == 1 ? windowWidth * 0.25f : windowWidth * .75f;
        pos.anchoredPosition = new Vector2(xPos, yPos);
        pos.sizeDelta = new Vector2(windowWidth / 2.3f, windowTransform.rect.height / 2.3f);
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
