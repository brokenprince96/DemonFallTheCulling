using UnityEngine;

public class Downtown : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        DialogueController.Instance.SetDialgoue("Downtown LA's not looking too good...");
        Player.Instance.PlayAnimation("Idle");

    }

}
