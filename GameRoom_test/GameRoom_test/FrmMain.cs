using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameRoom_test
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }
        DbConnect dbConnect = new DbConnect();
        Room room = new Room();
        bool isCreator = false;
        

        private void LoadRooms()
        {
            DataTable dt = dbConnect.ListRooms();

            flowRoomList.Controls.Clear();
            foreach (DataRow row in dt.Rows)
            {
                int roomid = Convert.ToInt32(row["roomid"]);
                int creatorid = Convert.ToInt32(row["creatorid"]);
                string creatorname = dbConnect.getUserName(Convert.ToInt32(row["creatorid"]));
                int maxplayers = Convert.ToInt32(row["maxplayers"]);
                string password = row["password"].ToString();

                int playersat = dbConnect.getPlayersNum(roomid);
                Button btn = new Button();
                Room roomEntry = new Room()
                {
                    maxplayers = maxplayers,
                    pw = password,
                    id = roomid,
                    creatorid = creatorid,
                    playersat = playersat,
                    creatornick = creatorname
                };

                string roomLabel = $"Room Number: {roomid} Created By: {creatorname} Maxplayers: {playersat}/{maxplayers}";

                btn.Name = "btn" + roomid;
                btn.Text = roomLabel;
                btn.Size = new Size(flowRoomList.Size.Width - 10, 23);
                btn.Tag = roomEntry;
                btn.Click += ButtonEntryRoom_Click;
                flowRoomList.Controls.Add(btn);

            }
        }
        private void ButtonEntryRoom_Click(object sender, EventArgs e)
        {

            Button btn = (Button)sender;
            Room roomEntryInfo = (Room)btn.Tag;
            if(roomEntryInfo.playersat < roomEntryInfo.maxplayers)
            {
                if (!dbConnect.AlreadyInRoom(User.uid, roomEntryInfo.id))
                    dbConnect.EnterRoom(User.uid, roomEntryInfo.id, roomEntryInfo.pw);
                //this.Hide();
                //FrmRoom frmRoom = new FrmRoom();
                //frmRoom.ShowRoom(rInfo.id, rInfo.creatorid, rInfo.pw, rInfo.maxplayers);
                TabServersRoom.TabPages.Remove(tabServers);
                TabServersRoom.TabPages.Add(tabRoom);
                btnCloseRoom.Visible = true;
                btnCreateRoom.Visible = false;
                UpdateRomInfo(roomEntryInfo);

            }
            else
                MessageBox.Show("A Sala está cheia", "Game Room", MessageBoxButtons.OK,MessageBoxIcon.Information);
                       
        }
        private void UpdateRomInfo(Room room)
        {
            this.room.Clear();
            this.room = room;
            numMaxPlayers.Value = room.maxplayers;
            txtPw.Text = room.pw;

            if (room.creatorid != User.uid)
            {
                gbRoomSettings.Enabled = false;
            }
            else
            {    
                gbRoomSettings.Text = "Your Room Settings";
                gbRoomSettings.Enabled = true;
            }
            tabRoom.Text = $"{room.creatornick}'s Lobby";
            checkPlayersRoom.Enabled = true;
            checkPlayersRoom.Start();
            checkRoomList.Stop();
            checkRoomList.Enabled = false;
        }
        private void CloseRoom()
        {
            if (room.creatorid == User.uid)
                dbConnect.RemoveRoom(room.id, room.creatorid);
            else
                dbConnect.RemovePlayerFromRoom(User.uid, room.id);

            btnCreateRoom.Visible = true;
            btnCloseRoom.Visible = false;

            TabServersRoom.TabPages.Remove(tabRoom);
            TabServersRoom.TabPages.Add(tabServers);

            room.Clear();

            checkPlayersRoom.Enabled = false;
            checkPlayersRoom.Stop();
            checkRoomList.Enabled = true;
            checkRoomList.Start();
            
        }
        private void CreateRoom()
        {
            Room createdRoom = new Room(User.genRoomId, User.uid, User.username, string.Empty, 0, 2);

            dbConnect.CreateRoom(createdRoom);
            dbConnect.EnterRoom(User.uid, createdRoom.id, "");

            btnCreateRoom.Visible = false;
            btnCloseRoom.Visible = true;

            TabServersRoom.TabPages.Remove(tabServers);
            TabServersRoom.TabPages.Add(tabRoom);

            UpdateRomInfo(createdRoom);
        }
        void GetPlayers()
        {
            DataTable playersList = dbConnect.GetPlayersFromRoom(room.id);
            if (playersList.Rows.Count == 0)
            {
                if (!isCreator)
                {
                    checkPlayersRoom.Stop();
                    checkPlayersRoom.Enabled = false;
                    TabServersRoom.TabPages.Remove(tabRoom);
                    TabServersRoom.TabPages.Add(tabServers);
                    btnCloseRoom.Visible = false;
                    btnCreateRoom.Visible = true;
                    checkRoomList.Enabled = true;
                    checkRoomList.Start();
                    flowRoomList.Controls.Clear();
                    MessageBox.Show("The lobby was closed!", "Game Room", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    
                }
            }
            flowPlayersList.Controls.Clear();
            foreach (DataRow player in playersList.Rows)
            {
                Button btn = new Button()
                {
                    Name = "btn" + player["userid"],
                    Text = dbConnect.getUserName((int)player["userid"])
                };

                if ((int)player["userid"] == room.creatorid)
                    btn.Text += " [HOST]";

                btn.Size = new Size(200, 90);
                flowPlayersList.Controls.Add(btn);
            }

        }
        private void BtnCreateRoom_Click(object sender, EventArgs e)
        {
            CreateRoom();
        }
        private void BtnCloseRoom_Click(object sender, EventArgs e)
        {
            CloseRoom();
        }
        private void CheckRoomList_Tick(object sender, EventArgs e)
        {
            LoadRooms();
        }
        private void FrmMain_Load(object sender, EventArgs e)
        {
            if (User.islogged == false)
            {
                FrmLogin login = new FrmLogin();
                login.Show();
                this.Close();
            }
            LoadRooms();
            checkRoomList.Start();
            lblUsername.Text = $"Welcome, {User.username} ({User.email})";
            Application.ApplicationExit += Application_ApplicationExit;
            TabServersRoom.TabPages.Remove(tabRoom);

        }
        private void FrmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            dbConnect.UpdateUserStatus(0, User.uid);
            if (Application.OpenForms.Count == 0)
                Application.Exit();
        }
        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Você deseja sair?", "Game Room", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.No)
                e.Cancel = true;
            else
            {
                CloseRoom();
                dbConnect.UpdateUserStatus(0, User.uid);
            }
                
        }
        private void Application_ApplicationExit(object sender, EventArgs e)
        {
            dbConnect.UpdateUserStatus(0, User.uid);
        }

        private void CheckPlayersRoom_Tick(object sender, EventArgs e)
        {
            GetPlayers();
            if(room.creatorid != User.uid)
            {
                int mp = 0;
                string pw = string.Empty;
                dbConnect.GrabRoomSettings(room.id, ref mp,ref pw );

                if(((decimal)mp != numMaxPlayers.Value) & (mp > 0))
                    numMaxPlayers.Value = (decimal)mp;
                if (pw != txtPw.Text)
                    txtPw.Text = pw;
                
            }
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            if(room.creatorid == User.uid)
            {
                dbConnect.UpdateRoomSettings((int)numMaxPlayers.Value, txtPw.Text, room.id);
            }
        }
    }
}
