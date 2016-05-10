var app = {
    baseUrl: 'http://localhost:62767'
};

app.game = {
    runSimulation: function () {
        setInterval(request, 5000);
        function request() {
            $.ajax({
                url: app.baseUrl + '/Home/Simulate',
                type: 'POST',
                success: function (data) {
                    app.game.template(data);
                }
            });
        }
    },
    play: function (val) {
        var selectedGame = val.value;
        $.ajax({
            url: app.baseUrl + '/Home/Play',
            data: { game: selectedGame },
            type: 'POST',
            success: function (data) {
                app.game.template(data);
            }
        });

    },
    template: function (data) {
        var message = data.Result;
        var playerscore = data.PlayerScore;
        var opponentScore = data.OpponentScore;

        var playerContainer = $('#score-container > #player').find('span');
        var opponentContainer = $('#score-container > #opponent').find('span');

        $(playerContainer).html(playerscore);
        $(opponentContainer).html(opponentScore);

        $('#player-game').html(data.PlayerGame);
        $('#opponent-game').html(data.OpponentGame);


        if (message != undefined && message != "") {
            alert(message);
        }
    }
}