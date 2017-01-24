using UnityEngine;
using System.Collections;
using XInputDotNetPure; // Required in C#
using System;

namespace GameInput
{

    public enum PlayerID
    {
        One,
        Two,
        Three,
        Four
    }


    public enum GamePadButttons
    {
        A,
        B,
        X,
        Y,
        Start,
        Back,
        DPadUP,
        DPadDOWN,
        DPadLEFT,
        DPadRIGHT,
        TriggerLeft,
        TriggerRight,
        ShoulderLeft,
        ShoulderRight
    }

    public enum GamePadAxis
    {
        StickLeft,
        StickRight
    }

    public enum InputState
    {
        NONE,
        Pressed,
        Released,
        Hold
    }

    public class XInput : MonoBehaviour
    {
        public int maxPlayer =1;

        public float triggerPressedLimit = 0.9f;

        public static XInput instance = null;
        bool playerIndexSet = false;
        PlayerIndex playerIndex;
        GamePadState state;
        GamePadState prevState;
        InputState[,] buttonStateArray;
        int[] vibePlayer;
        void Awake()
        {
            instance = this;


            buttonStateArray = new InputState[maxPlayer, GamePadButttons.GetNames(typeof(GamePadButttons)).Length];
            for (int id = 0; id < maxPlayer; id++)
            {
                for (int i = 0; i < buttonStateArray.Length; i++)
                {
                    buttonStateArray[id,i] = InputState.NONE;
                }
            }

            vibePlayer = new int[4];
            vibePlayer[0] = 0;
            vibePlayer[1] = 0;
            vibePlayer[2] = 0;
            vibePlayer[3] = 0;
        }

        void Update()
        {
            // Find a PlayerIndex, for a single player game
            // Will find the first controller that is connected ans use it
            if (!playerIndexSet || !prevState.IsConnected)
            {
                for (int id = 0; id < maxPlayer; id++)
                {
                    PlayerIndex testPlayerIndex = (PlayerIndex)id;
                    GamePadState testState = GamePad.GetState(testPlayerIndex);
                    if (testState.IsConnected)
                    {
                        playerIndex = testPlayerIndex;
                        playerIndexSet = true;

                        
                    }
                }
            }
            prevState = state;
            state = GamePad.GetState(playerIndex);

            for (int id = 0; id < maxPlayer; id++)
            {
                CheckInputs(id);
            }
            
            // Set vibration according to triggers
            //GamePad.SetVibration(playerIndex, vibe.x, vibe.y);

            // Make the current object turn
            //transform.localRotation *= Quaternion.Euler(0.0f, state.ThumbSticks.Left.X * 25.0f * Time.deltaTime, 0.0f);
        }


        #region ButtonChecker and Converts
        /// <summary>
        /// Updates the Input bools. This is hardcoded to fix sucky Xinput. HACKY HACKY
        /// </summary>
        /// <param name="id"></param>
        private void CheckInputs(int id)
        {
            buttonStateArray[id, (int)GamePadButttons.A] = ConvertButtonState(GamePad.GetState((PlayerIndex)id).Buttons.A, buttonStateArray[id, (int)GamePadButttons.A]);
            buttonStateArray[id, (int)GamePadButttons.B] = ConvertButtonState(GamePad.GetState((PlayerIndex)id).Buttons.B, buttonStateArray[id, (int)GamePadButttons.B]);
            buttonStateArray[id, (int)GamePadButttons.X] = ConvertButtonState(GamePad.GetState((PlayerIndex)id).Buttons.X, buttonStateArray[id, (int)GamePadButttons.X]);
            buttonStateArray[id, (int)GamePadButttons.Y] = ConvertButtonState(GamePad.GetState((PlayerIndex)id).Buttons.Y, buttonStateArray[id, (int)GamePadButttons.Y]);
            buttonStateArray[id, (int)GamePadButttons.Start] = ConvertButtonState(GamePad.GetState((PlayerIndex)id).Buttons.Start, buttonStateArray[id, (int)GamePadButttons.Start]);
            buttonStateArray[id, (int)GamePadButttons.Back] = ConvertButtonState(GamePad.GetState((PlayerIndex)id).Buttons.Back, buttonStateArray[id, (int)GamePadButttons.Back]);
            buttonStateArray[id, (int)GamePadButttons.ShoulderLeft] = ConvertButtonState(GamePad.GetState((PlayerIndex)id).Buttons.LeftShoulder, buttonStateArray[id, (int)GamePadButttons.ShoulderLeft]);
            buttonStateArray[id, (int)GamePadButttons.ShoulderRight] = ConvertButtonState(GamePad.GetState((PlayerIndex)id).Buttons.RightShoulder, buttonStateArray[id, (int)GamePadButttons.ShoulderRight]);
            buttonStateArray[id, (int)GamePadButttons.DPadUP] = ConvertButtonState(GamePad.GetState((PlayerIndex)id).DPad.Up, buttonStateArray[id, (int)GamePadButttons.DPadUP]);
            buttonStateArray[id, (int)GamePadButttons.DPadDOWN] = ConvertButtonState(GamePad.GetState((PlayerIndex)id).DPad.Down, buttonStateArray[id, (int)GamePadButttons.DPadDOWN]);
            buttonStateArray[id, (int)GamePadButttons.DPadLEFT] = ConvertButtonState(GamePad.GetState((PlayerIndex)id).DPad.Left, buttonStateArray[id, (int)GamePadButttons.DPadLEFT]);
            buttonStateArray[id, (int)GamePadButttons.DPadRIGHT] = ConvertButtonState(GamePad.GetState((PlayerIndex)id).DPad.Right, buttonStateArray[id, (int)GamePadButttons.DPadRIGHT]);

            buttonStateArray[id, (int)GamePadButttons.TriggerLeft] = ConvertTriggerState(GamePad.GetState((PlayerIndex)id).Triggers.Left, buttonStateArray[id, (int)GamePadButttons.TriggerLeft]);
            buttonStateArray[id, (int)GamePadButttons.TriggerRight] = ConvertTriggerState(GamePad.GetState((PlayerIndex)id).Triggers.Right, buttonStateArray[id, (int)GamePadButttons.TriggerRight]);


        }
        /// <summary>
        /// Converts Xinput Button states to our own states
        /// </summary>
        /// <param name="xinputbuttonstate"></param>
        /// <param name="currentstate"></param>
        /// <returns></returns>
        private InputState ConvertButtonState(ButtonState xinputbuttonstate, InputState currentstate)
        {
            if (xinputbuttonstate == ButtonState.Pressed)
            {

                if (currentstate == InputState.Pressed || currentstate == InputState.Hold)
                    return InputState.Hold;
                if (currentstate == InputState.NONE)
                    return InputState.Pressed;
                
            }
            else if (xinputbuttonstate == ButtonState.Released)
            {
                if (currentstate == InputState.Released || currentstate == InputState.NONE)
                    return InputState.NONE;
                if (currentstate == InputState.Hold || currentstate == InputState.Pressed)
                    return InputState.Released;
            }

            Debug.LogWarning("Can't convert this button state");
            return InputState.NONE;

        }

        /// <summary>
        /// Converts Xinput Trigger values to our own states
        /// </summary>
        /// <param name="xinputtriggervalue"></param>
        /// <param name="currentstate"></param>
        /// <returns></returns>
        private InputState ConvertTriggerState(float xinputtriggervalue, InputState currentstate)
        {
            if (xinputtriggervalue >= triggerPressedLimit)
            {

                if (currentstate == InputState.Pressed || currentstate == InputState.Hold)
                    return InputState.Hold;
                if (currentstate == InputState.NONE)
                    return InputState.Pressed;

            }
            else if (xinputtriggervalue < triggerPressedLimit)
            {
                if (currentstate == InputState.Released || currentstate == InputState.NONE)
                    return InputState.NONE;
                if (currentstate == InputState.Hold || currentstate == InputState.Pressed)
                    return InputState.Released;
            }

            Debug.LogWarning("Can't convert this button state");
            return InputState.NONE;
        }

        #endregion

        /// <summary>
        /// Gets the current state of a button of the GamePad. For sticks use GetStickVector().
        /// </summary>
        /// <param name="id"></param>
        /// <param name="PadInput"></param>
        /// <returns> </returns>
        public InputState GetButtonState(PlayerIndex id, GamePadButttons PadInput)
        {
            return buttonStateArray[(int)id, (int)PadInput];
        }

        /// <summary>
        /// Gets the Vector2 of sticks, For Buttons use GetButtonState().
        /// </summary>
        /// <param name="id"></param>
        /// <param name="PadInput"></param>
        /// <returns></returns>
        public Vector2 GetStickVector(PlayerID id, GamePadAxis PadInput)
        {
            Vector2 stickvector = new Vector2();

            if (PadInput == GamePadAxis.StickLeft)
            {
                stickvector.x = GamePad.GetState((PlayerIndex)id).ThumbSticks.Left.X;
                stickvector.y = GamePad.GetState((PlayerIndex)id).ThumbSticks.Left.Y;
            }
            else if (PadInput == GamePadAxis.StickRight)
            {
                stickvector.x = GamePad.GetState((PlayerIndex)id).ThumbSticks.Right.X;
                stickvector.y = GamePad.GetState((PlayerIndex)id).ThumbSticks.Right.Y;
            }
            /*else
            {
                Debug.LogError("You can't get the buttons vector, use GetButton instead");
                return new Vector2();
            }*/
            return stickvector;
        }

        #region OldSchool Trigger Values

        public float getTriggerRight(PlayerIndex id)
        {
            return GamePad.GetState(id).Triggers.Right;
        }

        public float getTriggerLeft(PlayerIndex id)
        {
            return GamePad.GetState(id).Triggers.Left;
        }
        #endregion

        /// <summary>
        /// Trigger a vibration on the GamePad
        /// </summary>
        /// <param name="id"></param>
        /// <param name="time"></param>
        /// <param name="force1"></param>
        /// <param name="force2"></param>
        public void useVibe(PlayerIndex id, float time, float force1, float force2)
        {
            vibePlayer[(int)id]++;
            StartCoroutine(vibration((PlayerIndex)(id), time, force1, force2));
        }

        IEnumerator vibration(PlayerIndex id, float time, float force1, float force2)
        {
            GamePad.SetVibration(id, force1, force2);
            yield return new WaitForSeconds(time);
            vibePlayer[(int)id]--;
            if (vibePlayer[(int)id] == 0)
                GamePad.SetVibration(id, 0, 0);
        }

        void OnDestroy()
        {
            for (int id = 0; id < maxPlayer; id++)
            {
                GamePad.SetVibration((PlayerIndex)id, 0, 0);
            }
        }
    }

}
