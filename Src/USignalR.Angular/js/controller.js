var myModule = angular.module('soulstoneClient', [])

myModule.controller('SoulstoneController', function ($scope, $http) {
    $scope.soulstone = { songs: [], results: [] };
    $scope.search = { text: '' };

    $http.get('songs.json')
        .then(function (res) {
            $scope.soulstone.songs = res.data;
        });

    $(function () {
        $.connection.hub.url = "http://192.168.1.148:1453/signalr";

        hub = $.connection.chatHub;

        hub.client.send = function (data) {
            $("#field").append("<li>" + data + "</li>");
        }

        $.connection.hub.start().done(function () {
            hub.server.welcome();
        });
    });

    $scope.search = function () {
        $scope.soulstone.results = [];
        if ($scope.search.text.length > 0) {
            $scope.soulstone.songs.some(function (item) {
                if (item.title.toLowerCase().indexOf($scope.search.text.toLowerCase()) > -1) {
                    $scope.soulstone.results.push(item)
                }
            });
        }
    };

    $scope.playSong = function (songName) {
        hub.server.play(songName);
    };
});