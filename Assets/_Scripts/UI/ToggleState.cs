using UnityEngine;
using UnityEngine.UI;

public class ToggleState : MonoBehaviour
{
    private AudioManager audioManager;
    public Toggle toggle;

    private void Start()
    {
        // Tìm AudioManager trong Scene nếu nó không được gán trong Inspector
        if (audioManager == null)
        {
            audioManager = FindObjectOfType<AudioManager>();
        }

        // Thêm listener cho toggle
        if (toggle != null)
        {
            toggle.onValueChanged.AddListener(ToggleMusic);

            // Thiết lập trạng thái ban đầu
            ToggleMusic(toggle.isOn);
        }
    }

    public void ToggleMusic(bool isOn)
    {
        if (isOn)
        {
            audioManager.PauseMusic(); // Pause music if toggle is off
        }
        else
        {
            audioManager.PlayMusic(); // Play music if toggle is on
        }
    }
}
