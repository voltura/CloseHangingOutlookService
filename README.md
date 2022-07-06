# CloseHangingOutlookService

Windows Service example using .NET 6

Using via powershell as Administrator;

Install
========
sc create "Close Hanging Outlook Service" binpath="<path/to/exe>"

Start
======
sc start "Close Hanging Outlook Service" 

Check status
=============
sc query "Close Hanging Outlook Service" 

Stop
=====
sc stop "Close Hanging Outlook Service" 

Delete
=======
sc delete "Close Hanging Outlook Service" 

