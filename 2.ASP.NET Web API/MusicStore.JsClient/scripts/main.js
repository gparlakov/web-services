/// <reference path="class.js" />
/// <reference path="controller.js" />
/// <reference path="http-requester.js" />
/// <reference path="jquery-2.0.2.js" />
/// <reference path="persister.js" />



$(document).ready(function () {
    var urlOfService = "http://localhost:49308/api/";
    var dataPersister = persisters.get(urlOfService);

    function errorFunction(error, holder) {
        var message = $("<span>" + error.message + "</span>");

        $(holder).add(message);
    };

    $("#get-all-artists").click(function () {
        dataPersister.artists.getAll(function (artists) { 
            var artistsString = "";

            for (var i = 0; i < artists.length; i++) {
                artistsString += "<span>" + artists[i].Name + "| </span>";
            }

            $("#artists-holder").html(artistsString);
        },
        function (error) {
            errorFunction(error, "#artists-holder");
        });
    });
});

//<script>
//        var serviceUrl = "http://localhost:49308/api/";

//var requester = httpRequester.getJSON(serviceUrl + "Artists", function (artists) {
            
//},
//function (error) {
//    console.log(error.message)
//});

//var requester = httpRequester.postJSON(serviceUrl + "Artists", {Name:"Papata"}, function (response) {
//    console.log(response);
//},
//function (error) {
//    console.log(error.message)
//});
//</script>