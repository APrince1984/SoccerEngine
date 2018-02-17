namespace SoccerDataGenerator.Data
{
    public struct PlayerPercentages
    {
        public const double GreatPlayers = 5.0;
        public const double GoodPlayers = 10.0;
        public const double MediocrePlayers = 30.0;
        public const double BadPlayers = 30.0;
        public const double VeryBadPlayers = 25.0;
    }

    public struct Rating
    {
        //public const int NoRating = 0;
        public const int VeryBad = 1;
        public const int Bad = 2;
        public const int Mediocre = 3;
        public const int Good = 4;
        public const int VeryGood = 5;
    }

    public struct Position
    {
        public const int Goaly = 1;
        public const int Defence = 2;
        public const int Midfield = 3;
        public const int Forward = 4;
    }

    public struct Maximums
    {
        public const int MaximumGoalies = 3;
        public const int MaximumDefenders = 7;
        public const int MaximumMidfield = 7;
        public const int MaximumForwards = 4;
    }

    public struct AttributeName
    {
        public struct GoalyAttributes
        {
            public const string Reflexes = "Reflexes"; // 13
            public const string Ballhandling = "Ballhandling"; // 14
            public const string PenaltyStopping = "Penalty Stopping"; // 15
        }

        public struct DefensiveAttributes
        {
            public const string Anticipation = "Anticipation"; // 1
            public const string Tackling = "Tackling"; // 2
            public const string Marking = "Marking"; // 3
        }

        public struct MidfieldAttribues 
        {
            public const string Passing = "Passing"; // 4
            public const string FirstTouch = "First Touch"; // 5
            public const string Teamwork = "Teamwork"; // 6
        }

        public struct ForwardAttributes
        {
            public const string Finishing = "Finishing"; // 9
            public const string Composure = "Composure"; // 10
            public const string Positioning = "Positioning"; // 11
        }

        public struct FysicalAttributes
        {
            public const string Acceleration = "Acceleration"; // 16
            public const string Stamina = "Stamina"; // 17
            public const string Speed = "Speed"; // 18
            public const string Heading = "Heading"; // 19
            public const string Condition = "Condition"; // 2
            public const string InjuryProneness = "Injury proneness"; // 20
        }

        public struct MentalAttributes
        {
            public const string LeaderShip = "Leadership"; // 21
            public const string Moral = "Moral"; // 1
            public const string Guts = "Guts"; //26
        }

        public struct SetPiecesAttributes
        {
            public const string Corners = "Corners"; // 22 
            public const string PenaltyKicks = "Penalty kicks"; // 23
            public const string FreeKicks = "Free kicks"; // 24
            public const string ThrowIns = "Throw Ins"; // 25
        }

        public struct AttackingAttributes
        {
            public const string Dribbling = "Dribbling"; // 7
            public const string Crossing = "Crossing"; // 8
            public const string Techniek = "Techniek"; // 12
        }
    }

    public struct PlayerPosition
    {
        public const int Goaly = 1;

        public struct DefensivePositions
        {
            public const int RightBack = 1;
            public const int CenterBack = 3;
            public const int LeftBack = 5;
            public const int DefensiveMidfield = 6;
        }
        public struct MidfieldPositions
        {
            public const int RightMidfield = 7;
            public const int DefensiveMidfield = 6;
            public const int CenterMidfield = 8;
            public const int AttackingMidfield = 10;
            public const int LeftMidfield = 11;
        }
        public struct ForwardPositions
        {
            public const int AttackingMidfield = 10;
            public const int Forward = 9;
        }
    }
}
