using System.Collections.Generic;
using UnityEngine;

public class Survivor : Action
{
    public string survivorName;
    public AnimatorOverrideController overrideController;
    Animator animator;

    public override void InitAction(string action)
    {
        //not all actions load new levels
        base.InitAction(action);
        GameManager.Instance.LoadActionScene(action);
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        var animator = GetComponent<Animator>();
        var overrideController = new AnimatorOverrideController(animator.runtimeAnimatorController);
        animator.runtimeAnimatorController = overrideController;

        Object[] loadedClips = Resources.LoadAll("Animations/" + survivorName);
        AnimationClip[] originalClips = overrideController.animationClips;

        var overrides = new List<KeyValuePair<AnimationClip, AnimationClip>>();

        foreach (AnimationClip original in originalClips)
        {
            AnimationClip replacement = null;

            // Get suffix like "Idle", "Move", etc
            // Assumes format like "Remy_Idle" or "James_Move"
            int underscoreIndex = original.name.IndexOf('_');
            string suffix = underscoreIndex >= 0 ? original.name.Substring(underscoreIndex) : original.name;

            foreach (Object asset in loadedClips)
            {
                if (asset is AnimationClip clip && clip.name.EndsWith(suffix))
                {
                    replacement = clip;
                    break;
                }
            }

            if (replacement != null)
            {
                overrides.Add(new KeyValuePair<AnimationClip, AnimationClip>(original, replacement));
                Debug.Log($"Replacing '{original.name}' with '{replacement.name}'");
            }
            else
            {
                overrides.Add(new KeyValuePair<AnimationClip, AnimationClip>(original, original));
                Debug.LogWarning($"No replacement found for '{original.name}'");
            }
        }

        overrideController.ApplyOverrides(overrides);

    }

    public void PlayAnimation(string animation)
    {
        animator.Play(animation);
    }
}
