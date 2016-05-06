using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class ConversationManager : MonoBehaviour
{
    // Singleton
    public static ConversationManager Instance { get; set; }

    bool isTalking = false;
    ConversationEntry currentConversationLine;

    void Awake()
    {
        if (Instance != null && Instance != this)
            Destroy(gameObject);

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
    
    public void StartConversation(Conversation conversation)
    {
        if (!isTalking)
            StartCoroutine(DisplayConversation(conversation));
    }

    IEnumerator DisplayConversation(Conversation conversation)
    {
        isTalking = true;

        foreach(ConversationEntry line in conversation.ConversationLines)
        {
            currentConversationLine = line;
            Debug.Log(currentConversationLine.SpeakingCharacterName + ": " + currentConversationLine.ConversationText + " " + currentConversationLine.DisplayPicture);

            yield return new WaitForSeconds(3);
        }

        isTalking = false;
    }
}
