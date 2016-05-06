using UnityEngine;

// Author: Tiffany Fisher
public class MessagingClientReceiver : MonoBehaviour
{
    void Start()
    {
        // Subscribe to the event
        MessagingManager.Instance.Subscribe(ThePlayerIsTryingToLeave);
    }

    void ThePlayerIsTryingToLeave()
    {
        Debug.Log("Oi Don't Leave Me!! - " + tag.ToString());
        ConversationComponent dialogue = GetComponent<ConversationComponent>();

        if(dialogue != null)
        {
            if(dialogue.Conversations != null && dialogue.Conversations.Length > 0)
            {
                var conversation = dialogue.Conversations[0];
                if(conversation != null)
                {
                    ConversationManager.Instance.StartConversation(conversation);
                }
            }
        }
    }
}
