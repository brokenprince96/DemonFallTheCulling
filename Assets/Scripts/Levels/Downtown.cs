using UnityEngine;

public class Downtown : MonoBehaviour
{
    //the quick brown fox jumpeed vvr   thee lazy  dg
    //Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        DialogueController.Instance.SetDialgoue("Downtown LA's not looking too good...");

        GameManager gm = GameManager.Instance;

        if (gm.GetRemainingDayActions() == 0)
            gm.NightFall();
    }

}
