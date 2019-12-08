using System;

namespace GravitySurge.Player
{
    /*
    **  Singleton Bytecode Virtual Machine For Player Specific Actions.
    */
    public class PlayerLogic
    {
        public delegate void  Action(int value);
        public static   event Action OnBarrier;
        public static   event Action OnTrigger;
        public static   event Action OnGravity;

        private static int   LIMIT = 64;
        private static int[] Stack = new int[LIMIT];
        private static int   Count = 0;
        
        /*
        **  Pushes Bytecode Into The Stack.
        */
        private static int Push(int value)
        {
            if (Count >= LIMIT)
            {
                throw new Exception("Push Failed.");
            }

            return Stack[Count++] = value;
        }

        /*
        **  Pulls Bytecode From The Stack.
        */
        private static int Pull()
        {
            if (Count <= 0)
            {
                throw new Exception("Pull Failed.");
            }

            return Stack[--Count];
        }
        
        /*
        **  Resets Instruction Count.
        */
        public static void Reset()
        {
            Count = 0;
        }

        /*
        **  Assign A Bytecode To Be Interpreted.
        */
        public static void Interpret(int[] bytecode)
        {
            for (int index = 0; index < bytecode.Length; index++)
            {
                switch (bytecode[index])
                {
                    case (int) PlayerInstruction.Literal:
                    {
                        Push(bytecode[++index]);

                        break;
                    }

                    case (int) PlayerInstruction.Barrier:
                    {
                        int value = Pull();

                        if (OnBarrier != null)
                        {
                            OnBarrier(value);
                        }
                        
                        break;
                    }

                    case (int) PlayerInstruction.Trigger:
                    {
                        int value = Pull();

                        if (OnTrigger != null)
                        {
                            OnTrigger(value);
                        }

                        break;
                    }

                    case (int) PlayerInstruction.Gravity:
                    {
                        int value = Pull();

                        if (OnGravity != null)
                        {
                            OnGravity(value);
                        }

                        break;
                    }
                }
            }

            /*
            **  Resets Instruction Count After Execution.
            */
            Reset();
        }
    }
}