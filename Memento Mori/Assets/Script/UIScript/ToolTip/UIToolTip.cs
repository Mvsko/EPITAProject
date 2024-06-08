using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEditor.Overlays;
using UnityEngine;
using UnityEngine.UI;

[ExecuteInEditMode()]
public class ToolTipScript : MonoBehaviour
{
    public TextMeshProUGUI headerField;
    public TextMeshProUGUI contentField;

    public LayoutElement layoutElement;

    public int characterWrapLimit;

    public RectTransform rectTransform;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    public void SetText(string content, string header = "")
    {
        if(string.IsNullOrEmpty(header))
        {
            headerField.gameObject.SetActive(false);
        }
        else
        {
            headerField.gameObject.SetActive(true);
            headerField.text = header;
        }
        contentField.text = content;

        int headerLenght = headerField.text.Length;
        int contentLenght = contentField.text.Length;

        layoutElement.enabled = (headerLenght > characterWrapLimit || contentLenght > characterWrapLimit) ? true : false;
    }
    private void Update()
    {
        int headerLenght = headerField.text.Length;
        int contentLenght = contentField.text.Length;

        layoutElement.enabled = (headerLenght > characterWrapLimit || contentLenght > characterWrapLimit) ? true : false;

        Vector2 position = new Vector2(Input.mousePosition.x+50,Input.mousePosition.y-50);
        //Vector2 position = Input.mousePosition;
        float privotX = position.x / Screen.width;
        float privotY = position.y / Screen.height;

        rectTransform.pivot = new Vector2(privotX,privotY);
        transform.position = position;
    }
}
