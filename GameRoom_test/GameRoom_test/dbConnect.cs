using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace GameRoom_test
{
    class DbConnect
    {
        MySqlConnection conn;
        readonly string serverName = "localhost";
        readonly string serverPort = "3306";
        readonly string serverDB = "server";
        readonly string serverUsername = "root";
        readonly string serverPassword = "";
        bool success = false;

        public void Initialize()
        {
            try
            {
                conn = new MySqlConnection($"datasource='{serverName}';port={serverPort};database={serverDB};username='{serverUsername}';password='{serverPassword}'");
                if (conn.State == ConnectionState.Closed)
                    conn.Open();

                success = true;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
                success = false;
            }
        }
        public ConnectionState State {
            get
            {
                return conn.State;
            }
        }
        public void Close()
        {
            if (conn.State == ConnectionState.Open)
                conn.Close();
        }
        public bool Login(string username, string password)
        {
            this.Initialize();
            bool ret = false;
            string query = "SELECT * FROM `users` WHERE `username` = @user AND `password` = @pw";
            MySqlCommand command = new MySqlCommand(query, conn);
            command.Parameters.AddWithValue("@user", username);
            command.Parameters.AddWithValue("@pw", password);

            if (success == true)
            {
                MySqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    reader.Read();
                    if ((int)reader["status"] == 0)
                    {
                        User.username = reader["username"].ToString();
                        User.email = reader["email"].ToString();
                        User.picture = reader["picture"].ToString();
                        User.uid = Convert.ToInt32(reader["id"]);
                        User.islogged = true;
                        UpdateUserStatus(1, User.uid);
                        ret = true;
                    }
                    else
                        return false;
                    
                }
                this.Close();
            }
            return ret;
        }
        public DataTable ListRooms()
        {
            this.Initialize();
            DataTable dt = new DataTable();
            string query = "SELECT * FROM `rooms`";
            MySqlCommand command = new MySqlCommand(query, conn);
            MySqlDataAdapter adapter = new MySqlDataAdapter(command);

            adapter.Fill(dt);
            this.Close();
            return dt;
        }
        public string getUserName(int id)
        {
            this.Initialize();
            string ret = string.Empty;
            string query = "SELECT `id`, `username` FROM `users` WHERE `id` = @id";
            MySqlCommand command = new MySqlCommand(query, conn);
            command.Parameters.AddWithValue("@id", id);
            MySqlDataReader reader = command.ExecuteReader();

            if (reader.HasRows)
            {
                reader.Read();
                ret = reader["username"].ToString();
            }
            this.Close();
            return ret;
        }
        public int getPlayersNum(int roomid)
        {
           
                this.Initialize();
                int ret = 0;
                DataTable dt = new DataTable();
                string query = "SELECT `userid` FROM `roomplayers` WHERE `roomid` = @roomid";
                MySqlCommand command = new MySqlCommand(query, conn);
                command.Parameters.AddWithValue("@roomid", roomid);
                MySqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                        ret += 1;
                }
                this.Close();
                return ret;
            
        }
        public DataTable GetPlayersFromRoom(int roomid)
        {
           
                this.Initialize();
                DataTable dt = new DataTable();
                string query = "SELECT `userid` FROM `roomplayers` WHERE `roomid` = @roomid";
                MySqlCommand command = new MySqlCommand(query, conn);
                command.Parameters.AddWithValue("@roomid", roomid);
                MySqlDataAdapter adapter = new MySqlDataAdapter(command);

                adapter.Fill(dt);
                this.Close();
                return dt;
            
        }
        public bool CreateRoom(Room room)
        {
                this.Initialize();
                bool result = false;

                string query = "INSERT INTO `rooms`(`roomid`, `creatorid`, `password`, `maxplayers`) VALUES (@roomid,@creatorid,@password,@maxplayers)";
                MySqlCommand command = new MySqlCommand(query, conn);
                command.Parameters.AddWithValue("@roomid", room.id);
                command.Parameters.AddWithValue("@creatorid", room.creatorid);
                command.Parameters.AddWithValue("@password", room.pw);
                command.Parameters.AddWithValue("@maxplayers", room.maxplayers);
                command.ExecuteNonQuery();

                this.Close();
                return result;
        }
        public bool AlreadyInRoom(int userid, int roomid)
        {
                this.Initialize();
                bool ret = false;
                string query = "SELECT `roomid`, `userid` FROM `roomplayers` WHERE `userid` = @id";
                MySqlCommand command = new MySqlCommand(query, conn);
                command.Parameters.AddWithValue("@id", userid);
                MySqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                    ret = true;
                this.Close();
                return ret;     
        }
        public bool EnterRoom(int userid, int roomid, string password)
        {
                DateTime dt = DateTime.Now;
                this.Initialize();
                bool result = false;


                string query = "INSERT INTO `roomplayers`(`roomid`, `userid`, `datetime`) VALUES (@roomid,@userid,@datetime)";
                MySqlCommand command = new MySqlCommand(query, conn);
                command.Parameters.AddWithValue("@roomid", roomid);
                command.Parameters.AddWithValue("@userid", userid);
                command.Parameters.AddWithValue("@datetime", dt);
                command.ExecuteNonQuery();

                this.Close();
                return result;
            
        }
        public bool RemovePlayerFromRoom(int userid, int roomid)
        {        
                this.Initialize();
                string query = "DELETE FROM `roomplayers` WHERE `roomid` = @roomid AND `userid` = @userid";
                MySqlCommand command = new MySqlCommand(query, conn);
                command.Parameters.AddWithValue("@roomid", roomid);
                command.Parameters.AddWithValue("@userid", userid);
                command.ExecuteNonQuery();
                this.Close();
                return true;
        }
        public void RemoveRoom(int roomid, int creatorid)
        {
                this.Initialize();
                string query = "DELETE FROM `rooms` WHERE `roomid` = @roomid AND `creatorid` = @creatorid";
                MySqlCommand command = new MySqlCommand(query, conn);
                command.Parameters.AddWithValue("@roomid", roomid);
                command.Parameters.AddWithValue("@creatorid", creatorid);
                command.ExecuteNonQuery();
                this.Close();
                this.Initialize();
                string query2 = "DELETE FROM `roomplayers` WHERE `roomid` = @roomid";
                MySqlCommand command2 = new MySqlCommand(query2, conn);
                command2.Parameters.AddWithValue("@roomid", roomid);
                command2.ExecuteNonQuery();
                this.Close();
        }
        public bool UpdateUserStatus(int status, int userid)
        {
            this.Initialize();
            string query = "UPDATE `users` SET `status` = @status WHERE `id` = @userid";
            MySqlCommand command = new MySqlCommand(query, conn);
            command.Parameters.AddWithValue("@status", status);
            command.Parameters.AddWithValue("@userid", userid);
            command.ExecuteNonQuery();
            this.Close();
            return true;
        }
        public bool UpdateRoomSettings(int maxplayers, string pw, int roomid)
        {
            this.Initialize();
            string query = "UPDATE `rooms` SET `maxplayers` = @maxplayers, `password` = @password WHERE `roomid` = @roomid";
            MySqlCommand command = new MySqlCommand(query, conn);
            command.Parameters.AddWithValue("@maxplayers", maxplayers);
            command.Parameters.AddWithValue("@password", pw);
            command.Parameters.AddWithValue("@roomid", roomid);
            command.ExecuteNonQuery();
            this.Close();
            return true;
        }
        public void GrabRoomSettings(int roomid, ref int maxplayers, ref string password)
        {
            this.Initialize();

            DataTable dt = new DataTable();
            string query = "SELECT `password`, `maxplayers` FROM `rooms` WHERE `roomid` = @roomid";
            MySqlCommand command = new MySqlCommand(query, conn);
            command.Parameters.AddWithValue("@roomid", roomid);
            MySqlDataReader reader = command.ExecuteReader();

            if (reader.HasRows)
            {
                reader.Read();

                password = reader["password"].ToString();
                maxplayers = (int)reader["maxplayers"];
            }
            this.Close();
        }
    }
}

