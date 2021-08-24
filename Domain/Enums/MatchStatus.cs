namespace Domain.Enums
{
    public enum MatchStatus
    {
        TBD, // Time To Be Defined
        NS, // Not Started
        H1, // First Half, Kick Off
        HT, // Halftime
        H2, // Second Half, 2nd Half Started
        ET, // Extra Time
        P, // Penalty In Progress
        FT, // Match Finished
        AET, // Match Finished After Extra Time
        PEN, // Match Finished After Penalty
        BT, // Break Time (in Extra Time)
        SUSP, // Match Suspended
        INT, // Match Interrupted
        PST, // Match Postponed
        CANC, // Match Cancelled
        ABD, // Match Abandoned
        AWD, // Technical Loss
        WO // WalkOver
    }
}
