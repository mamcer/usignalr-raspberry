# uSignalR Raspberry Pi 

## Description

Initially built on MonoDevelop 5.5 in 2015. Targeting a Raspberry Pi model B. Originally hosted in a Bitbucket private git repository.

The idea and main motivation was to play some music remotely on a Raspberry Pi which was connected to a fairly decent pair of speakers. The player supports basic functions like playing a file from a list, stop playing and increase/decrease the volume. All in realtime powered by SignalR.

at that moment didn't know that at least from the 3.5mm stereo jack you don't get the best audio quality. The POC works pretty well but the quality of the sound was bad. After a little research I found some raspberry sound cards for sell but at least in my country (Argentina) they were expensive (compared to the raspberry pi price bought in the USA)

This POC ended as another fun project which left some initial experience developing in Linux with Mono Develop and also with AngularJS.

## Install

Except the server all are web applications, they could be hosted in the same raspberry pi but where hosted in a Windows Server 2012. Only the server application ran in the raspberry pi. This application never left the POC status and for example doesn't have a Datastore in that context the angular application gets the data from a `songs.json` file.

The server is configured to use mpg321 as the mp3 player and amixer to change the volume.