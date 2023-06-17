namespace Talia.Connection
{
    public static class DBUtilities
    {
        public readonly static string GET_USER_LIST = "[dbo].[uspGetUserList]";
        public readonly static string GET_STORE_LIST = "[dbo].[uspGetStoreList]";
        public readonly static string DELETE_STORE_LIST = "[dbo].[uspDeleteStore]";
        public readonly static string INSERT_NEW_STORE = "[dbo].[uspNewStore]";
        public readonly static string INSERT_NEW_APP_USER = "[Users].[NewUser]";
        public readonly static string DELETE_APP_USER = "[Users].[DeleteUser]";
        public readonly static string GET_APP_USER = "[Users].[GetUser]";
        public readonly static string UPDATE_APP_USER = "[Users].[UpdateUser]";
        public readonly static string VALIDATE_USER_CREDENTIALS = "[Users].[CheckUser]";
        public readonly static string GET_USER_ROLES = "[Users].[GetUserRoles]";
        public readonly static string ADD_USER_TO_ROLES = "[Users].[NewUserRole]";
        public readonly static string DELETE_USER_FROM_ROLES = "[Users].[RemoveUserRole]";
        public readonly static string GET_CURRENT_USER_ID = "[Users].[GetUserId]";
        public readonly static string OUTPUT_PARAM = "@User_count";
        public readonly static string INSERT_NEW_ORDER = "[Orders].[AddNewOrder]";
        public readonly static string UPDATE_ORDER_STATUS = "[Orders].[UpdateOrderStatus]";
    }
}
