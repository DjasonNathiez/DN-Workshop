using System;
using System.Collections.Generic;
using UnityEngine;
using Object = System.Object;

public class QuestManager : MonoBehaviour
{
    public static QuestManager instance;
    
    public List<QuestInstance> questInstance;
    
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    public void AddToQuestCount(Object obj, int count)
    {
        foreach (QuestInstance quest in questInstance)
        {

            if (obj.GetType() == typeof(Item) 
                || obj.GetType() == typeof(ItemBag)
                || obj.GetType() == typeof(Item_Equipment)
                || obj.GetType() == typeof(ItemConsumable)
                || obj.GetType() == typeof(ItemObject))
            {
                
                if (quest.quest.GetType() == typeof(ItemQuest))
                {
                    ItemQuest itemQuest = (ItemQuest)quest.quest;
                    Item item = (Item)obj;

                    if (item == itemQuest.itemToCollect)
                    {
                        quest.currentQRequirementCount += count;
                        Debug.Log(quest.currentQRequirementCount);
                    }
                    
                }
            }
            
            if (quest.quest.GetType() == typeof(ExploreQuest))
            {
                Debug.Log("explore quest");
            }
            
            CheckQuestState(quest);
        }
    }
        
    public void CheckQuestState(QuestInstance quest)
    {
        if (quest.quest.count >= quest.currentQRequirementCount)
        {
            quest.isComplete = true;
        }
    }

    public void CheckAllQuestsState()
    {
        foreach (var quest in questInstance)
        {
            if (quest.quest.count >= quest.currentQRequirementCount)
            {
                quest.isComplete = true;
            }
        }
    }
}

[Serializable]public class QuestInstance
{
    public Quest quest;
    public int currentQRequirementCount;
    public bool isComplete;
}
