using UnityEngine;

namespace GravitySurge.Command
{
    /*
    **  Singleton Command/Input Handler.
    */
    public class CommandHandler : MonoBehaviour
    {
        /*
        **  Available Command Slots.
        */
        private static CommandInterface CommandLMouse;
        private static CommandInterface CommandRMouse;

        private static CommandType Valid = CommandType.Unassigned;
        private static float       Value = 0f;

        [Header("Input")]
        public bool Active = true;
        
        /*
        **  Registers A Command To An Input Slot.
        */
        public static void Register(CommandType type, CommandInterface command)
        {
            switch (type)
            {
                case CommandType.LMouse:
                {
                    CommandLMouse = command;

                    break;
                }

                case CommandType.RMouse:
                {
                    CommandRMouse = command;

                    break;
                }
            }
        }

        private void Update()
        {
            /*
            **  Handles Input Events And Commands.
            */
            if (Active == true && CommandLMouse != null)
            {
                if (Input.GetMouseButton((int) CommandType.LMouse) == true)
                {
                    if (Valid == CommandType.Unassigned)
                    {
                        Value = 0f;
                    }

                    Value += Time.deltaTime;
                    Valid  = CommandType.LMouse;

                    return;
                }
                else
                {
                    if (Valid == CommandType.LMouse)
                    {
                        Valid = CommandType.Unassigned;

                        CommandLMouse.Execute(Value);
                        
                        return;
                    }
                }
            }
            
            if (Active == true && CommandRMouse != null)
            {
                if (Input.GetMouseButton((int) CommandType.RMouse) == true)
                {
                    if (Valid == CommandType.Unassigned)
                    {
                        Value = 0f;
                    }

                    Value += Time.deltaTime;
                    Valid  = CommandType.RMouse;

                    return;
                }
                else
                {
                    if (Valid == CommandType.RMouse)
                    {
                        Valid = CommandType.Unassigned;

                        CommandRMouse.Execute(Value);
                        
                        return;
                    }
                }
            }
        }
    }
}