using System.Collections;
using UnityEngine;

public class Scavenge : Action
{
    public InventoryController inventoryController;
    float scavengeTime = 6.0f;
    int numOfSuppliesToFind = 1;

    public override void InitAction(string action)
    {
        base.InitAction(action);
        DialogueController.Instance.SetDialgoue("Lets see if we can find some supplies...");
        interuptTime = 7;
        StartCoroutine(SearchForSupplies(scavengeTime));
    }

    IEnumerator SearchForSupplies(float duration)
    {
        float elapsed = 0f;
        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;

            if(elapsed > scavengeTime - scavengeTime/4 && numOfSuppliesToFind > 0)
            {
                DialogueController.Instance.SetDialgoue("Supply Found!");
                Inventory.Instance.AddSupply();
                inventoryController.UpdateImages();
                numOfSuppliesToFind--;
            }

            if (interupt != 0 && elapsed > interuptTime)
            {
                HandleInterruption(interupt);
                yield break;
            }

            actionLength = 0;
            yield return null;
        }
        DialogueController.Instance.SetDialgoue("I wonder if there is anything else left to find...");
        EndAction();
    }

}
