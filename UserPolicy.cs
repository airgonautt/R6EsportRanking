namespace R6Ranking {
    public class UserPolicy {
        public const string VIEW = "VIEW";
        public const string ADD = "ADD";
        public const string EDIT = "EDIT";
        public const string DELETE = "DELETE";

        public static List<string> GetPolicies() {
            return new List<string> {
                VIEW,
                ADD,
                EDIT,
                DELETE
            };
        }
    }
}
