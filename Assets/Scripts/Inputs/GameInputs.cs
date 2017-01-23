using UnityEngine;
using XInputDotNetPure;
using Events;


namespace GameInput
{
    /// <summary>
    /// These are all the Actions possible in the game, these are Hardcoded.
    /// </summary>
    public enum InputActionList
    {
        // UI State Helpers
        Interact = 1,
        Back = 2,

        //Exploration Actions
        Crawl = 7,

        // Combat Actions
        UseCharacter01 = 11,
        UseCharacter02 = 12,
        UseCharacter03 = 13,
        UseCharacter04 = 14,
        AttackModifier = 15,
        AbilityModifier = 16,



        // General Actions
        Pause = 100
    }

    /// <summary>
    /// All the possible Inputcontexts
    /// </summary>
    public enum InputContextList
    {
        Exploration = 0,
        Combat = 1,
        Dialogue = 4,
        Menu = 10
    }
       
    public class GameInputs : MonoBehaviour
    {
        public static GameInputs instance;

        void Awake()
        {
            if (instance == null)
            {
                //DontDestroyOnLoad(this.gameObject);
                instance = this;
            }
            else if (instance != this)
            {
                Destroy(this.gameObject);
            }

            _inputContexts = this.GetComponent<InputContext>();
            _XInput = this.GetComponent<XInput>();

            currentContext = GetContext(_currentContext);
        }

        private InputContext _inputContexts;
        private InputContext.IInputContext currentContext;
        private XInput _XInput;

        public InputContextList _currentContext = InputContextList.Exploration;
        public PlayerIndex playerIndex = PlayerIndex.One;

        void Update()
        {
            currentContext = GetContext(_currentContext);
            CheckContextInputs(currentContext);
        }

        /// <summary>
        /// Check all the inputs for each action in current Input Context
        /// </summary>
        /// <param name="context"></param>
        private void CheckContextInputs(InputContext.IInputContext context)
        {
            for (int i = 0; i < context.InputMap.Count; i++)
            {
                InputActionList currentaction = context.InputMap[i].IAction;
                InputState currentstate = _XInput.GetButtonState(playerIndex, GetMapping(currentaction));

                if (currentstate != InputState.NONE)
                {
                    EventCenter.FireEvent<InputEvents.IActionHandler>((handler) => handler.OnAction(currentaction, currentstate));
                }
            }
        }

        /// <summary>
        /// Gets you the desired context
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public InputContext.IInputContext GetContext(InputContextList context)
        {
            return _inputContexts.ContextList.Find(searchedcontext => searchedcontext.IContext == context);
        }

        /// <summary>
        /// Gets you the Input used for the action
        /// </summary>
        public GamePadButttons GetMapping(InputActionList action)
        {
            return currentContext.InputMap.Find(searchedInputMap => searchedInputMap.IAction == action).Inputs;
        }
    }
}

