using UnityEngine;

public class FuseUIController : MonoBehaviour
{
    [Header("UI à afficher")]
    [SerializeField] private GameObject fuseUIPanel;

    [Header("Animation de réparation")]
    [SerializeField] private Animator fuseAnimator;
    [SerializeField] private string repairTriggerName = "repair";

    [Header("Fermeture automatique")]
    [SerializeField] private bool autoHide = false;
    [SerializeField] private float hideDelay = 2f;

    /// <summary>
    /// Active l'UI du fusible et lance éventuellement l'animation "repair"
    /// </summary>
    public void ActivateFuseUI(bool playRepairAnimation = true)
    {
        if (fuseUIPanel != null)
            fuseUIPanel.SetActive(true);

        if (playRepairAnimation && fuseAnimator != null && !string.IsNullOrEmpty(repairTriggerName))
            fuseAnimator.SetTrigger(repairTriggerName);

        if (autoHide)
            Invoke(nameof(HideFuseUI), hideDelay);
    }

    /// <summary>
    /// Masque l'UI
    /// </summary>
    public void HideFuseUI()
    {
        if (fuseUIPanel != null)
            fuseUIPanel.SetActive(false);
    }
}
