# uSignalR Raspberry Pi

An AngularJS and console application (that runs in a RaspberryPi) from 2015

> More details about why I published this project in [this blog post](https://mamcer.github.io/2018-09-02-i-cleaned-up-my-virtual-basement/)

## Description

Initially built in MonoDevelop 5.5 in 2015. Targeting a Raspberry Pi model B.

The idea and main motivation was to play some music remotely on a Raspberry Pi which was connected to a fairly decent pair of speakers. The player supports basic functions like playing a file from a list, stop playing and increase/decrease the volume. All in realtime powered by SignalR.

at that moment didn't know that at least from the 3.5mm stereo jack you don't get the best audio quality. The POC works pretty well but the quality of the sound was bad. After a little research I found some raspberry sound cards for sell but at least in my country (Argentina) they were expensive (compared to the raspberry pi price bought in the USA)

This POC ended as another fun project which left some initial experience developing in Linux with Mono Develop and also with AngularJS.

This project was originally hosted in a Bitbucket private git repository.

## Install

Except the server all are web applications, they could be hosted in the same Raspberry Pi but where hosted in a Windows Server 2012. Only the server application ran in the Pi. This application never left the POC status and for example doesn't have a Datastore. In that context the angular application gets the data from a `songs.json` file.

The server is configured to use mpg321 as the mp3 player and amixer to change the volume.

## Branches

In the `original-version` branch you will find the almost untouched original version of this application (originally it was divided in three different solutions).

The `master` branch contains a reviewed version of the application with some little refactor included.
