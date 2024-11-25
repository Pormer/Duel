using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerKey : MonoBehaviour
{
    // LPlayer
    [SerializeField] private TextMeshProUGUI lPlayerMoveUpTxt;
    [SerializeField] private TextMeshProUGUI lPlayerMoveDownTxt;
    [SerializeField] private TextMeshProUGUI lPlayerMoveLeftTxt;
    [SerializeField] private TextMeshProUGUI lPlayerMoveRightTxt;
    // Fight
    [SerializeField] private TextMeshProUGUI lPlayerShootTxt;
    [SerializeField] private TextMeshProUGUI lPlayerBarrierTxt;
    [SerializeField] private TextMeshProUGUI lPlayerSkillTxt;

    // RPlayer
    [SerializeField] private TextMeshProUGUI rPlayerMoveUpTxt;
    [SerializeField] private TextMeshProUGUI rPlayerMoveDownTxt;
    [SerializeField] private TextMeshProUGUI rPlayerMoveLeftTxt;
    [SerializeField] private TextMeshProUGUI rPlayerMoveRightTxt;
    // Fight
    [SerializeField] private TextMeshProUGUI rPlayerShootTxt;
    [SerializeField] private TextMeshProUGUI rPlayerBarrierTxt;
    [SerializeField] private TextMeshProUGUI rPlayerSkillTxt;


    public enum PlayerKeyAction
    {
        #region LPlayer
        // LPlayer Move
        LMoveUp,
        LMoveDown,
        LMoveLeft,
        LMoveRight,
        // LPlayer Fight
        LShoot,
        LBarrier,
        LSkill,
        #endregion

        #region RPlayer
        // RPlayer Move
        RMoveUp,
        RMoveDown,
        RMoveLeft,
        RMoveRight,
        // RPlayer Fight
        RShoot,
        RBarrier,
        RSkill,
        #endregion
        KeyCount
    }

    public static class KeySetting
    {
        public static Dictionary<PlayerKeyAction, KeyCode> keys = new Dictionary<PlayerKeyAction, KeyCode>();
    }

    public class KeyBinding
    {
        KeyCode[] defaultKC = new KeyCode[]
        {

            // LPlayer
            KeyCode.W,
            KeyCode.A,
            KeyCode.S,
            KeyCode.D,

            KeyCode.X,
            KeyCode.C,
            KeyCode.V,
            // RPlayer
            KeyCode.UpArrow,
            KeyCode.DownArrow,
            KeyCode.LeftArrow,
            KeyCode.RightArrow,

            KeyCode.B,
            KeyCode.N,
            KeyCode.M
        };

        int key = -1;

        private void Awake()
        {
            KeySetting.keys.Clear();
            for(int i = 0; i <(int)PlayerKeyAction.KeyCount; i++)
            {
                KeySetting.keys.Add((PlayerKeyAction)i, defaultKC[i]);
            }
        }

        private void Update()
        {

        }

        private void OnGUI()
        {
            Event keyEvent = Event.current;
            if (keyEvent.isKey)
            {
                KeySetting.keys[(PlayerKeyAction)key] = keyEvent.keyCode;
                key--;
            }
        }

        public void KeyChange(int value)
        {
            key = value;
        }

        private void Input()
        {

        }
    }
}
