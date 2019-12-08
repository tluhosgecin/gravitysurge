using GravitySurge.Player;

namespace GravitySurge.Command
{
    /*
    **  Trigger Command For Player Movement.
    */
    public class CommandTrigger : CommandInterface
    {
        private float Scaler;
        private int   Course;

        public CommandTrigger(float scaler = 10f, int course = 1)
        {
            Scaler = scaler;
            Course = course;
        }

        public override void Execute(float value)
        {
            /*
            **  Sends Bytecode To Player Logic To Be Interpreted.
            */
            PlayerLogic.Interpret(new int[] {0x00, (int) (value * Scaler * Course), 0x02 });
        }
    }
}