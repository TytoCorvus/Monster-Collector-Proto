using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class MessageBoxScript : MonoBehaviour, IPointerDownHandler
{
    public Image outerPanel;
    public Image innerPanel;
    public Text textComponent;
    public double messageDelay;
    private bool visible;
    private bool moveForwardByInput = false;
    private Queue<Pair<string, bool>> messageQueue = new Queue<Pair<string, bool>>();
    private Action queueEmptyCallback;

    public void OnPointerDown(PointerEventData data)
    {
        if (messageQueue.Peek().getSecond())
        {
            moveForwardByInput = true;
        }
    }

    public void setVisible(bool newVal)
    {
        if(!newVal == visible)
        {
            visible = newVal;
            outerPanel.enabled = newVal;
            innerPanel.enabled = newVal;
            textComponent.enabled = newVal;
        }
    }

    public void setCallback(Action callback)
    {
        this.queueEmptyCallback = callback;
    }

    public void enqueueText(string[] strArr, bool requireInput)
    {
        bool queueWasEmpty = messageQueue.Count == 0;
        foreach (string str in strArr)
            messageQueue.Enqueue(new Pair<string, bool>(str, requireInput));
        if (queueWasEmpty)
            StartCoroutine(displayCoroutine());
    }

    public void enqueueText(string str, bool requireInput)
    {
        bool queueWasEmpty = messageQueue.Count == 0;
        messageQueue.Enqueue(new Pair<string, bool>(str, requireInput));
        if (queueWasEmpty)
            StartCoroutine(displayCoroutine());
    }

    public IEnumerator waitUntilQueueEmpty()
    {
        while(messageQueue.Count == 0)
            yield return new WaitForSeconds(0.05f);
    }

    private IEnumerator displayCoroutine()
    {
        while(messageQueue.Count > 0)
        {
            Pair<string, bool> messageArgs = messageQueue.Peek();
            textComponent.text = messageArgs.getFirst();

            if (messageArgs.getSecond())
            {
                while (!moveForwardByInput)
                    yield return new WaitForSeconds(0.05f);
                moveForwardByInput = false;
            }
            else
                yield return new WaitForSeconds((float)messageDelay);
            
            messageQueue.Dequeue();
        }

        clear();
        setVisible(false);
        if(queueEmptyCallback != null)
        {
            queueEmptyCallback();
            queueEmptyCallback = null;
        }
    }

    private void setText(string str)
    {
        textComponent.text = str;
    }

    public void clear()
    {
        textComponent.text = "";
    }
}
