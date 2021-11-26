using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using AutomationLib;
using InputManager;

namespace EliteRoadLoader
{
    public partial class RoadLoaderForm : Form
    {
        List<string> systems = new List<string>();
        int systemIndex = -1;

        //Hotkeys
        private GlobalHotkey hk_F4;
        private GlobalHotkey hk_F5;
        private GlobalHotkey hk_F6;

        public RoadLoaderForm()
        {
            InitializeComponent();
        }

        private void LoadNext(object sender, EventArgs e)
        {
            if (systemIndex + 1 < systems.Count)
            {
                systemIndex++;
                string currentSystem = systems[systemIndex];
                lblDebug.Text = "[Next] Loaded \"" + currentSystem + "\".";
                Clipboard.SetText(currentSystem);
                Console.Beep(2000, 20);
            }
            else
                Console.Beep(50, 100);
        }

        private void LoadPrev(object sender, EventArgs e)
        {
            if (systemIndex > 0)
            {
                systemIndex--;
                string currentSystem = systems[systemIndex];
                lblDebug.Text = "[Prev] Loaded \"" + currentSystem + "\".";
                Clipboard.SetText(currentSystem);
                Console.Beep(5000, 20);
            }
            else
                Console.Beep(50, 100);
        }

        private void WriteNext(object sender, EventArgs e)
        {
            if (systemIndex + 1 < systems.Count)
            {
                systemIndex++;
                string currentSystem = systems[systemIndex];
                lblDebug.Text = "[Next] Pasted \"" + currentSystem + "\".";

                // Copy and paste ; NOTE: SendKeys.Send(currentSystem); is unreliable!
                Clipboard.SetText(currentSystem);
                Keyboard.ShortcutKeys(new Keys[] { Keys.LControlKey, Keys.V }, 200);

                // Wait for system to show up (has no effect when it loads too slow, or there are multiple suggestions)
                Timing.RandomizedSleep(1250, 0.04);

                // Press ENTER
                Keyboard.KeyPress(Keys.Enter, 200);

                // Notify the user that it's done.
                Console.Beep(2000, 20);
            }
            else
                Console.Beep(50, 100);
        }

        private void RoadLoaderForm_Load(object sender, EventArgs e)
        {
            //Register Hotkeys (http://bloggablea.wordpress.com/2007/05/01/global-hotkeys-with-net/)
            hk_F4 = new GlobalHotkey(Keys.F4, false, false, false, false);
            hk_F4.Pressed += WriteNext;
            hk_F4.Register(this);
            hk_F5 = new GlobalHotkey(Keys.F5, false, false, false, false);
            hk_F5.Pressed += LoadNext;
            hk_F5.Register(this);
            hk_F6 = new GlobalHotkey(Keys.F6, false, false, false, false);
            hk_F6.Pressed += LoadPrev;
            hk_F6.Register(this);
        }

        private void load(List<string> filePaths)
        {
            foreach (string filePath in filePaths)
            {
                Console.Beep(200, 100);
                if (filePath.EndsWith(".csv"))
                {
                    string csvText = File.ReadAllText(filePath);
                    string[] lines = csvText.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
                    for (int i = 0; i < lines.Length; i++)
                    {
                        if (i != 0 && lines[i][0] == '"')
                        {
                            int index = lines[i].IndexOf("\",", 1);
                            if (index > 0)
                            {
                                string systemName = lines[i].Substring(1, index - 1);
                                if (systems.Count == 0 || systems.Last() != systemName) // Skip sequential duplicates
                                    systems.Add(systemName);
                            }
                        }
                    }
                }
                else
                {
                    string text = File.ReadAllText(filePath);
                    string[] lines = text.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
                    systems.AddRange(lines);
                }
            }
            txtLoaded.Text = string.Join("\r\n", systems);
            lblDebug.Text = "Loaded " + systems.Count + " system name" + (systems.Count == 1 ? "" : "s") + " from " + filePaths.Count + " file" + (filePaths.Count == 1 ? "" : "s") + ".";
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = System.Reflection.Assembly.GetExecutingAssembly().Location;
                openFileDialog.Filter = "Comma-separated values (*.csv)|*.csv|Text documents (*.txt)|*.txt|All files (*.*)|*.*";
                openFileDialog.FilterIndex = 3;
                openFileDialog.RestoreDirectory = true;
                openFileDialog.Multiselect = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    systemIndex = -1;
                    systems.Clear();
                    load(openFileDialog.FileNames.ToList());
                }
            }

        }

        private void btnPaste_Click(object sender, EventArgs e)
        {
            PasteBox box = new PasteBox("Enter one system name per line.", "Paste");
            if (box.ShowDialog() == DialogResult.OK)
            {
                Console.Beep(200, 100);
                systemIndex = -1;
                systems.Clear();
                string[] lines = box.Result.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
                systems.AddRange(lines);
                txtLoaded.Text = string.Join("\r\n", systems);
                lblDebug.Text = "Loaded " + systems.Count + " system name" + (systems.Count == 1 ? "" : "s") + " via text input.";
            }
        }

        private void RoadLoaderForm_DragDrop(object sender, DragEventArgs e)
        {
            systemIndex = -1;
            systems.Clear();
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            load(files.Where(x => x.EndsWith(".csv") || x.EndsWith(".txt")).ToList());
        }

        private void RoadLoaderForm_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop)) e.Effect = DragDropEffects.Copy;
        }

        //Enable Ctrl+A for textboxes
        private void SelectAll_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.A)
            {
                ((TextBox)sender).SelectAll();
            }
        }
    }
}
