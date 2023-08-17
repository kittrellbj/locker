/*
 * Author: Brian Kittrell, Exteran Studios LLC
 * Copyright © 2023 Exteran Studios LLC
 * 
 * Date: August 16, 2023
 * License: GNU General Public License (GPL) 3.0
 * Description: This program allows you to lock and unlock directories and files within the 'C:\Users' directory. 
 * It provides buttons to populate the directory list, lock selected directories and files, and unlock selected directories and files. 
 * The progress bar 'viewStatus' updates as the locking and unlocking operations are performed. The operation details are displayed in the 'txtConsole' TextBox, 
 * including affected directories, files, and any access denied errors.
 * 
 * GPL 3.0
 * 
 * This program is free software; you can redistribute it and/or modify it under the terms of the GNU General Public License as published by the Free Software Foundation; either version 3 of the License, 
 * or (at your option) any later version.
 *
 * This program is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the GNU 
 * General Public License for more details.
 *
 * You should have received a copy of the GNU General Public License along with this program; if not, write to the Free Software Foundation, Inc., 51 Franklin Street, Fifth Floor, Boston, MA 02110-1301, USA.
 *
 * ====================================
 *        DISCLAIMER & WARNING
 * ====================================
 *
 * This program requires administrator privileges to perform certain actions that modify system files and permissions. Running this program without proper understanding or caution can lead to unintended consequences and potential data loss.
 *
 * PLEASE READ CAREFULLY:
 *
 * 1. Administrator Privileges: 
 * This program needs to be executed with administrator privileges to function correctly. Running it without elevated permissions may result in errors, incomplete operations, or other unexpected behavior.
 *
 * 2. Data Loss and System Changes:
 * Be aware that this program can modify permissions on files and directories. Incorrect usage can lead to data loss, system instability, or security vulnerabilities.
 *
 * 3. Backup Your Data:
 * Before using this program, ensure that you have backed up your important data. We are not responsible for any loss of data caused by the use of this program.
 *
 * 4. Use at Your Own Risk:
 * By using this program, you acknowledge that you understand the potential risks involved and agree to use it at your own risk.
 *
 * 5. Liability:
 * Exteran Studios LLC and Brian Kittrell are not liable for any damages, losses, or issues caused by the use of this program. You are solely responsible for any consequences that arise from using this software.
 * 
 * 6. No Malicious Code:
 * No purposefully or intentionally malicious code was added to the original source code of this software, but careless use or misues of this software could cause damage to your computer due to the operations performed
 * by the software. Develop a full understanding of the implications of these operations before using the software.
 * 
 * 7. Some Files Remain Locked:
 * This software was designed to unlock a user's files in the Windows file system such that a system administrator can recover the files in the event that the user can no longer or should no longer access the files 
 * themselves, for purposes of investigation of the user and/or the user's activities, to recover the files of a user who cannot or will not provide them voluntarily, or in cases of catastrophic events or other cirucmstances 
 * where an administrator needs to recover the files. However, some files remain locked, such as critical system files. Since these files usually cannot be altered by a user during the normal course of their activities 
 * on a computer system without also possessing administrator permissions on the system, no additional effort was made to attempt an override on such files. A system administrator will be able to access these files 
 * even in that case, but this software unlocks or locks most of the user's files for the administrator's convenience.
 * 
 * If you are unsure about using this program or its consequences, please consult with a qualified IT professional before proceeding.
 *
 * BY RUNNING THIS PROGRAM, YOU AGREE TO THE TERMS OUTLINED ABOVE, UNDERSTAND THE WARNINGS GIVEN, AND ACCEPT THE DISCLAIMER AND SOFTWARE AS-IS. IF YOU DO NOT AGREE, DO NOT PROCEED.
 *
 * ====================================
 */

using System.Diagnostics;
using System.Security.AccessControl;

namespace Locker
{
    /// <summary>
    /// Represents the main form of the Locker application.
    /// </summary>
    public partial class formLocker : Form
    {
        /// <summary>
        /// Initializes a new instance of the Form1 class.
        /// </summary>
        public formLocker()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Event handler for the "Populate" button click.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="e">The event arguments.</param>
        private void PopulateButton_Click(object sender, EventArgs e)
        {
            Debug.WriteLine("Populate button clicked."); // Check if this message appears in the Output window

            lstUsers.Items.Clear();

            string usersDirectory = @"C:\Users";
            string[] userDirectories = Directory.GetDirectories(usersDirectory);

            foreach (string userDir in userDirectories)
            {
                lstUsers.Items.Add(Path.GetFileName(userDir));
            }
        }

        /// <summary>
        /// Event handler for the "Users Directory" button click.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="e">The event arguments.</param>
        private void UsersDirectoryButton_Click(object sender, EventArgs e)
        {
            Debug.WriteLine("Opening Users Directory."); // Debug to console
            Process.Start("explorer.exe", @"C:\Users");
        }

        /// <summary>
        /// Event handler for the "Unlock" button click.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="e">The event arguments.</param>
        private void UnlockButton_Click(object sender, EventArgs e)
        {
            string? selectedDirectory = lstUsers.SelectedItem?.ToString();

            if (selectedDirectory != null)
            {
                string fullPath = Path.Combine(@"C:\Users", selectedDirectory);
                viewStatus.Value = 0; // Reset progress bar

                UnlockDirectory(fullPath);

                txtConsole.AppendText("\nOperation complete. Files have been UNLOCKED.\n");
            }
        }

        /// <summary>
        /// Unlocks a directory and its subdirectories by adding Full Control permissions for Everyone.
        /// </summary>
        /// <param name="directory">The directory to unlock.</param>
        private void UnlockDirectory(string directory)
        {
            DirectoryInfo dirInfo = new DirectoryInfo(directory);
            DirectorySecurity dirSecurity = dirInfo.GetAccessControl();

            string[] allFilesAndDirs = GetAllFilesAndDirectories(directory); // Get a list of all files and directories
            int totalItems = allFilesAndDirs.Length;
            int affectedItems = 0;

            foreach (string item in allFilesAndDirs)
            {
                dirSecurity.AddAccessRule(new FileSystemAccessRule("Everyone", FileSystemRights.FullControl, InheritanceFlags.ContainerInherit | InheritanceFlags.ObjectInherit, PropagationFlags.None, AccessControlType.Allow));
                dirInfo.SetAccessControl(dirSecurity);

                UpdateProgressBar(++affectedItems, totalItems); // Update progress bar
                AppendToConsoleRecursive(item); // List all affected directories and files
            }

            viewStatus.Value = 100; // Fill progress bar

            AppendToConsoleRecursive(directory); // List all affected directories and files
        }

        /// <summary>
        /// Locks a directory and its subdirectories by removing Full Control permissions for Everyone.
        /// </summary>
        /// <param name="directory">The directory to lock.</param>
        private void LockButton_Click(object sender, EventArgs e)
        {
            string? selectedDirectory = lstUsers.SelectedItem?.ToString();

            if (selectedDirectory != null)
            {
                string fullPath = Path.Combine(@"C:\Users", selectedDirectory);
                viewStatus.Value = 0; // Reset progress bar

                LockDirectory(fullPath);

                txtConsole.AppendText("\nOperation complete. Files have been LOCKED.\n");
            }
        }
        private void LockDirectory(string directory)
        {
            DirectoryInfo dirInfo = new DirectoryInfo(directory);
            DirectorySecurity dirSecurity = dirInfo.GetAccessControl();

            string[] allFilesAndDirs = GetAllFilesAndDirectories(directory); // Get a list of all files and directories
            int totalItems = allFilesAndDirs.Length;
            int affectedItems = 0;

            foreach (string item in allFilesAndDirs)
            {
                dirSecurity.RemoveAccessRuleAll(new FileSystemAccessRule("Everyone", FileSystemRights.FullControl, InheritanceFlags.ContainerInherit | InheritanceFlags.ObjectInherit, PropagationFlags.None, AccessControlType.Allow));
                dirInfo.SetAccessControl(dirSecurity);

                UpdateProgressBar(++affectedItems, totalItems); // Update progress bar
                AppendToConsoleRecursive(item); // List all affected directories and files
            }

            viewStatus.Value = 100; // Fill progress bar

            AppendToConsoleRecursive(directory); // List all affected directories and files
        }

        /// <summary>
        /// Recursively appends the contents of a directory and its subdirectories to the txtConsole.
        /// </summary>
        /// <param name="directory">The directory to list.</param>
        private void AppendToConsoleRecursive(string directory)
        {
            txtConsole.AppendText(directory + Environment.NewLine); // List the current directory

            try
            {
                string[] files = Directory.GetFiles(directory);
                foreach (string file in files)
                {
                    txtConsole.AppendText(file + Environment.NewLine); // List each file
                }

                string[] subdirectories = Directory.GetDirectories(directory);
                foreach (string subdirectory in subdirectories)
                {
                    AppendToConsoleRecursive(subdirectory); // List all subdirectories and their contents
                }
            }
            catch (UnauthorizedAccessException)
            {
                txtConsole.AppendText($"Access denied: {directory}" + Environment.NewLine); // Handle access denied errors
            }
            catch (IOException ex)
            {
                txtConsole.AppendText($"Error processing: {ex.Message}");
            }
        }

        /// <summary>
        /// Recursively retrieves a list of all files and directories within a given directory.
        /// </summary>
        /// <param name="directory">The directory to start the search from.</param>
        /// <returns>An array of strings representing the paths of all files and directories found.</returns>
        private string[] GetAllFilesAndDirectories(string directory)
        {
            List<string> allItems = new List<string>();

            try
            {
                allItems.AddRange(Directory.GetFiles(directory));
                allItems.AddRange(Directory.GetDirectories(directory));

                foreach (string subdirectory in Directory.GetDirectories(directory))
                {
                    allItems.AddRange(GetAllFilesAndDirectories(subdirectory));
                }
            }
            catch (UnauthorizedAccessException)
            {
                txtConsole.AppendText($"Access denied: {directory}" + Environment.NewLine); // Handle access denied errors
            }

            return allItems.ToArray();
        }

        /// <summary>
        /// Method to update the progress bar based on the current progress and total items.
        /// </summary>
        /// <param name="currentProgress">The current progress.</param>
        /// <param name="totalItems">The total number of items.</param>
        private void UpdateProgressBar(int currentProgress, int totalItems)
        {
            viewStatus.Value = (int)((double)currentProgress / totalItems * 100);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}