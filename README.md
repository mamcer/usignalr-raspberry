# uSignalR Raspberry Pi 

## Description

Initially built on MonoDevelop 5.5 in 2015. Targeting a Raspberry Pi model B. Originally hosted in bitbucket private git repository.

The idea was to play remotely some music on the Raspberry Pi which was connected to a decent pair of speakers. The player supports basic functions like playing a file from a list, stop playing and increase/decrease the volume. All in realtime powered by SignalR.

Didn't know that at least from the 3.5mm stereo jack you don't get the best audio quality. The POC works pretty well but the quality of the sound was pretty bad. After a little research I found some raspberry sound cards for sell but at least in my country (Argentina) they were expensive (compared to the raspberry pi price bought in USA)

Basically this POC ended up just for fun, some initial experience developing in Linux with Mono Develop and to play with AngularJS.

## Install

All are web applications, at the basic level you can SCP the files to the raspberry for deployment. This (never left the POC status) application doesn't have a Datastore. For example the angular application gets the data from a `songs.json` file.

If I remember well I use nginx for hosting. The server is configured to use mpg321 as the mp3 player and amixer to change the volume.