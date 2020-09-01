using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;
using System.Net;
using System.Text.RegularExpressions;
using System.Linq.Expressions;
using System.IO;
using System.Xml;
using System.Xml.Linq;
using System.Runtime.CompilerServices;

/*
 * TODO:
 * check images on startup
 * 
 */

namespace Roblox_Asset_Manager_by_Kyle
{
    public partial class Form1 : Form
    {
        private const string CURRENT_VERSION = "v1.1";

        SQLiteConnection DBConnection;

        public Form1()
        {
            InitializeComponent();
            this.Text = "Roblox Asset Manager by Kyle " + CURRENT_VERSION;
            using (DBConnection = new SQLiteConnection("Data Source=assets/metadata.sqlite;Version=3;"))
            {
                DBConnection.Open();
                UpdateDecalDataGrid(DBConnection);
                DBConnection.Close();

                this.DGDatabase.Columns[0].Width = (int)(this.DGDatabase.Width * 0.05); //id
                this.DGDatabase.Columns[1].Width = (int)(this.DGDatabase.Width * 0.15); //name
                this.DGDatabase.Columns[2].Width = (int)(this.DGDatabase.Width * 0.45); //description
                this.DGDatabase.Columns[3].Width = (int)(this.DGDatabase.Width * 0.18); //link
                this.DGDatabase.Columns[4].Width = (int)(this.DGDatabase.Width * 0.12); //created timestamp
            }
        }

        //doesn't handle opening and closing the connection, need to do manually
        private void UpdateDecalDataGrid(SQLiteConnection DBConnection)
        {
            //establish database connection
            try
            {
                //fill columns and stuff

                SQLiteCommand cmd = new SQLiteCommand("select rowid,* from decals", DBConnection);
                cmd.ExecuteNonQuery();

                SQLiteDataAdapter adapter = new SQLiteDataAdapter(cmd);
                DataTable table = new DataTable("tbl_category");

                adapter.Fill(table);

                this.DGDatabase.DataSource = table.DefaultView;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error (What the heck did you do?!)");
                this.Close();
            }
        }

        //saves an a byte array as an image to the assets folder
        //Returns: format is image or not
        private bool CheckAndSaveBytesToAssets(byte[] rawBytes, long id)
        {
            if (ImageDecoding.GetImageFormat(rawBytes) != ImageDecoding.ImageFormat.unknown)
            {
                string filePath = Helper.GetRelativePath() + "/assets/" + id + ".png";
                File.WriteAllBytes(filePath, rawBytes);

                return true;
            }
            return false;
        }

        //takes in a byte array and automatically downloads the image even if it leads to xml file
        private bool SaveImageToAssets(byte[] rawBytes, long id)
        {
            //first check if image
            if (!CheckAndSaveBytesToAssets(rawBytes, id))
            {
                //check if asset leads to xml file
                try
                {
                    XDocument rbxXml = XDocument.Load("https://assetdelivery.roblox.com/v1/asset/?id=" + id);
                    var link = rbxXml.Descendants("url").ElementAt(0).Value; //just take the first link idc

                    //parse the id that leads to the actual image
                    var decalId = long.Parse(Helper.RegexFilterNumbers.Match(link).Value);

                    //overwriting var cuz uhhh yeahhh
                    rawBytes = DownloadImage("https://assetdelivery.roblox.com/v1/asset/?id=", decalId);

                    if (rawBytes != null)
                    {
                        //save the image as the original id before preview check gets all confused
                        return CheckAndSaveBytesToAssets(rawBytes, id);
                    }
                    else
                    {
                        throw new XmlException();
                    }

                }
                catch (XmlException XmlException)
                {
                    //NOT IMAGE AND NOT XML FILE SO CAN NOT BE IMAGE AT ALL!!!!!
                    return false;
                }
            }

            return true;
        }

        private void ButtonSubmit_Click(object sender, EventArgs e)
        {
            if (this.TBName.Text.Length == 0)
            {
                this.ToolStripLabel.Text = "Error: You need a name for the entry";
                return;
            }

            if (this.TBLink.Text.Length > 0 && this.TBLink.Text.StartsWith("https://roblox.com/library/"))
            {
                //check if already exists in database
                Match match = Helper.RegexFilterNumbers.Match(this.TBLink.Text);

                //url needs to have an id number
                if (match.Success)
                {
                    long id = long.Parse(match.Value);

                    //check if already exists in database
                    using (DBConnection = new SQLiteConnection("Data Source=assets/metadata.sqlite;Version=3;"))
                    {
                        DBConnection.Open();

                        SQLiteCommand checkExistence = new SQLiteCommand($"select link from decals where link='{this.TBLink.Text}'", DBConnection);
                        SQLiteDataReader reader = checkExistence.ExecuteReader();

                        //thing already exists
                        if (reader.HasRows)
                        {
                            this.ToolStripLabel.Text = id + " already exists in the database";
                            MessageBox.Show("Link already exists in database", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }

                        DBConnection.Close();
                    }

                    var rawBytes = DownloadImage("https://assetdelivery.roblox.com/v1/asset/?id=", id);

                    if (rawBytes != null)
                    {
                        //save image to assets folder
                        if(SaveImageToAssets(rawBytes, id))
                        {
                            //add to sql database
                            using (DBConnection = new SQLiteConnection("Data Source=assets/metadata.sqlite;Version=3;"))
                            {
                                DBConnection.Open();
                                SQLiteCommand cmd = new SQLiteCommand($"insert into decals (name, description, link, created) values ('{this.TBName.Text}', '{this.TBNotes.Text}', '{this.TBLink.Text}', datetime('now','localtime'))", DBConnection);
                                cmd.ExecuteNonQuery();

                                UpdateDecalDataGrid(DBConnection);

                                DBConnection.Close();
                            }

                            this.ToolStripLabel.Text = "Success: Added decal " + id + " to the database";
                        }
                    }
                }
                else
                {
                    this.ToolStripLabel.Text = "Error: Your link doesn't contain an id";
                }
            }
        }

        private byte[] ReadBytesToEnd(System.IO.Stream stream)
        {
            long originalPosition = 0;

            if (stream.CanSeek)
            {
                originalPosition = stream.Position;
                stream.Position = 0;
            }

            try
            {
                byte[] readBuffer = new byte[4096];

                int totalBytesRead = 0;
                int bytesRead;

                while ((bytesRead = stream.Read(readBuffer, totalBytesRead, readBuffer.Length - totalBytesRead)) > 0)
                {
                    totalBytesRead += bytesRead;

                    if (totalBytesRead == readBuffer.Length)
                    {
                        int nextByte = stream.ReadByte();
                        if (nextByte != -1)
                        {
                            byte[] temp = new byte[readBuffer.Length * 2];
                            Buffer.BlockCopy(readBuffer, 0, temp, 0, readBuffer.Length);
                            Buffer.SetByte(temp, totalBytesRead, (byte)nextByte);
                            readBuffer = temp;
                            totalBytesRead++;
                        }
                    }
                }

                byte[] buffer = readBuffer;
                if (readBuffer.Length != totalBytesRead)
                {
                    buffer = new byte[totalBytesRead];
                    Buffer.BlockCopy(readBuffer, 0, buffer, 0, totalBytesRead);
                }
                return buffer;
            }
            finally
            {
                if (stream.CanSeek)
                {
                    stream.Position = originalPosition;
                }
            }
        }

        private byte[] DownloadImage(string url, long id)
        {
            var request = WebRequest.Create(url + id);
            try
            {
                using (var response = request.GetResponse())
                {
                    using (var stream = response.GetResponseStream())
                    {
                        //BinaryReader reader = new BinaryReader(stream);
                        //return ReadAllBytes(reader);
                        return ReadBytesToEnd(stream);
                    }
                }
            }
            //catch (System.Net.WebException exception)
            catch(Exception exception)
            {
                this.ToolStripLabel.Text = "Id " + id + ": " + exception.Message;
            }

            return null;
        }

        private bool CheckSaveAndSetPreview(byte[] rawBytes)
        {
            if (ImageDecoding.GetImageFormat(rawBytes) != ImageDecoding.ImageFormat.unknown)
            {
                //this.ImagePreview.Image = Bitmap.FromStream(stream);
                string filePath = Helper.GetRelativePath() + "/cache/preview.png";
                File.WriteAllBytes(filePath, rawBytes);
                this.ImagePreview.ImageLocation = filePath;

                return true;
            }

            return false;
        }

        private void TextBoxLink_Changed(object sender, EventArgs e)
        {
            if (this.TBLink.Text.Length > 0 && this.TBLink.Text.StartsWith("https://roblox.com/library/"))
            {
                //download the image and display it in the image preview
                Match match = Helper.RegexFilterNumbers.Match(this.TBLink.Text);

                //url needs to have an id number
                if (match.Success)
                {
                    long id = long.Parse(match.Value);
                    var rawBytes = DownloadImage("https://assetdelivery.roblox.com/v1/asset/?id=", id);

                    if (rawBytes != null)
                    {
                        if (!CheckSaveAndSetPreview(rawBytes))
                        {
                            //id could lead to xml file containg link to actual assetum
                            try
                            {
                                XDocument rbxXml = XDocument.Load("https://assetdelivery.roblox.com/v1/asset/?id=" + id);
                                var link = rbxXml.Descendants("url").ElementAt(0).Value; //just take the first link idc

                                id = long.Parse(Helper.RegexFilterNumbers.Match(link).Value);

                                //overwriting cuz uhhh yeahhh
                                rawBytes = DownloadImage("https://assetdelivery.roblox.com/v1/asset/?id=", id);
                                if (rawBytes != null)
                                {
                                    CheckSaveAndSetPreview(rawBytes);
                                }
                                else
                                {
                                    throw new XmlException();
                                }

                            }
                            catch (XmlException XmlException)
                            {
                                //NOT IMAGE AND NOT XML FILE SO CAN NOT BE IMAGE AT ALL!!!!!
                                return;
                            }
                        }
                    }
                    else
                    {
                        //image just straight up doesn't exist on roblox :P
                    }
                }
            }
        }

        private void ButtonClear_Click(object sender, EventArgs e)
        {
            this.TBLink.Text = "https://roblox.com/library/";
            this.TBName.Text = "";
            this.TBNotes.Text = "";
        }

        private void DGDatabase_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var selectedRow = this.DGDatabase.SelectedCells[0].OwningRow.Cells;
            this.TBName.Text = (string)selectedRow[1].Value;
            this.TBNotes.Text = (string)selectedRow[2].Value;
            this.TBLink.Text = "https://roblox.com/library/";

            
            Match match = Helper.RegexFilterNumbers.Match((string)selectedRow[3].Value);

            this.ImagePreview.ImageLocation = Helper.GetRelativePath() + "/assets/" + long.Parse(match.Value) + ".png";
        }

        private void ButtonDeleteRow_Click(object sender, EventArgs e)
        {
            var selectedRows = this.DGDatabase.SelectedRows;

            if(selectedRows.Count == 0)
            {
                this.ToolStripLabel.Text = "Error: No row selected. Select a row by clicking the left most cell";
                return;
            }

            using (DBConnection = new SQLiteConnection("Data Source=assets/metadata.sqlite;Version=3;"))
            {
                DBConnection.Open();

                int deleted = 0;
                for(int i = 0; i < selectedRows.Count; i++)
                {
                    //delete from filesystem, 3rd column is link
                    Match match = Helper.RegexFilterNumbers.Match((string)selectedRows[i].Cells[3].Value);
                    File.Delete(Helper.GetRelativePath() + "/assets/" + long.Parse(match.Value));

                    //remove from database
                    SQLiteCommand cmd = new SQLiteCommand($"delete from decals where rowid={selectedRows[i].Cells[0].Value}", DBConnection);
                    cmd.ExecuteNonQuery();

                    deleted++;
                }

                //reorder rowid
                SQLiteCommand ReorderIdCommand = new SQLiteCommand("vacuum", DBConnection);
                ReorderIdCommand.ExecuteNonQuery();

                UpdateDecalDataGrid(DBConnection);
                DBConnection.Close();

                this.ToolStripLabel.Text = "Success: Deleted " + deleted + " entries";
            }
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var formPopup = new AboutForm();
            formPopup.Show(this); // if you need non-modal window
        }
    }
}
