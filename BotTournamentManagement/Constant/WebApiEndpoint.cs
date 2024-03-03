namespace BotTournamentManagement.Constant
{
    public static class WebApiEndpoint
    {
        public const string AreaName = "api";
        public static class Tournament
        {
            private const string BaseEndpoint = "~/" + AreaName + "/tournament";
            public const string GetAllTournament = BaseEndpoint + "/get-all";
            public const string GetSingleTournament = BaseEndpoint + "/get-by-id" + "/{id}";
            public const string CreateTournament = BaseEndpoint + "/create";
            public const string UpdateTournament = BaseEndpoint + "/update" + "/{id}";
            public const string DeleteTournament = BaseEndpoint + "/delete" + "/{id}";
        }
        public static class ActivityType
        {
            private const string BaseEndpoint = "~/" + AreaName + "/activity-type";
            public const string GetAllActivity = BaseEndpoint + "/get-all";
            public const string GetSingleActivity = BaseEndpoint + "/get-by-id" + "/{id}";
            public const string CreateActivity = BaseEndpoint + "/create";
            public const string UpdateActivity = BaseEndpoint + "/update" + "/{id}";
            public const string DeleteActivity = BaseEndpoint + "/delete" + "/{id}";
        }
        public static class Map
        {
            private const string BaseEndpoint = "~/" + AreaName + "/map";
            public const string GetAllMap = BaseEndpoint + "/get-all";
            public const string GetSingleMap = BaseEndpoint + "/get-by-id" + "/{id}";
            public const string CreateMap = BaseEndpoint + "/create";
            public const string UpdateMap = BaseEndpoint + "/update" + "/{id}";
            public const string DeleteMap = BaseEndpoint + "/delete" + "/{id}";
        }
        public static class HighSchool
        {
            private const string BaseEndpoint = "~/" + AreaName + "/highSchool";
            public const string GetAllHighSchool = BaseEndpoint + "/get-all";
            public const string GetSingleHighSchool = BaseEndpoint + "/get-by-id" + "/{id}";
            public const string CreateHighSchool = BaseEndpoint + "/create";
            public const string UpdateHighSchool = BaseEndpoint + "/update" + "/{id}";
            public const string DeleteHighSchool = BaseEndpoint + "/delete" + "/{id}";
        }
        public static class Team
        {
            private const string BaseEndpoint = "~/" + AreaName + "/team";
            public const string GetAllTeams = BaseEndpoint + "/get-all";
            public const string GetSingleTeam = BaseEndpoint + "/get-by-id" + "/{id}";
            public const string CreateTeam = BaseEndpoint + "/create";
            public const string UpdateTeam = BaseEndpoint + "/update" + "/{id}";
            public const string DeleteTeam = BaseEndpoint + "/delete" + "/{id}";
        }
        public static class Player
        {
            private const string BaseEndpoint = "~/" + AreaName + "/player";
            public const string GetAllPlayers = BaseEndpoint + "/get-all";
            public const string GetPlayersByTeamId = BaseEndpoint + "/get-by-team-id" + "/{teamId}";
            public const string GetSinglePlayer = BaseEndpoint + "/get-by-id" + "/{id}";
            public const string CreatePlayer = BaseEndpoint + "/create";
            public const string UpdatePlayer = BaseEndpoint + "/update" + "/{id}";
            public const string DeletePlayer = BaseEndpoint + "/delete" + "/{id}";
        }
        public static class Round
        {
            private const string BaseEndpoint = "~/" + AreaName + "/round";
            public const string GetAllRounds = BaseEndpoint + "/get-all";
            public const string GetSingleRound = BaseEndpoint + "/get-by-id" + "/{id}";
            public const string CreateRound = BaseEndpoint + "/create";
            public const string UpdateRound = BaseEndpoint + "/update" + "/{id}";
            public const string DeleteRound = BaseEndpoint + "/delete" + "/{id}";
        }
        public static class Match
        {
            private const string BaseEndpoint = "~/" + AreaName + "/match";
            public const string GetAllMatches = BaseEndpoint + "/get-all";
            public const string GetSingleMatch = BaseEndpoint + "/get-by-id" + "/{id}";
            public const string CreateMatch = BaseEndpoint + "/create";
            public const string UpdateMatch = BaseEndpoint + "/update" + "/{id}";
            public const string DeleteMatch = BaseEndpoint + "/delete" + "/{id}";
        }
        public static class User
        {
            private const string BaseEndpoint = "~/" + AreaName + "/user";
            public const string GetAllUser = BaseEndpoint + "/get-all";
            public const string GetSingleUser = BaseEndpoint + "/get-by-id" + "/{id}";
            public const string CreateUser = BaseEndpoint + "/create";
            public const string UpdateUser = BaseEndpoint + "/update" + "/{id}";
            public const string DeleteUser = BaseEndpoint + "/delete" + "/{id}";
            public const string SearchUser = BaseEndpoint + "/search-user";
        }
        public static class TeamInMatch
        {
            private const string BaseEndpoint = "~/" + AreaName + "/team-in-match";
            public const string GetAllTeamsInAMatch = BaseEndpoint + "/get-all-teams-in-match-id" + "/{matchId}";
            public const string AddATeamToMatch = BaseEndpoint + "/add-team-to-match-id" + "/{matchId}";
            public const string DeleteTeamFromMatch = BaseEndpoint + "/delete-team-with-id"+ "/{teamId}";
            public const string UpdateResultForTeamInMatch = BaseEndpoint + "/update-result-for-team-in-match" + "/{teamId}";
        }

    }
}
