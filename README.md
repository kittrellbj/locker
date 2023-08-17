# Locker

Locker is a comprehensive software solution designed to manage the locking and unlocking of users' directories on Windows computing systems. It offers simple functionality as an executable tool that cater to system administrators of Windows environments. This README provides detailed information about the software, including its features, system requirements, installation instructions, and usage guidelines.

## Table of Contents

- [Features](#features)
- [System Requirements](#system-requirements)
- [Installation](#installation)
- [Usage](#usage)
- [License](#license)
- [Contact](#contact)

## Features

- **Populate Users**: The Populate button will find all user objects in the Windows system that have files/a directory and display them in a list. To lock or unlock files, select the user from the list by clicking, and Locker will send all commands to that user's directory, subdirectory, and files.
- **Unlocking Files**: With a button press, Locker will unlock a user's files by adding the 'Everyone' group to the user's directory, subdirectories, and files recursively in the user's tree.
- **Locking Files**: Using the same process, Locker will remove the 'Everyone' group's Full Control permission on the user's directory, subdirectories, and files recursively.
- **Open Users Directory**: After locking or unlocking files, the Users Directory button will launch a file explorer window to the C:\Users directory for quicker access.
- **Status Bar and Console**: The status bar and console allow you to track Locker's progress.

## System Requirements

Locker was built using .NET C# 6.0 LTS and uses some **Windows-only** libraries. For information on running this software, refer to: https://learn.microsoft.com/en-us/dotnet/framework/get-started/system-requirements

## Installation

Follow these steps to install Locker:

1. Download the latest release from [GitHub Releases: win-locker.zip](https://github.com/kittrellbj/locker/blob/main/Locker/bin/Release/net6.0-windows/win-locker.zip) - 8/17/2023 - 81 KB
2. Unzip the downloaded file.
3. Run the executable and follow the on-screen instructions. **NOTE:** Locker will need to be elevated with administrator permissions to perform many functions.

## Usage

Here's how to get started with Locker:

1. **Step 1**: Launch the locker.exe application with elevated (administrator) permissions.
2. **Step 2**: Click "Populate" to scan for user objects/directories on the current system.
3. **Step 3**: To unlock files, click Unlock. Locker will go through the files and set permissions such that anyone with physical access to the system has Full Control permissions.
4. **Step 4**: To lock files, click Lock. Locker will reverse the unlocking operation by removing the Full Control permissions it added.
5. **Step 5**: For quick access, a button called Users Directory will open the Users directory.

## License

Locker is licensed under the [GPL 3.0 License](https://www.gnu.org/licenses/gpl-3.0.en.html).

## Contact

For any questions, issues, suggestions, or feedback, open an issue here.

---

Thank you for using Locker!
