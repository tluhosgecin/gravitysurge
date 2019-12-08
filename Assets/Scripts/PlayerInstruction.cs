namespace GravitySurge.Player
{
    /*
    **  Player Instructions For Triggering State Changes.
    */
    public enum PlayerInstruction
    {
        Literal = 0x00,
        Barrier = 0x01,
        Trigger = 0x02,
        Gravity = 0x03,
    }
}