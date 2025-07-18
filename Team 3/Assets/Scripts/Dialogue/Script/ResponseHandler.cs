using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Collections.Generic;

public class ResponseHandler : MonoBehaviour
{
    [SerializeField] private RectTransform responseBox;
    [SerializeField] private RectTransform responseButtonTemplate;
    [SerializeField] private RectTransform responseContainer;

    private DialogueUI dialogueUI;

    private List<GameObject> tempResponseButton = new List<GameObject>();

    private void Start()
    {
        dialogueUI = GetComponent<DialogueUI>();
    }

    public void ShowResponses(Response[] responses)
    {
        float responseBoxHeight = 0;

        foreach (Response response in responses)
        {
            GameObject responseButton = Instantiate(responseButtonTemplate.gameObject, responseContainer);
            responseButton.gameObject.SetActive(true);
            responseButton.GetComponent<TMP_Text>().text = response.ResponseText;
            Debug.Log("create");
            responseButton.GetComponent<Button>().onClick.AddListener(() => OnPickedResponse(response));

            tempResponseButton.Add(responseButton);

            responseBoxHeight += responseButtonTemplate.sizeDelta.y;

        }

        responseBox.sizeDelta = new Vector2(responseBox.sizeDelta.x, responseBoxHeight);
        responseBox.gameObject.SetActive(true);
        
    }

    private void OnPickedResponse(Response response)
    {
        responseBox.gameObject.SetActive(false);

        foreach (GameObject button in tempResponseButton)
        {
            Destroy(button);
        }

        tempResponseButton.Clear();

        dialogueUI.ShowDialogue(response.DialogueObject);
        Debug.Log("press");
    }

}
