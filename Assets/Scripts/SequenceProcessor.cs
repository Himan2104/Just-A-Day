using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SequenceProcessor : MonoBehaviour
{
    [SerializeField] private SpriteRenderer MainSprite;
    [SerializeField] private Sequence CurrentSequence;

    NarrativeManager narrativeManager;
    AudioSource audioSource;
    Coroutine sequence;

    void Start()
    {
        narrativeManager = FindObjectOfType<NarrativeManager>();
        audioSource = GetComponent<AudioSource>();
        sequence = StartCoroutine(ProcessSequence());
    }

    private IEnumerator ProcessSequence()
    {
        foreach (var step in CurrentSequence.steps)
        {
            narrativeManager.HideTextInterface();
            yield return new WaitForSeconds(0.25f);
            narrativeManager.SetText(step.text);
            if (step.changeSprite)
            {
                while (MainSprite.color.a > 0f)
                {
                    MainSprite.color = new Color(MainSprite.color.r, MainSprite.color.g, MainSprite.color.b, MainSprite.color.a - 0.01f);
                    audioSource.volume -= 0.01f;
                    yield return new WaitForSeconds(0.01f);
                }
                MainSprite.sprite = step.newSprite;
                if (step.changeSound) audioSource.clip = step.newSound;
                if (audioSource.clip) audioSource.Play();
                while (MainSprite.color.a < 1f)
                {
                    MainSprite.color = new Color(MainSprite.color.r, MainSprite.color.g, MainSprite.color.b, MainSprite.color.a + 0.01f);
                    audioSource.volume += 0.01f;
                    yield return new WaitForSeconds(0.01f);
                }
            }
            narrativeManager.ShowTextInterface();
            yield return new WaitForSeconds(step.time);
        }

        if (CurrentSequence.isEnd)
        {
            audioSource.enabled = false;
            StartCoroutine(EndGame());
        }
        else
        {
            narrativeManager.HideTextInterface();
            yield return new WaitForSeconds(0.25f);
            narrativeManager.SetText(CurrentSequence.finalText);
            narrativeManager.SetOptions
                (
                new OptionData
                {
                    OptionAText = CurrentSequence.optionAText,
                    OptionBText = CurrentSequence.optionBText,
                    OptionAAction = delegate { Debug.Log("You chose A"); narrativeManager.SetButtonState(false); CurrentSequence = CurrentSequence.optionASequence; StartCoroutine(EndSequence()); },
                    OptionBAction = delegate { Debug.Log("You chose B"); narrativeManager.SetButtonState(false); CurrentSequence = CurrentSequence.optionBSequence; StartCoroutine(EndSequence()); }
                }
                );
            narrativeManager.ShowTextInterface();
            narrativeManager.ShowOptionsInterface();
            narrativeManager.SetButtonState(true);
        }
    }

    private IEnumerator EndSequence()
    {   
        yield return new WaitForSeconds(1f);
        narrativeManager.HideFullInterface();
        while (MainSprite.color.a < 1f)
        {
            MainSprite.color = new Color(MainSprite.color.r, MainSprite.color.g, MainSprite.color.b, MainSprite.color.a + 0.01f);
            yield return new WaitForSeconds(0.01f);
        }

        yield return new WaitForSeconds(1f);
        StopCoroutine(sequence);
        sequence = StartCoroutine(ProcessSequence());
        
    }

    private IEnumerator EndGame()
    {
        yield return new WaitForSeconds(1f);
        narrativeManager.HideFullInterface();
        while (MainSprite.color.a > 0f)
        {
            MainSprite.color = new Color(MainSprite.color.r, MainSprite.color.g, MainSprite.color.b, MainSprite.color.a - 0.01f);
            yield return new WaitForSeconds(0.01f);
        }

        yield return new WaitForSeconds(1f);
        UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenu");
    }
}
