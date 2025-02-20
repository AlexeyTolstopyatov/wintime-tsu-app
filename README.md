# WinTime
WinTime (Windows InTime, or InTime for Windows) was built 
for showing TSU schedule
for every entity or any group.
All, what you need is select faculty and group, registered
in Tomsk State University database and accept with choise.

### Tools
This is an Win32 windowed application, which using
C#, WPF and other Window controls/frameworks,
 - .net6.0-windows - foundation of windowed application
 - C# 10 - language standard version for .NET 6
 - [WPF-UI](https://github.com/lepoco/wpfui) - large framework, which represents many Fluent-style controls
MVVM experience, and other features.
 - [MicaWPF](https://github.com/Simnico99/MicaWPF) - Enables Windows 11 Mica experience for Window

### Tomsk State University InTime service
Public application [TSU InTime](https://intime.tsu.ru) lets you
see timetable everywhere and represents kinds of API, based on
used by you platform. (I know only)
 - `Web`
 - `Mobile`

WinTime uses `Web` API by default.

### Screenshots
At the Feb 2025 moment, Windows client looks like that, 
and it will be improve next time.

![image](https://github.com/user-attachments/assets/dbb64529-84c6-4bfa-a082-1eb6e6a27375)

Maximized Window 

![image](https://github.com/user-attachments/assets/117727a4-687d-475f-80eb-cee2834df1b3)

### What's next?
In the future I want to bind it with `TSU.Account` 
services and show little more about 
credit-book and other data, using TSU InTime public API.
